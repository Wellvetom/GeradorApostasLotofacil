using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.Helper;
using GeradorApostasLotofacil.Infrastructure;
using GeradorApostasLotofacil.Repository;
using Microsoft.EntityFrameworkCore;

namespace GeradorApostasLotofacil.Application
{
    public class GeracaoService : IGeracaoService
    {
        private readonly IApostaRepository _repo;
        private readonly AppDbContext _context;

        public GeracaoService(IApostaRepository repo, AppDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        public ApostaModel GerarJogosInteligentes(decimal quantidadeJogos, int qtdMaisSorteados = 12, int qtdMenosSorteados = 0)
        {
            var random = new Random();

            // Ranking completo ordenado por frequência (mais sorteados primeiro)
            var ranking = _repo.ObterRankingNumeros();

            // Números mais sorteados (top N do ranking)
            var maisSorteados = ranking
                .Take(15)
                .Select(x => x.Numero)
                .ToList();

            // Números menos sorteados (últimos 15 do ranking)
            var menosSorteados = ranking
                .OrderBy(x => x.Quantidade)
                .Take(15)
                .Select(x => x.Numero)
                .ToList();

            // TODOS os números possíveis da Lotofácil
            var todosNumeros = Enumerable.Range(1, 25).ToList();

            // Busca jogos já existentes para garantir ineditismo
            var hashesExistentes = _context.Jogos
                .AsEnumerable()
                .Select(j => JogoHelper.GerarHashJogo(j.Numeros))
                .ToHashSet();

            // Controle dos jogos gerados nessa execução
            var hashesGerados = new HashSet<string>();

            // Cria aposta
            var aposta = new ApostaModel
            {
                DataInclusao = DateTime.Now,
                Jogos = new List<JogoModel>()
            };

            // Limite de tentativas para evitar loop infinito caso o espaço de
            // combinações inéditas esteja praticamente esgotado.
            int quantidadeAlvo = (int)quantidadeJogos;
            const int maxTentativasPorJogo = 1000;
            int tentativasSemSucesso = 0;

            while (aposta.Jogos.Count < quantidadeAlvo)
            {
                // Conjunto de números do jogo em construção. O HashSet garante,
                // por definição, que não haverá números repetidos no mesmo jogo.
                var numerosSelecionados = new HashSet<int>();

                // 1) Seleciona números dos MAIS sorteados (aleatoriamente dentre o pool)
                foreach (var numero in maisSorteados.OrderBy(_ => random.Next()))
                {
                    if (numerosSelecionados.Count >= qtdMaisSorteados) break;
                    numerosSelecionados.Add(numero);
                }

                // 2) Seleciona números dos MENOS sorteados, ignorando os que já
                //    foram escolhidos no passo anterior (evita sobreposição entre
                //    os pools de mais e menos sorteados, que compartilham números).
                int alvoAposMenos = numerosSelecionados.Count + qtdMenosSorteados;
                foreach (var numero in menosSorteados.OrderBy(_ => random.Next()))
                {
                    if (numerosSelecionados.Count >= alvoAposMenos) break;
                    numerosSelecionados.Add(numero); // Add ignora duplicatas
                }

                // 3) Completa o restante com números aleatórios ainda não usados,
                //    até totalizar 15 números distintos.
                foreach (var numero in todosNumeros.OrderBy(_ => random.Next()))
                {
                    if (numerosSelecionados.Count >= 15) break;
                    numerosSelecionados.Add(numero); // Add ignora duplicatas
                }

                // Monta o jogo final ordenado
                var numerosJogo = numerosSelecionados
                    .OrderBy(x => x)
                    .ToList();

                // Salvaguarda: garante 15 números distintos antes de aceitar o jogo.
                if (numerosJogo.Count != 15 || numerosJogo.Distinct().Count() != 15)
                    continue;

                // Gera hash único
                var hash = JogoHelper.GerarHashJogo(numerosJogo);

                // Já existe no banco ou já foi gerado nessa execução?
                if (hashesExistentes.Contains(hash) || hashesGerados.Contains(hash))
                {
                    // Proteção contra loop infinito quando não há mais jogos inéditos possíveis
                    if (++tentativasSemSucesso >= maxTentativasPorJogo)
                    {
                        throw new InvalidOperationException(
                            "Não foi possível gerar novos jogos inéditos com os parâmetros informados. " +
                            "Tente reduzir a quantidade de jogos ou ajustar os filtros.");
                    }
                    continue;
                }

                // Sucesso: registra e adiciona o jogo
                tentativasSemSucesso = 0;
                hashesGerados.Add(hash);

                aposta.Jogos.Add(new JogoModel
                {
                    Numeros = numerosJogo
                });
            }

            return aposta;
        }

        public List<int> GerarJogoComCriterio(int acertosAlvo, int minSorteios)
        {
            if (acertosAlvo < 11 || acertosAlvo > 14)
                throw new ArgumentOutOfRangeException(nameof(acertosAlvo),
                    "O alvo de acertos deve ser 11, 12, 13 ou 14.");

            if (minSorteios < 1)
                throw new ArgumentOutOfRangeException(nameof(minSorteios),
                    "A quantidade de sorteios deve ser pelo menos 1.");

            var random = new Random();

            // Conjuntos de números de cada sorteio oficial importado (UsuarioId == null).
            var sorteiosOficiais = _context.Apostas
                .Where(a => a.UsuarioId == null)
                .Include(a => a.Jogos)
                .AsEnumerable()
                .SelectMany(a => a.Jogos)
                .Select(j => j.Numeros.ToHashSet())
                .Where(s => s.Count > 0)
                .ToList();

            if (sorteiosOficiais.Count == 0)
                throw new InvalidOperationException(
                    "Não há sorteios oficiais importados para basear a geração. Importe resultados primeiro.");

            if (sorteiosOficiais.Count < minSorteios)
                throw new InvalidOperationException(
                    $"Existem apenas {sorteiosOficiais.Count} sorteios importados, " +
                    $"menos que os {minSorteios} solicitados.");

            // Hashes já existentes na base (jogos de usuários e sorteios) para garantir ineditismo.
            var hashesExistentes = _context.Jogos
                .AsEnumerable()
                .Select(j => JogoHelper.GerarHashJogo(j.Numeros))
                .ToHashSet();

            var todosNumeros = Enumerable.Range(1, 25).ToList();

            // Espaço de busca é grande; usamos tentativas aleatórias com um teto de segurança.
            const int maxTentativas = 200_000;

            for (int tentativa = 0; tentativa < maxTentativas; tentativa++)
            {
                // Sorteia 15 números distintos de 1 a 25.
                var numerosJogo = todosNumeros
                    .OrderBy(_ => random.Next())
                    .Take(15)
                    .OrderBy(n => n)
                    .ToList();

                var hash = JogoHelper.GerarHashJogo(numerosJogo);
                if (hashesExistentes.Contains(hash))
                    continue; // não é inédito

                var conjunto = numerosJogo.ToHashSet();

                // Conta em quantos sorteios oficiais a interseção atinge o alvo de acertos.
                int sorteiosQueAtingem = 0;
                foreach (var sorteio in sorteiosOficiais)
                {
                    int acertos = 0;
                    foreach (var n in sorteio)
                    {
                        if (conjunto.Contains(n)) acertos++;
                    }

                    if (acertos >= acertosAlvo)
                    {
                        sorteiosQueAtingem++;
                        if (sorteiosQueAtingem >= minSorteios)
                            break;
                    }
                }

                if (sorteiosQueAtingem >= minSorteios)
                    return numerosJogo;
            }

            throw new InvalidOperationException(
                $"Não foi possível gerar um jogo inédito com pelo menos {acertosAlvo} acertos " +
                $"em {minSorteios} sorteio(s) após {maxTentativas:N0} tentativas. " +
                "Tente reduzir o alvo de acertos ou a quantidade de sorteios.");
        }
    }
}

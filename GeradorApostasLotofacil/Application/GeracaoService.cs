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
    }
}

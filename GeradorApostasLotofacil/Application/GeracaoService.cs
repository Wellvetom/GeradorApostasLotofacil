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

            // Quantidade de números aleatórios (restante para completar 15)
            int qtdAleatorios = 15 - qtdMaisSorteados - qtdMenosSorteados;

            while (aposta.Jogos.Count < (int)quantidadeJogos)
            {
                // Seleciona N números dos mais sorteados (aleatoriamente dentre os top 15)
                var escolhidosMais = maisSorteados
                    .OrderBy(x => random.Next())
                    .Take(qtdMaisSorteados)
                    .ToList();

                // Seleciona N números dos menos sorteados (aleatoriamente dentre os bottom 15)
                var escolhidosMenos = menosSorteados
                    .OrderBy(x => random.Next())
                    .Take(qtdMenosSorteados)
                    .ToList();

                // Números já usados
                var numerosUsados = escolhidosMais.Concat(escolhidosMenos).ToHashSet();

                // Números disponíveis para preencher o restante (exclui os já usados)
                var numerosDisponiveis = todosNumeros
                    .Where(n => !numerosUsados.Contains(n))
                    .ToList();

                // Escolhe aleatórios dos restantes
                var aleatorios = numerosDisponiveis
                    .OrderBy(x => random.Next())
                    .Take(qtdAleatorios)
                    .ToList();

                // Monta o jogo final com 15 números
                var numerosJogo = escolhidosMais
                    .Concat(escolhidosMenos)
                    .Concat(aleatorios)
                    .OrderBy(x => x)
                    .ToList();

                // Gera hash único
                var hash = JogoHelper.GerarHashJogo(numerosJogo);

                // Já existe no banco?
                if (hashesExistentes.Contains(hash))
                    continue;

                // Já foi gerado nessa aposta?
                if (hashesGerados.Contains(hash))
                    continue;

                // Adiciona controle
                hashesGerados.Add(hash);

                // Cria jogo
                var jogo = new JogoModel
                {
                    Numeros = numerosJogo
                };

                aposta.Jogos.Add(jogo);
            }

            return aposta;
        }
    }
}

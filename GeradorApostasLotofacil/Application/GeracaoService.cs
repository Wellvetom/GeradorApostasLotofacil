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

        public ApostaModel GerarJogosInteligentes(decimal quantidadeJogos)
        {
            var random = new Random();

            // TOP 12 FIXOS
            var top12 = _repo.ObterRankingNumeros()
                .Take(12)
                .Select(x => x.Numero)
                .ToList();

            // TODOS os números possíveis
            var todosNumeros = Enumerable.Range(1, 25).ToList();

            // Remove os fixos
            var numerosDisponiveis = todosNumeros
                .Except(top12)
                .ToList();

            // Busca jogos já existentes
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

            while (aposta.Jogos.Count < (int)quantidadeJogos)
            {
                // Escolhe SOMENTE 3 aleatórios
                var tresAleatorios = numerosDisponiveis
                    .OrderBy(x => random.Next())
                    .Take(3)
                    .ToList();

                // Junta TOP12 + 3 aleatórios
                var numerosJogo = top12
                    .Concat(tresAleatorios)
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

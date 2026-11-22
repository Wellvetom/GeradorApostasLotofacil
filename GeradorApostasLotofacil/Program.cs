using GeradorApostasLotofacil.Application;
using GeradorApostasLotofacil.Domain;
using GeradorApostasLotofacil.Infrastructure;
using GeradorApostasLotofacil.Repository;
using GeradorApostasLotofacil.Session;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GeradorApostasLotofacil
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Sessão de usuário é compartilhada entre as duas modalidades (login único).
            var session = new UsuarioSession();

            // Um provedor de serviços independente por modalidade, cada um com sua LoteriaConfig.
            var providerLotofacil = BuildProvider(LoteriaConfig.Lotofacil, connectionString, session);
            var providerMegaSena = BuildProvider(LoteriaConfig.MegaSena, connectionString, session);

            // Menu de cada aba, ligado ao provedor da respectiva modalidade.
            var menuLotofacil = providerLotofacil.GetRequiredService<FormMenuPrincipal>();
            menuLotofacil.InitializeNavigation(providerLotofacil);

            var menuMegaSena = providerMegaSena.GetRequiredService<FormMenuPrincipal>();
            menuMegaSena.InitializeNavigation(providerMegaSena);

            // Shell com as duas abas.
            var shell = new FormShell();
            shell.AdicionarAba(LoteriaConfig.Lotofacil, menuLotofacil);
            shell.AdicionarAba(LoteriaConfig.MegaSena, menuMegaSena);

            System.Windows.Forms.Application.Run(shell);
        }

        /// <summary>
        /// Monta um contêiner de DI parametrizado para uma modalidade específica.
        /// A <see cref="UsuarioSession"/> é a mesma instância em ambos os contêineres.
        /// </summary>
        private static ServiceProvider BuildProvider(LoteriaConfig config, string? connectionString, UsuarioSession session)
        {
            var services = new ServiceCollection();

            // Configuração da modalidade (injetada em serviços e forms).
            services.AddSingleton(config);

            // DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Repositories
            services.AddScoped<IApostaRepository, ApostaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // Services
            services.AddScoped<IApostaService, ApostaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IGeracaoService, GeracaoService>();
            services.AddScoped<IImportacaoService, ImportacaoService>();
            services.AddScoped<IConferenciaService, ConferenciaService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IAdminDashboardService, AdminDashboardService>();

            // Cliente HTTP direto da API da Caixa (substitui o parser fixo da DLL).
            services.AddSingleton<ICaixaLoteriaClient, CaixaLoteriaClient>();

            // Session compartilhada
            services.AddSingleton(session);

            // Forms
            services.AddTransient<FormLogin>();
            services.AddTransient<FormCadastro>();
            services.AddTransient<FormGerarApostas>();
            services.AddTransient<FormApostaManual>();
            services.AddTransient<FormListarApostas>();
            services.AddTransient<FormVerificarAposta>();
            services.AddTransient<FormImportarApostas>();
            services.AddTransient<FormDashboard>();
            services.AddTransient<FormDashboardAdmin>();
            services.AddSingleton<FormMenuPrincipal>();

            return services.BuildServiceProvider();
        }
    }
}

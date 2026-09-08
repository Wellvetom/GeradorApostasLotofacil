using GeradorApostasLotofacil.Application;
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

            var services = new ServiceCollection();

            // DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

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

            // Session (singleton)
            services.AddSingleton<UsuarioSession>();

            // Forms
            services.AddTransient<FormLogin>();
            services.AddTransient<FormCadastro>();
            services.AddTransient<FormGerarApostas>();
            services.AddTransient<FormListarApostas>();
            services.AddTransient<FormVerificarAposta>();
            services.AddTransient<FormImportarApostas>();
            services.AddTransient<FormDashboard>();
            services.AddTransient<FormDashboardAdmin>();
            services.AddSingleton<FormMenuPrincipal>();

            // NavigationService will be registered after FormMenuPrincipal is created
            // because it needs the panel reference

            var serviceProvider = services.BuildServiceProvider();

            var mainForm = serviceProvider.GetRequiredService<FormMenuPrincipal>();
            mainForm.InitializeNavigation(serviceProvider);

            System.Windows.Forms.Application.Run(mainForm);
        }
    }
}

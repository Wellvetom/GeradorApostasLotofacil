using GeradorApostasLotofacil.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace GeradorApostasLotofacil.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<ApostaModel> Apostas { get; set; }
        public DbSet<JogoModel> Jogos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Parameterless constructor for EF Core migrations
        public AppDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();

                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JogoModel>()
                .HasOne(t => t.Aposta)
                .WithMany(u => u.Jogos)
                .HasForeignKey(t => t.ApostaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApostaModel>()
                .HasOne(t => t.Usuario)
                .WithMany(u => u.Apostas)
                .HasForeignKey(t => t.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<JogoModel>()
                .Property(j => j.Numeros)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<List<int>>(v, (JsonSerializerOptions?)null) ?? new List<int>()
                )
                .HasColumnType("nvarchar(max)");

            // Modalidade persistida como int (0 = Lotofácil, 1 = Mega Sena).
            // Registros existentes recebem 0 (Lotofácil) via valor default na migration.
            modelBuilder.Entity<ApostaModel>()
                .Property(a => a.Modalidade)
                .HasConversion<int>()
                .HasDefaultValue(Modalidade.Lotofacil);
        }
    }
}

using GeradorApostasLotofacil.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeradorApostasLotofacil.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<ApostaModel> Apostas { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(
            "Server=wellington-pc\\sqlexpress;Database=BD_GeradorDeApostas;Trusted_Connection=True;TrustServerCertificate=True");
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
        }

    }
}

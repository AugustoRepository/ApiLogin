using ApiLogin.Repository.Entities;
using ApiLogin.Repository.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ApiLogin.Repository.Contexts
{
    public  class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PerfilMap()); 
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(u => u.Email).IsUnique();
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasIndex(u => u.Nome).IsUnique();
            });
        }
    }
}

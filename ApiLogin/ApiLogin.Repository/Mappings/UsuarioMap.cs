using ApiLogin.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Repository.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            
            builder.HasKey(u => u.IdUsuario);

          
            builder.Property(u => u.IdUsuario)
                .HasColumnName("IdUsuario");

            builder.Property(u => u.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("Email")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(u => u.Senha)
                .HasColumnName("Senha")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.DataCadastro)
                .HasColumnName("DataCadastro")
                .IsRequired();

            builder.Property(u => u.Cnpj)
                 .HasMaxLength(150)
                 .HasColumnName("Cnpj")
                .IsRequired();

            builder.Property(u => u.Cpf)
                .HasColumnName("Cpf")
               .HasMaxLength(150)
              .IsRequired();


            builder.HasMany(u => u.Enderecos)
               .WithOne(e => e.Usuario)
               .HasForeignKey(e => e.IdUsuario);

            // Relacionamento com Pedido
            builder.HasMany(u => u.Pedidos)
                   .WithOne(p => p.Usuario)
                   .HasForeignKey(p => p.IdUsuario);

            // Relacionamento com Cartao
            builder.HasMany(u => u.Cartoes)
                   .WithOne(c => c.Usuario)
                   .HasForeignKey(c => c.IdUsuario);

            // Relacionamento com Pix
            builder.HasMany(u => u.Pixs)
                   .WithOne(p => p.Usuario)
                   .HasForeignKey(p => p.IdUsuario);

        }
    }
}

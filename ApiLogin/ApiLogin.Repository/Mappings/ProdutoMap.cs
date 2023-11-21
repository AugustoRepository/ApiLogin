using ApiLogin.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Repository.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            
            builder.HasKey(u => u.IdProduto);

          
            builder.Property(u => u.IdProduto)
                .HasColumnName("ProdutoId");

            builder.Property(u => u.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(u => u.Informacoes)
                .HasColumnName("Informacoes")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(u => u.Imagem)
                .HasColumnName("Imagem")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.DataCadastro)
                .HasColumnName("DataCadastro")
                .IsRequired();

            builder.Property(u => u.Peso)
                .HasColumnName("Peso")
                .IsRequired();
            builder.Property(u => u.Preco)
                .HasColumnName("Preco")
              .IsRequired();

            builder.HasOne(p => p.Usuario)
               .WithMany(u => u.Produtos)
               .HasForeignKey(p => p.IdUsuario);
        }
    }
}

using ApiLogin.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Repository.Mappings
{
    public  class CartaoMap : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.ToTable("Cartao");

            builder.HasKey(u => u.IdCartao);


            builder.Property(u => u.IdCartao)
                .HasColumnName("IdCartao");


            builder.Property(e => e.IdUsuario)                
                .HasColumnName("IdUsuario")
                .IsRequired();

            builder.Property(e => e.CVV)
                .HasMaxLength(250)
                .HasColumnName("CVV")
                .IsRequired();

            builder.Property(e => e.ValidadeCartao)
                .HasColumnName("ValidadeCartao")
                .IsRequired();

            builder.Property(e => e.NomeTitular)
                .HasMaxLength(250)
                .HasColumnName("NomeTitular")
                .IsRequired();


            builder.Property(e => e.BandeiraCartao)
                .HasMaxLength(250)
                .HasColumnName("BandeiraCartao")
                .IsRequired();

            builder.Property(e => e.NumeroCartao)
                .HasMaxLength(250)
                .HasColumnName("NumeroCartao")
                .IsRequired();



            builder.HasOne(p => p.Usuario)
               .WithMany(u => u.Cartoes)
               .HasForeignKey(p => p.IdUsuario);

        }
    }
}

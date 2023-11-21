using ApiLogin.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Repository.Mappings
{
    public  class EnderecoMap
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(u => u.IdEndereco);


            builder.Property(u => u.IdEndereco)
                .HasColumnName("IdEndereco");


            builder.Property(e => e.Rua)
                .HasMaxLength(250)
                .HasColumnName("Rua")
                .IsRequired();

            builder.Property(e => e.Numero)
                .HasMaxLength(250)
                .HasColumnName("Numero")
                .IsRequired();

            builder.Property(e => e.Complemento)
                .HasColumnName("Complemento")
                .HasMaxLength(250);

            builder.Property(e => e.Cidade)
                .HasMaxLength(250)
                .HasColumnName("Cidade")
                .IsRequired();

            builder.Property(e => e.Estado)
                .HasMaxLength(250)
                .HasColumnName("Estado")
                .IsRequired();

            builder.Property(e => e.CEP)
                .HasMaxLength(250)
                .HasColumnName("CEP")
                .IsRequired();


            builder.HasOne(p => p.Usuario)
               .WithMany(u => u.Enderecos)
               .HasForeignKey(p => p.IdUsuario);

        }
    }
}

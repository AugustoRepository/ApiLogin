using ApiLogin.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Repository.Mappings
{
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
          
            builder.ToTable("Perfil");

            builder.HasKey(p => p.IdPerfil);

            builder.Property(p => p.IdPerfil)
                .HasColumnName("IdPerfil");

            builder.Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(50)
                .IsRequired();

        }
    }
}

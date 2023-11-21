using ApiLogin.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Repository.Mappings
{
    public  class PixMap : IEntityTypeConfiguration<Pix>
    { 
        public void Configure(EntityTypeBuilder<Pix> builder)
        {
            builder.ToTable("Pix");

            builder.HasKey(u => u.IdPix);


            builder.Property(u => u.IdPix)
                .HasColumnName("IdPix");


            builder.Property(e => e.IdUsuario)                
                .HasColumnName("IdUsuario")
                .IsRequired();

            builder.Property(e => e.ChavePix)
                .HasMaxLength(250)
                .HasColumnName("ChavePix")
                .IsRequired();

            builder.Property(e => e.DataTransacao)
                .HasColumnName("DataTransacao")
                .HasMaxLength(250);

            builder.Property(e => e.Valor)       
                .HasColumnName("Valor")
                .IsRequired();         

            builder.HasOne(p => p.Usuario)
               .WithMany(u => u.Pixs)
               .HasForeignKey(p => p.IdUsuario);

        }
    }
}

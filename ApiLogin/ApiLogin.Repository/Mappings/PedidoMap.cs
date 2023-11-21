using ApiLogin.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Repository.Mappings
{
    public  class PedidoMap
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");

            builder.HasKey(u => u.IdPedido);


            builder.Property(u => u.IdPedido)
                .HasColumnName("IdPedido");


            builder.Property(e => e.DataPedido)
                .HasMaxLength(250)
                .HasColumnName("Rua")
                .IsRequired();

            builder.Property(e => e.ValorTotal)
                .HasMaxLength(250)
                .HasColumnName("Numero")
                .IsRequired();

            builder.Property(e => e.Status)
                .HasColumnName("Complemento")
                .HasMaxLength(250);


            builder.HasOne(p => p.Usuario)
               .WithMany(u => u.Pedidos)
               .HasForeignKey(p => p.IdUsuario);

        }
    }
}

using ApiLogin.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Repository.Mappings
{
    public  class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");

            builder.HasKey(u => u.IdPedido);


            builder.Property(u => u.IdPedido)
                .HasColumnName("IdPedido");


            builder.Property(e => e.DataPedido)                
                .HasColumnName("DataPedido")
                .IsRequired();

            builder.Property(e => e.ValorTotal)          
                .HasColumnName("ValorTotal")
                .IsRequired();

            builder.Property(e => e.Status)
                .HasColumnName("Status")
                .IsRequired();

            builder.HasOne(p => p.Usuario)
               .WithMany(u => u.Pedidos)
               .HasForeignKey(p => p.IdUsuario);

        }
    }
}

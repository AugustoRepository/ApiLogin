using ApiLogin.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Repository.Mappings
{
    public  class ItemPedidoMap
    {
        public void Configure(EntityTypeBuilder<ItensPedido> builder)
        {
            builder.ToTable("Pedido");

            builder.HasKey(u => u.IdItemPedido);


            builder.Property(u => u.IdItemPedido)
                .HasColumnName("IdItemPedido");


            builder.Property(e => e.IdItemPedido)              
                .HasColumnName("Rua")
                .IsRequired();

            builder.Property(e => e.ValorTotal)             
                .HasColumnName("ValorTotal")
                .IsRequired();


            builder.Property(e => e.Preco)
                .HasColumnName("Preco")
                .IsRequired();


            builder.Property(e => e.Quantidade)
                .HasColumnName("Quantidade")
                .HasMaxLength(250);

            

        }
    }
}

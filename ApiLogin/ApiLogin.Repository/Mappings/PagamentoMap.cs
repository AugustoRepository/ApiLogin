using ApiLogin.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Repository.Mappings
{
    public  class PagamentoMap : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable("Pagamento");

            builder.HasKey(u => u.IdPagamento);


            builder.Property(u => u.IdPagamento)
                .HasColumnName("IdPagamento");


            builder.Property(e => e.DataPagamento)
                .HasMaxLength(250)
                .HasColumnName("DataPagamento")
                .IsRequired();

            builder.Property(e => e.MetodoPagamento)
                .HasMaxLength(250)
                .HasColumnName("MetodoPagamento")
                .IsRequired();

            builder.Property(e => e.Valor)
                .HasColumnName("Valor")
                .HasMaxLength(250)
                .IsRequired();
            
            builder.Property(e => e.Status)
            .HasColumnName("Status")
            .IsRequired();


            builder.Property(e => e.PedidoId)
                .HasColumnName("PedidoId")
                .IsRequired();

            //Relacionamento de cardinalidade 1 para MUITOS
            builder.HasOne(t => t.Pedido) //Tarefa TEM 1 Usuário
                .WithMany(u => u.Pagamento) //Usuário TEM MUITAS Tarefas
                .HasForeignKey(t => t.PedidoId); //chave estrangeira

        }
    }
}

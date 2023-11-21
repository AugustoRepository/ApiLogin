using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Repository.Entities
{
    public  class ItemPedido
    {
        public int IdItemPedido { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public double ValorTotal { get; set; }
        // Outras propriedades relacionadas a um item de pedido

        public int IdPedido { get; set; }
        public Pedido Pedido { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
        
    }
}

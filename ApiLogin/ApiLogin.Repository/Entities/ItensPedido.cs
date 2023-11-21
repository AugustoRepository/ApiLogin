using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Repository.Entities
{
    public  class ItensPedido
    {
        public int IdItemPedido { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public double ValorTotal { get { return Quantidade * Preco; } }
        // Outras propriedades relacionadas a um item de pedido

        public int IdPedido { get; set; }
        public Pedido Pedido { get; set; }
    }
}

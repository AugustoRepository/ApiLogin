using ApiLogin.Repository.Enuns;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Presentation.Model
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public DateTime DataPedido { get; set; }
        public double ValorTotal { get; set; }
        // Outras propriedades relacionadas a um pedido

        public StatusPedidoEnum Status { get; set; }

        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public List<ItemPedido> ItensPedido { get; set; }
        public List<Pagamento> Pagamento { get; set; }


    }
}

using ApiLogin.Repository.Enuns;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Presentation.Model
{
    public class PedidoConsultaModel
    {
        public int IdPedido { get; set; }
        public DateTime DataPedido { get; set; }
        public double ValorTotal { get; set; }

        public StatusPedidoEnum Status { get; set; }    

    }
}

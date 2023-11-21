using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ApiLogin.Repository.Enuns
{
    public enum StatusPedidoEnum
    {
        [Description("Pendente")]
        Pendente,

        [Description("Em Processamento")]
        EmProcessamento,

        [Description("Concluído")]
        Concluido,

        [Description("Cancelado")]
        Cancelado,

        [Description("Venda Aberta")]
        VendaAberta
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Presentation.Model
{
    public class PagamentoModel
    {
        public decimal Valor { get; set; }
        public DateTime DataPagamento { get; set; }
        public int MetodoPagamento { get; set; }
        public int Status { get; set; }
        // Outras propriedades relacionadas ao pagamento, se necessário


    }
}

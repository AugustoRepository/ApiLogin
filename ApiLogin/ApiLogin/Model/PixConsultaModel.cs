using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Presentation.Model
{
    public class PixConsultaModel
    {
        public int Id { get; set; }
        public string ChavePix { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataTransacao { get; set; }
        // Outras propriedades relacionadas a uma transação PIX, se necessário  
    }

}

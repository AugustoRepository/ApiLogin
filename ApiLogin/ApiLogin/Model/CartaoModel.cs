using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Presentation.Model
{
    public class CartaoModel
    {
        public int IdCartao { get; set; }
        public string NumeroCartao { get; set; }
        public string NomeTitular { get; set; }
        public string BandeiraCartao { get; set; }
        public DateTime ValidadeCartao { get; set; }
        public string CVV { get; set; } 
    }
}

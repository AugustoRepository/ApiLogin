using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Repository.Entities
{
    public class Cartao
    {
        public int IdCartao { get; set; }
        public string NumeroCartao { get; set; }
        public string NomeTitular { get; set; }
        public string BandeiraCartao { get; set; }
        public DateTime ValidadeCartao { get; set; }
        public string CVV { get; set; } // Adicionando o CVV
                                        // Outras propriedades relacionadas ao cartão, se necessário

        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}

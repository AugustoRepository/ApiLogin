using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Presentation.Model
{
    public class Endereco
    {
        public int IdEndereco { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }

        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

    }
}

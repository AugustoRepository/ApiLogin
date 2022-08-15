using System;

namespace ApiLogin.Presentation.Model
{
    public class UsuarioConsultaModel
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public int IdPerfil { get; set; }
    }
}

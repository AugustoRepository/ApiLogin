using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Repository.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public int IdPerfil { get; set; }

        #region Relacionamentos

        public Perfil Perfil { get; set; }

        #endregion
    }
}

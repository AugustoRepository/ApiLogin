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
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool UsuarioAdministrativo { get; set; }

        #region Relacionamentos

        public List<Produto> Produtos { get; set; }
        public List<Endereco> Enderecos { get; set; }
        public List<Pedido> Pedidos { get; set; }
        public List<Cartao> Cartoes { get; set; }
        public List<Pix> Pixs { get; set; }

        #endregion
    }
}

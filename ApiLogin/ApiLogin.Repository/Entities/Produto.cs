using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Repository.Entities
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public double Peso { get; set; }
        public string Informacoes { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Imagem { get; set; }

        // Relacionamento 1 para muitos com Usuário
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}

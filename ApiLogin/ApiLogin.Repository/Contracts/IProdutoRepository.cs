using ApiLogin.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Repository.Contracts
{
    public interface IProdutoRepository
    {
        void Add(Produto produto);
        void  Update(Produto produto);
        void Delete(Produto produto);
        List<Produto> GetAll();
        Produto Get(int id);
    }
}

using ApiLogin.Repository.Contexts;
using ApiLogin.Repository.Contracts;
using ApiLogin.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiLogin.Repository.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext dataContext;

        public ProdutoRepository(DataContext dataContex)
        {
            dataContext = dataContex;
        }

        public void Add(Produto Produto)
        {
            dataContext.Produto.Add(Produto);
            dataContext.SaveChanges();
        }

        public void Delete(Produto produto)
        {
            dataContext.Produto.Remove(produto);
            dataContext.SaveChanges();
        }

        public Produto Get(int id)
        {
            return dataContext.Produto.FirstOrDefault(u => u.IdProduto == id);
        }

        public List<Produto> GetAll()
        {
            return dataContext.Produto.OrderBy(p => p.Nome).ToList();
        }

        public void Update(Produto produto)
        {
            dataContext.Entry(produto).State = EntityState.Modified;
            dataContext.SaveChanges();
        }
    }
}

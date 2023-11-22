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
    public class CartaoRepository : ICartaoRepository
    {
        private readonly DataContext dataContext;

        public CartaoRepository(DataContext dataContex)
        {
            dataContext = dataContex;
        }

        public void Add(Cartao cartao)
        {
            dataContext.Cartao.Add(cartao);
            dataContext.SaveChanges();
        }

        public void Delete(Cartao cartao)
        {
            dataContext.Cartao.Remove(cartao);
            dataContext.SaveChanges();
        }

        public Cartao Get(int id)
        {
            return dataContext.Cartao.FirstOrDefault(u => u.IdCartao == id);
        }

        public List<Cartao> GetAll()
        {
            return dataContext.Cartao.OrderBy(p => p.IdCartao).ToList();
        }

        public void Update(Cartao cartao)
        {
            dataContext.Entry(cartao).State = EntityState.Modified;
            dataContext.SaveChanges();
        }
    }
}

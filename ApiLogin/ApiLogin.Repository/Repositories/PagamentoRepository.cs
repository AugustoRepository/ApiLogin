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
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly DataContext dataContext;

        public PagamentoRepository(DataContext dataContex)
        {
            dataContext = dataContex;
        }

        public void Add(Pagamento pagamento)
        {
            dataContext.Pagamento.Add(pagamento);
            dataContext.SaveChanges();
        }

        public void Delete(Pagamento pagamento)
        {
            dataContext.Pagamento.Remove(pagamento);
            dataContext.SaveChanges();
        }

        public Pagamento Get(int id)
        {
            return dataContext.Pagamento.FirstOrDefault(u => u.IdPagamento == id);
        }

        public List<Pagamento> GetAll()
        {
            return dataContext.Pagamento.OrderBy(p => p.IdPagamento).ToList();
        }

        public void Update(Pagamento pagamento)
        {
            dataContext.Entry(pagamento).State = EntityState.Modified;
            dataContext.SaveChanges();
        }
    }
}

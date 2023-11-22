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
    public class PedidoRepository : IPedidoRepository
    {
        private readonly DataContext dataContext;

        public PedidoRepository(DataContext dataContex)
        {
            dataContext = dataContex;
        }

        public void Add(Pedido pedido)
        {
            dataContext.Pedido.Add(pedido);
            dataContext.SaveChanges();
        }

        public void Delete(Pedido pedido)
        {
            dataContext.Pedido.Remove(pedido);
            dataContext.SaveChanges();
        }

        public Pedido Get(int id)
        {
            return dataContext.Pedido.FirstOrDefault(u => u.IdPedido == id);
        }

        public List<Pedido> GetAll()
        {
            return dataContext.Pedido.OrderBy(p => p.IdPedido).ToList();
        }

        public void Update(Pedido pedido)
        {
            dataContext.Entry(pedido).State = EntityState.Modified;
            dataContext.SaveChanges();
        }
    }
}

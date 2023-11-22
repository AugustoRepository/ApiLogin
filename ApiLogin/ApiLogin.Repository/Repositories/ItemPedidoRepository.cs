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
    public class ItemPedidoRepository : IItemPedidoRepository
    {
        private readonly DataContext dataContext;

        public ItemPedidoRepository(DataContext dataContex)
        {
            dataContext = dataContex;
        }

        public void Add(ItemPedido itemPedido)
        {
            dataContext.ItemPedido.Add(itemPedido);
            dataContext.SaveChanges();
        }

        public void Delete(ItemPedido itemPedido)
        {
            dataContext.ItemPedido.Remove(itemPedido);
            dataContext.SaveChanges();
        }

        public ItemPedido Get(int id)
        {
            return dataContext.ItemPedido.FirstOrDefault(u => u.IdItemPedido == id);
        }

        public List<ItemPedido> GetAll()
        {
            return dataContext.ItemPedido.OrderBy(p => p.IdItemPedido).ToList();
        }

        public void Update(ItemPedido itemPedido)
        {
            dataContext.Entry(itemPedido).State = EntityState.Modified;
            dataContext.SaveChanges();
        }
    }
}

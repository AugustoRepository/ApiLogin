using ApiLogin.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Repository.Contracts
{
    public interface IItemPedidoRepository
    {
        void Add(ItemPedido ItemPedido);
        void Update(ItemPedido ItemPedido);
        void Delete(ItemPedido ItemPedido);
        List<ItemPedido> GetAll();
        ItemPedido Get(int id);
    }
}

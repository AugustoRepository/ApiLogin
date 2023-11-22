using ApiLogin.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Repository.Contracts
{
    public interface IPedidoRepository
    {
        void Add(Pedido pedido);
        void Update(Pedido pedido);
        void Delete(Pedido pedido);
        List<Pedido> GetAll();
        Pedido Get(int id);
    }
}

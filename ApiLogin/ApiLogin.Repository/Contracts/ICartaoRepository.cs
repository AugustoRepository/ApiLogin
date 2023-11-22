using ApiLogin.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Repository.Contracts
{
    public interface ICartaoRepository
    {
        void Add(Cartao cartao);
        void Update(Cartao cartao);
        void Delete(Cartao cartao);
        List<Cartao> GetAll();
        Cartao Get(int id);
    }
}

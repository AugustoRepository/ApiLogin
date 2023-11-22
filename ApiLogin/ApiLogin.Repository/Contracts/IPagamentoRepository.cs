using ApiLogin.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Repository.Contracts
{
    public interface IPagamentoRepository
    {
        void Add(Pagamento pagamento);
        void Update(Pagamento pagamento);
        void Delete(Pagamento pagamento);
        List<Pagamento> GetAll();
        Pagamento Get(int id);
    }
}

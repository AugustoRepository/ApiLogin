using ApiLogin.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Repository.Contracts
{
    public interface IEnderecoRepository
    {
        void Add(Endereco endereco);
        void Update(Endereco endereco);
        void Delete(Endereco endereco);
        List<Endereco> GetAll();
        Endereco Get(int id);
    }
}

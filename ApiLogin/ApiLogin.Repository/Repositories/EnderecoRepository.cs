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
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly DataContext dataContext;

        public EnderecoRepository(DataContext dataContex)
        {
            dataContext = dataContex;
        }

        public void Add(Endereco endereco)
        {
            dataContext.Endereco.Add(endereco);
            dataContext.SaveChanges();
        }

        public void Delete(Endereco endereco)
        {
            dataContext.Endereco.Remove(endereco);
            dataContext.SaveChanges();
        }

        public Endereco Get(int id)
        {
            return dataContext.Endereco.FirstOrDefault(u => u.IdEndereco == id);
        }

        public List<Endereco> GetAll()
        {
            return dataContext.Endereco.OrderBy(p => p.IdEndereco).ToList();
        }

        public void Update(Endereco endereco)
        {
            dataContext.Entry(endereco).State = EntityState.Modified;
            dataContext.SaveChanges();
        }
    }
}

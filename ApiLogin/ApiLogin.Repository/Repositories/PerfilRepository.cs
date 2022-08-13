using ApiLogin.Repository.Contexts;
using ApiLogin.Repository.Contracts;
using ApiLogin.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiLogin.Repository.Repositories
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly DataContext dataContext;

        public PerfilRepository(DataContext dataContex)
        {
            dataContext = dataContex;
        }
        public List<Perfil> GetAll()
        {
            return dataContext.Perfil.OrderBy(p => p.Nome).ToList();
        }
    }
}

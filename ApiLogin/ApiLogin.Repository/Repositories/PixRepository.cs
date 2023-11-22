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
    public class PixRepository : IPixRepository
    {
        private readonly DataContext dataContext;

        public PixRepository(DataContext dataContex)
        {
            dataContext = dataContex;
        }

        public void Add(Pix pix)
        {
            dataContext.Pix.Add(pix);
            dataContext.SaveChanges();
        }

        public void Delete(Pix pix)
        {
            dataContext.Pix.Remove(pix);
            dataContext.SaveChanges();
        }

        public Pix Get(int id)
        {
            return dataContext.Pix.FirstOrDefault(u => u.IdPix == id);
        }

        public List<Pix> GetAll()
        {
            return dataContext.Pix.OrderBy(p => p.IdPix).ToList();
        }

        public void Update(Pix pix)
        {
            dataContext.Entry(pix).State = EntityState.Modified;
            dataContext.SaveChanges();
        }
    }
}

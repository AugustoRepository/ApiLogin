using ApiLogin.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Repository.Contracts
{
    public interface IPixRepository
    {
        void Add(Pix pix);
        void Update(Pix pix);
        void Delete(Pix pix);
        List<Pix> GetAll();
        Pix Get(int id);
    }
}

using ApiLogin.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Repository.Contracts
{
    public interface IPerfilRepository
    {
        List<Perfil> GetAll();
    }
}

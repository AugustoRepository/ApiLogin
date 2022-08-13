using ApiLogin.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiLogin.Repository.Contracts
{
    public interface IUsuarioRepository
    {
        void Add(Usuario usuario);
        List<Usuario> GetAll();
        Usuario Get(int id);
        Usuario GetByEmailAndSenha(string email, string senha);
        Usuario GetbyEmail(string email);
    }
}

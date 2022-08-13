using ApiLogin.Repository.Contexts;
using ApiLogin.Repository.Contracts;
using ApiLogin.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiLogin.Repository.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext dataContext;

        public UsuarioRepository(DataContext dataContex)
        {
            dataContext = dataContex;
        }

        public void Add(Usuario usuario)
        {
            dataContext.Usuario.Add(usuario);
            dataContext.SaveChanges();
        }

        public Usuario Get(int id)
        {
            return dataContext.Usuario.FirstOrDefault(u => u.IdUsuario == id);
        }

        public List<Usuario> GetAll()
        {
            return dataContext.Usuario.OrderBy(p => p.Nome).ToList();
        }

        public Usuario GetbyEmail(string email)
        {
            return dataContext.Usuario.FirstOrDefault(u =>  u.Email.Equals(email));
        }

        public Usuario GetByEmailAndSenha(string email, string senha)
        {
            return dataContext.Usuario.FirstOrDefault(u => u.Email.Equals(email) && u.Senha.Equals(senha));
        }
    }
}

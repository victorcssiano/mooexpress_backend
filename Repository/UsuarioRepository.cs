using mooexpress.Data;
using mooexpress.Interfaces;
using mooexpress.Models;
using System.Linq;

namespace mooexpress.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _context;

        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateUsuario(Usuario usuario)
        {
            _context.Add(usuario);
            return Save();
        }

        public Usuario GetUsuario(int id)
        {
            return _context.Usuarios.Where(u => u.Id == id).FirstOrDefault();
        }

        public Usuario GetUsuario(string nome)
        {
            return _context.Usuarios.Where(u => u.Nome == nome).FirstOrDefault();
        }

        public Usuario GetUsuarioCodigo(int codigo)
        {
            return _context.Usuarios.Where(u => u.codigo == codigo).FirstOrDefault();
        }

        public Usuario GetUsuarioEmail(string email)
        {
            return _context.Usuarios.Where(u => u.Email == email).FirstOrDefault();
        }

        public ICollection<Usuario> GetUsuarios()
        {
            return _context.Usuarios.OrderBy(u => u.Id).ToList();
        }

        public Usuario GetUsuarioSenha(string senha)
        {
            return _context.Usuarios.Where(u => u.senha == senha).FirstOrDefault();
        }

        public bool UsuarioExists(int Id)
        {
            return _context.Usuarios.Any(u => u.Id == Id);
        }

        private bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}

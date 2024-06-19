using mooexpress.Models;

namespace mooexpress.Interfaces
{
    public interface IUsuarioRepository
    {
        ICollection<Usuario> GetUsuarios();
        Usuario GetUsuario(int id);
        Usuario GetUsuario(string nome);
        Usuario GetUsuarioCodigo(int codigo);
        Usuario GetUsuarioEmail(string email);
        Usuario GetUsuarioSenha(string senha);
        bool UsuarioExists(int Id);
        bool CreateUsuario(Usuario usuario);
    }
}

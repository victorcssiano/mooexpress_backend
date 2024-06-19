using mooexpress.Models;

namespace mooexpress.Interfaces
{
    public interface IAvaliacoesRepository
    {
        ICollection<Avaliacoes> GetAvaliacoes();
        Avaliacoes GetAvaliacoes(int id);
        Avaliacoes GetAvaliacao(int avaliacao);
        Avaliacoes GetAvaliacoesDescricao(string Descricao);
        bool AvaliacoesExists(int Id);
        //bool CreateUsuario(Usuario usuario);
    }
}

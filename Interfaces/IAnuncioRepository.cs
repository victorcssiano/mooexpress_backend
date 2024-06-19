using mooexpress.Models;

namespace mooexpress.Interfaces
{
    public interface IAnuncioRepository
    {
        ICollection<Anuncio> GetAnuncios();
        Anuncio GetAnuncio(int id);
        Anuncio GetAnuncioTitulo(string titulo);
        Anuncio GetAnuncioDescricao(string descricao);
        Anuncio GetAnuncioPreco(double preco);
        Anuncio GetAnuncioStatus(string status);
        Anuncio GetAnuncioPublicacao(DateTime publicacao);
        bool AnuncioExists(int Id);
    }
}

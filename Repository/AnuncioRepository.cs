using mooexpress.Data;
using mooexpress.Interfaces;
using mooexpress.Models;

namespace mooexpress.Repository
{
    public class AnuncioRepository : IAnuncioRepository
    {
        private readonly DataContext _context;

        public AnuncioRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Anuncio> GetAnuncios()
        {
            return _context.Anuncios.OrderBy(a => a.Id).ToList();
        }
        public bool AnuncioExists(int Id)
        {
            return _context.Anuncios.Any(a => a.Id == Id);
        }

        public Anuncio GetAnuncio(int id)
        {
            return _context.Anuncios.Where(a => a.Id == id).FirstOrDefault();
        }

        public Anuncio GetAnuncioDescricao(string descricao)
        {
            return _context.Anuncios.Where(a => a.Descricao == descricao).FirstOrDefault();
        }

        public Anuncio GetAnuncioPreco(double preco)
        {
            return _context.Anuncios.Where(a => a.Preco == preco).FirstOrDefault();
        }

        public Anuncio GetAnuncioPublicacao(DateTime publicacao)
        {
            return _context.Anuncios.Where(a => a.Publicacao == publicacao).FirstOrDefault();
        }

        public Anuncio GetAnuncioStatus(string status)
        {
            return _context.Anuncios.Where(a => a.Status == status).FirstOrDefault();
        }

        public Anuncio GetAnuncioTitulo(string titulo)
        {
            return _context.Anuncios.Where(a => a.Titulo == titulo).FirstOrDefault();
        }
    }
}

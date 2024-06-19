using mooexpress.Data;
using mooexpress.Interfaces;
using mooexpress.Models;

namespace mooexpress.Repository
{
    public class AvaliacoesRepository : IAvaliacoesRepository
    {
        private readonly DataContext _context;

        public AvaliacoesRepository(DataContext context)
        {
            _context = context;
        }

        public bool AvaliacoesExists(int Id)
        {
            return _context.Avaliacoes.Any(a => a.Id == Id);
        }

        public Avaliacoes GetAvaliacao(int avaliacao)
        {
            return _context.Avaliacoes.Where(a => a.Avaliacao == avaliacao).FirstOrDefault();
        }

        public ICollection<Avaliacoes> GetAvaliacoes()
        {
            return _context.Avaliacoes.OrderBy(a => a.Id).ToList();
        }

        public Avaliacoes GetAvaliacoes(int id)
        {
            return _context.Avaliacoes.Where(a => a.Id == id).FirstOrDefault();
        }

        public Avaliacoes GetAvaliacoesDescricao(string descricao)
        {
            return _context.Avaliacoes.Where(a => a.Descricao == descricao).FirstOrDefault();
        }
    }
}

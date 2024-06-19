using mooexpress.Data;
using mooexpress.Interfaces;
using mooexpress.Models;

namespace mooexpress.Repository
{
    public class GadoRepository : IGadoRepository
    {
        private readonly DataContext _context;

        public GadoRepository(DataContext context)
        {
            _context = context;
        }

        public bool GadoExists(int Id)
        {
            return _context.Gados.Any(g => g.Id == Id);
        }

        public Gado GetGado(int id)
        {
            return _context.Gados.Where(g => g.Id == id).FirstOrDefault();
        }

        public Gado GetGadoCor(string cor)
        {
            return _context.Gados.Where(g => g.Cor == cor).FirstOrDefault();
        }

        public Gado GetGadoIdade(int idade)
        {
            return _context.Gados.Where(g => g.Idade == idade).FirstOrDefault();
        }

        public Gado GetGadoPeso(int peso)
        {
            return _context.Gados.Where(g => g.Peso == peso).FirstOrDefault();
        }

        public Gado GetGadoRaca(string raca)
        {
            return _context.Gados.Where(g => g.Raca == raca).FirstOrDefault();
        }

        public ICollection<Gado> GetGados()
        {
            return _context.Gados.OrderBy(g => g.Id).ToList();
        }

        public Gado GetGadoSexo(char sexo)
        {
            return _context.Gados.Where(g => g.Sexo == sexo).FirstOrDefault();
        }
    }
}

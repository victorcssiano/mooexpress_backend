using mooexpress.Data;
using mooexpress.Interfaces;
using mooexpress.Models;

namespace mooexpress.Repository
{
    public class Endereco_entregaRepository : IEndereco_entregaRepository
    {
        private readonly DataContext _context;

        public Endereco_entregaRepository(DataContext context)
        {
            _context = context;
        }

        public bool EnderecoExists(int Id)
        {
            return _context.Endereco_Entregas.Any(e => e.Id == Id);
        }

        public Endereco_entrega GetEndereco(int id)
        {
            return _context.Endereco_Entregas.Where(e => e.Id == id).FirstOrDefault();
        }

        public Endereco_entrega GetEnderecoCep(int cep)
        {
            return _context.Endereco_Entregas.Where(e => e.Cep == cep).FirstOrDefault();
        }

        public Endereco_entrega GetEnderecoComplemento(string complemento)
        {
            return _context.Endereco_Entregas.Where(e => e.Complemento == complemento).FirstOrDefault();
        }

        public Endereco_entrega GetEnderecoNumero(int numero)
        {
            return _context.Endereco_Entregas.Where(e => e.Numero == numero).FirstOrDefault();
        }

        public Endereco_entrega GetEnderecoRua(string rua)
        {
            return _context.Endereco_Entregas.Where(e => e.Rua == rua).FirstOrDefault();
        }

        public ICollection<Endereco_entrega> GetEnderecos()
        {
            return _context.Endereco_Entregas.OrderBy(e => e.Id).ToList();
        }
    }
}

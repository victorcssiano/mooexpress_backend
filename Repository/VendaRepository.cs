using mooexpress.Data;
using mooexpress.Interfaces;
using mooexpress.Models;

namespace mooexpress.Repository
{
    public class VendaRepository : IVendaRepository
    {
        private readonly DataContext _context;

        public VendaRepository(DataContext context)
        {
            _context = context;
        }

        public Venda GetVenda(int id)
        {
            return _context.Vendas.Where(v => v.Id == id).FirstOrDefault();
        }

        public Venda GetVendaForma_pagamento(string forma_pagamento)
        {
            return _context.Vendas.Where(v => v.Forma_pagamento == forma_pagamento).FirstOrDefault();
        }

        public ICollection<Venda> GetVendas()
        {
            return _context.Vendas.OrderBy(v => v.Id).ToList();
        }

        public bool VendaExists(int Id)
        {
            return _context.Vendas.Any(v => v.Id == Id);
        }
    }
}

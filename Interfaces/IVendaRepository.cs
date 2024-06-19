using mooexpress.Models;

namespace mooexpress.Interfaces
{
    public interface IVendaRepository
    {
        ICollection<Venda> GetVendas();
        Venda GetVenda(int id);
        Venda GetVendaForma_pagamento(string forma_pagamento);
        bool VendaExists(int Id);
    }
}

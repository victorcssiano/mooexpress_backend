using mooexpress.Models;

namespace mooexpress.Interfaces
{
    public interface IEndereco_entregaRepository
    {
        ICollection<Endereco_entrega> GetEnderecos();
        Endereco_entrega GetEndereco(int id);
        Endereco_entrega GetEnderecoRua(string rua);
        Endereco_entrega GetEnderecoNumero(int numero);
        Endereco_entrega GetEnderecoComplemento(string complemento);
        Endereco_entrega GetEnderecoCep(int cep);
        bool EnderecoExists(int Id);
    }
}

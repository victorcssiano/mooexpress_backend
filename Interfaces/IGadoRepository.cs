using mooexpress.Models;

namespace mooexpress.Interfaces
{
    public interface IGadoRepository
    {
        ICollection<Gado> GetGados();
        Gado GetGado(int id);
        Gado GetGadoRaca(string raca);
        Gado GetGadoIdade(int idade);
        Gado GetGadoSexo(char sexo);
        Gado GetGadoPeso(int peso);
        Gado GetGadoCor(string cor);
        bool GadoExists(int Id);
    }
}

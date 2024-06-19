namespace mooexpress.Models
{
    public class Endereco_entrega
    {
        public int Id { get; set; }
        public string Rua { get; set;}
        public int Numero { get; set;}
        public string? Complemento { get; set; }
        public int Cep { get; set; }
        public int VendaId { get; set; }
        public Venda Venda { get; set; }
    }
}

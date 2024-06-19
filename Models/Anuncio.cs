namespace mooexpress.Models
{
    public class Anuncio
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public double Preco { get; set; }
        public string Status { get; set;}
        public DateTime Publicacao { get; set; }

        // Foreign Key for Usuario
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        // Foreign Key for Venda
        public int VendaId { get; set; }
        public Venda Venda { get; set; }

        // Foreign Key for Gado
        public int GadoId { get; set; }
        public Gado Gado { get; set; }
    }
}

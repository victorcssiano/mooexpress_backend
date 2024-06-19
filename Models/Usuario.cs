namespace mooexpress.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public int codigo { get; set; }
        public string Email { get; set; }
        public string senha { get; set; }
        public string Nome { get; set; }
        public ICollection<Anuncio> Anuncios { get; set; }
        public ICollection<Avaliacoes> Avaliacoes { get; set; }
    }
}

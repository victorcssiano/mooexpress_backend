namespace mooexpress.Models
{
    public class Avaliacoes
    {
        public int Id { get; set; }
        public int Avaliacao { get; set; }
        public string? Descricao { get; set; }
        public Usuario Usuario { get; set; }
    }
}

namespace mooexpress.Models
{
    public class Gado
    {
        public int Id { get; set; }
        public string Raca { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
        public int Peso { get; set; }
        public string Cor { get; set; }

        public Anuncio Anuncio { get; set; }
    }
}

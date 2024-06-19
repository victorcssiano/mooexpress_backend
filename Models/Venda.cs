namespace mooexpress.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public string Forma_pagamento { get; set; }

        public int AnuncioId { get; set; }
        public Anuncio Anuncio { get; set; }

        public int? Endereco_EntregaId { get; set; }
        public Endereco_entrega Endereco_Entrega { get; set; }
    }
}

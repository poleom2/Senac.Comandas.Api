namespace Comanda.Api.DTOs
{
    public class CardapioItemCreateRequest
    {
        
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public bool PossuiPreparo { get; set; }
        public string Imagem { get; set; }
        public string Tipo { get; set; }
    }
}

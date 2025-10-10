namespace Comanda.Api.DTOs
{
    public class ComandaCreateResquest
    {
        public int NumeroMesa { get; set; }
        public string NomeCliente { get; set; } 
        public int[] CardapioItemds { get; set; } = default!;
    }
}

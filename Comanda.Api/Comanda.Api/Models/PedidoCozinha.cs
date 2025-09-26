namespace Comanda.Api.Models
{
    public class PedidoCozinha
    {
        public int id { get; set; }
        public int ComandaId { get; set; }
        public List<PedidoCozinhaItem> items { get; set; } = [];
    }
}
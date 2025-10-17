using Comanda.Api.Models;

namespace Comanda.Api.DTOs
{
    public class PedidocozinhaCreateRequest
    {
        public int id { get; set; }
        public int ComandaId { get; set; }
        public List<PedidoCozinhaItemCreateRequest> items { get; set; } = [];
    }
    public class PedidoCozinhaItemCreateRequest
    {
        public int id { get; set; }
        public int ComandaItemId { get; set; }
        public int PedidoCozinhaid { get; set; }
    }
}

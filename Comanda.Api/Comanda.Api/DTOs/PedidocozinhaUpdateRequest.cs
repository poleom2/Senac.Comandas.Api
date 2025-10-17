using Comanda.Api.Models;

namespace Comanda.Api.DTOs
{
    public class PedidocozinhaUpdateRequest
    {
        public int id { get; set; }
        public int ComandaId { get; set; }
        public List<PedidoCozinhaItemCreateRequest> items { get; set; } = [];
    }
  
}

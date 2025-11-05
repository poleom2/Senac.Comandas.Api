using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comanda.Api.Models
{
    public class PedidoCozinha
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int ComandaId { get; set; }
        public virtual Comanda Comanda { get; set; }
        public List<PedidoCozinhaItem> items { get; set; } = [];
    }
}
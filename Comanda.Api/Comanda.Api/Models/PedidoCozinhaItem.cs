using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Comanda.Api.Models;

public class PedidoCozinhaItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } 
    public int PedidoCozinhaId { get; set; }//FK
    public virtual PedidoCozinha PedidoCozinha { get; set; }//Navegação
    public int ComandaItemId { get; set; }// FK
    public virtual ComandaItem ComandaItem { get; set; }//Navegação

}

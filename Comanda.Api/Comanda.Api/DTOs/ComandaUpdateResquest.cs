namespace Comanda.Api.DTOs
{
    public class ComandaUpdateResquest
    {
        public int NumeroMesa { get; set; }= default;
        public string NomeCliente { get; set; }
        public ComandaItemUpdateResquest[] Itens { get; set; } = [];
    }

    public class ComandaItemUpdateResquest
    {
        public int Id { get; set; }
        public bool Remuve { get; set; }
        public int CardapioItemId { get; set; }
    }
}

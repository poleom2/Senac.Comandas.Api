namespace Comanda.Api.DTOs
{
    public class comandaCrestrResponse
    {   
        public int id { get; set; }
        public int NumeroMesa { get; set; }
        public string NomeCliente { get; set; }
        public List<ComandaItemResponse> Itens { get; set; } = new List<ComandaItemResponse> ();
    }
    public class ComandaItemResponse
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
    }
}

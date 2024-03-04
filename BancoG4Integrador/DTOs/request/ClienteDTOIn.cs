namespace DTOs.request
{
    public class ClienteDTOIn
    {
        public int Id { get; set; }

        public string? RazonSocial { get; set; }

        public int Cuil { get; set; }

        public DateOnly Alta { get; set; }
        public int DireccionId { get; set; }
    }
}

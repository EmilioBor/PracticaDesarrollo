namespace DTOs.response
{
    public class ClienteDTOOut
    {
        //public int Id { get; set; }

        public string? RazonSocial { get; set; }
        public int Cuil { get; set; }
        public DateOnly? Alta { get; set; }
        public int DireccionId { get; set; }
    }
}

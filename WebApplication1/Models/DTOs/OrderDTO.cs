namespace WebApplication1.Models.DTOs
{
    public class OrderDTO
    {

        public int ID { get; set; }
        public DateTime AcceptedAt { get; set; }    
        public DateTime? FulfilledAt { get; set; }    
        public string? Comments { get; set; }

        public ICollection<PastryDTO> Pastries { get; set; } = null!;
    }
}

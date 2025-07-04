using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Models
{
    public class Show
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;
        
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        public DateTime DateTime { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Venue { get; set; } = string.Empty;
        
        [Required]
        [Range(0.01, 10000.00)]
        public decimal Price { get; set; }
        
        [Required]
        [Range(1, 10000)]
        public int TotalTickets { get; set; }
        
        public int AvailableTickets { get; set; }
        
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
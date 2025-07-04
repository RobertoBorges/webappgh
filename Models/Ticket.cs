using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TicketSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        
        [Required]
        public int ShowId { get; set; }
        public virtual Show Show { get; set; } = null!;
        
        [Required]
        public string UserId { get; set; } = string.Empty;
        public virtual IdentityUser User { get; set; } = null!;
        
        [Required]
        public DateTime PurchaseDate { get; set; }
        
        [Required]
        [Range(0.01, 10000.00)]
        public decimal PricePaid { get; set; }
        
        [StringLength(50)]
        public string SeatNumber { get; set; } = string.Empty;
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Sale
{
    [Key]public int IdSale { get; set; }
    public int IdClient { get; set; }
    [ForeignKey(nameof(IdClient))] public Client Client { get; set; } = null!;
    
    public int IdSubscription { get; set; }
    [ForeignKey(nameof(IdClient))] public Subscription Subscription { get; set; } = null!;
    
    [Required] public DateTime CreatedAt { get; set; }

}
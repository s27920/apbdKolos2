using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Payment
{
    [Key] public int IdPayment { get; set; }
    [Required] private DateTime Date { get; set; }
    public int IdClient { get; set; }
    [ForeignKey(nameof(IdClient))] private Client Client { get; set; } = null!;
    
    public int IdSubscription { get; set; }
    [ForeignKey(nameof(IdSubscription))] private Subscription Subscription { get; set; } = null!;

}
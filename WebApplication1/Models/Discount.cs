using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Discount
{
    [Key] public int IdDiscount { get; set; }
    [Required] public int Value { get; set; }
    public int IdSubscription { get; set; }
    [ForeignKey(nameof(IdSubscription))] private Subscription Subscription { get; set; } = null!;

    [Required] public DateTime DateFrom { get; set; }
    [Required] public DateTime DateTo { get; set; }
}
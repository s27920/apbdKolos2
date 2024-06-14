using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Discount
{
    [Key] public int IdDiscount { get; set; }
    [Required] public int Value { get; set; }
    public int IdSubscription { get; set; }
}
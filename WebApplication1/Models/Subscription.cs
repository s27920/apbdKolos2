using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Subscription
{
    [Key] public int IdSubscription { get; set; }
    [Required][MaxLength(100)] public string Name { get; set; } = null!;
    [Required] public int RenewalPeriod { get; set; }
    [Required] public DateTime EndTime { get; set; }
    [Required] public double Price { get; set; }
    public ICollection<Sale>? Sales = new List<Sale>();

}
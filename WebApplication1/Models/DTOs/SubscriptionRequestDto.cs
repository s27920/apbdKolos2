using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs;

public class SubscriptionRequestDto
{
    [Required] public int IdClient { get; set; }
    [Required] public int IdSubscription { get; set; }
    [Required] public Payment Payment = null!;
}
namespace WebApplication1.Models.DTOs;

public class ClientResponseDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!; 
    public string Phone { get; set; } = null!;
    public ICollection<Subscription> Subscriptions = null!;

}
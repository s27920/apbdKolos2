using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Client
{
    [Key] public int IdCient { get; set; }
    [Required] [MaxLength] public string FirstName { get; set; } = null!;
    [Required] [MaxLength] public string LastName { get; set; } = null!;
    [Required] [MaxLength] public string Email { get; set; } = null!; 
    [MaxLength] public string Phone { get; set; } = null!;
    public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
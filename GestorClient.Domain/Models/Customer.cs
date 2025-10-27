using System.ComponentModel.DataAnnotations;

namespace GestorClient.Domain.Models;

public class Customer
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public List<Order> Orders { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace GestorClient.Domain.Models;

public class Order
{
    public int Id { get; set; }

    [Required]
    public int CustomerId { get; set; }

    public DateTime OrderDate { get; set; } = DateTime.Now;

    [Required]
    public string Status { get; set; }

    public Customer Customer { get; set; }

    public List<OrderDetail> OrderDetails { get; set; }
}
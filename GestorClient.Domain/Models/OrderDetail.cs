using System.ComponentModel.DataAnnotations;

namespace GestorClient.Domain.Models;

public class OrderDetail
{
    public int Id { get; set; }

    [Required]
    public int OrderId { get; set; }

    [Required]
    public string ProductName { get; set; }

    public int Quantity { get; set; }

    public double UnitPrice { get; set; }

    public Order Order { get; set; }
}


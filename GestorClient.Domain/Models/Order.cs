namespace GestorClient.Domain.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = "Pendiente";

    //Llave foránea hacia Customer
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
}
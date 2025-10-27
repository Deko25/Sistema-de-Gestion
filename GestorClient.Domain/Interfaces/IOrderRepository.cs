using GestorClient.Domain.Models;

namespace GestorClient.Domain.Interfaces;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAll();
    Task<Order?> GetById(int id);
    Task Add(Order order);
    Task Update(Order order);
    Task Delete(int id);
    Task SaveChanges();
}
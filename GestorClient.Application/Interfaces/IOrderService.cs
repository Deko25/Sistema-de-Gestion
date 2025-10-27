using GestorClient.Domain.Models;

namespace GestionCustomers.Application.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(int id);
    Task<Order> CreateAsync(Order order);
    Task<bool> UpdateAsync(int id, Order order);
    Task<bool> DeleteAsync(int id);
}
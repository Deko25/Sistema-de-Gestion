using GestionCustomers.Application.Interfaces;
using GestorClient.Domain.Interfaces;
using GestorClient.Domain.Models;

namespace GestionCustomers.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepo;
    private readonly ICustomerRepository _customerRepo;

    public OrderService(IOrderRepository orderRepo, ICustomerRepository customerRepo)
    {
        _orderRepo = orderRepo;
        _customerRepo = customerRepo;
    }

    public async Task<IEnumerable<Order>> GetAllAsync() =>
        await _orderRepo.GetAll();

    public async Task<Order?> GetByIdAsync(int id) =>
        await _orderRepo.GetById(id);

    public async Task<Order> CreateAsync(Order order)
    {
        // Validar cliente existente antes de crear pedido
        var customer = await _customerRepo.GetById(order.CustomerId);
        if (customer == null)
            throw new Exception("No existe un cliente con ese ID.");

        order.OrderDate = DateTime.Now;
        order.Status = string.IsNullOrEmpty(order.Status) ? "Pendiente" : order.Status;

        await _orderRepo.Add(order);
        await _orderRepo.SaveChanges();
        return order;
    }

    public async Task<bool> UpdateAsync(int id, Order update)
    {
        var existing = await _orderRepo.GetById(id);
        if (existing == null) return false;

        existing.Status = update.Status;
        existing.OrderDate = update.OrderDate;
        existing.CustomerId = update.CustomerId;

        await _orderRepo.Update(existing);
        await _orderRepo.SaveChanges();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _orderRepo.GetById(id);
        if (existing == null) return false;

        await _orderRepo.Delete(id);
        await _orderRepo.SaveChanges();
        return true;
    }
}

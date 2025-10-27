using GestionCustomers.Application.Interfaces;
using GestorClient.Domain.Interfaces;
using GestorClient.Domain.Models;

namespace GestorClient.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync() =>
        await _repository.GetAll();

    public async Task<Customer?> GetByIdAsync(int id) =>
        await _repository.GetById(id);

    public async Task<Customer> CreateAsync(Customer customer)
    {
        if (string.IsNullOrWhiteSpace(customer.Name))
            throw new ArgumentException("El nombre es obligatorio");

        await _repository.Add(customer);
        await _repository.SaveChanges();
        return customer;
    }

    public async Task<bool> UpdateAsync(int id, Customer update)
    {
        var existing = await _repository.GetById(id);
        if (existing == null) return false;

        existing.Name = update.Name;
        existing.Email = update.Email;

        await _repository.Update(existing);
        await _repository.SaveChanges();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _repository.GetById(id);
        if (existing == null) return false;

        await _repository.Delete(id);
        await _repository.SaveChanges();
        return true;
    }
}

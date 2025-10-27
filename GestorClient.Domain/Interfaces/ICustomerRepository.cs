using GestorClient.Domain.Models;

namespace GestorClient.Domain.Interfaces;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAll();
    Task<Customer?> GetById(int id);
    Task Add(Customer customer);
    Task Update(Customer customer);
    Task Delete(int id);
    Task SaveChanges();
}
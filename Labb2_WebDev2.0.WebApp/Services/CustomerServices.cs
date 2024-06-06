using Labb2_WebDev2.Shared.DTOs;
using Labb2_WebDev2.Shared.Interfaces;

namespace Labb2_WebDev2.WebApp.Services;

public class CustomerServices : ICustomerService<CustomerDTO>
{
    public Task<IEnumerable<CustomerDTO>> GetAllCustomers()
    {
        throw new NotImplementedException();
    }

    public Task<CustomerDTO?> GetCustomerById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<CustomerDTO?> GetCustomerByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCustomer(int id, string newFirstname, string newLastname, string newAddress, string newEmail,
        string newPhone)
    {
        throw new NotImplementedException();
    }

    public Task AddCustomer(CustomerDTO newCustomer)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCustomer(int id)
    {
        throw new NotImplementedException();
    }
}
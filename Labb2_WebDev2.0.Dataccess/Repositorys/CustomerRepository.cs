using Labb2_WebDev2._0.Dataccess.Entities;
using Labb2_WebDev2._0.Shared.DTOs;
using Labb2_WebDev2._0.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Labb2_WebDev2._0.Dataccess.Repositorys;

public class CustomerRepository(HandmadeDbContext context) : ICustomerService<Customer>
{
    public async Task<IEnumerable<Customer>> GetAllCustomers()
    {
        return context.Customers;
    }

    public async Task<Customer?> GetCustomerById(int id)
    {
        var customer = await context.Customers.FindAsync(id);
        if (customer == null)
        {
            Console.WriteLine($"Customer with ID: {id} was not found");
            return null;
        }
        return customer;
    }

    public async Task<Customer?> GetCustomerByEmail(string email)
    {
        var customer = await context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        if (customer == null)
        {
            Console.WriteLine($"Customer with email: {email} was not found");
            return null;
        }
        return customer;
    }

    public async Task UpdateCustomer(CustomerDTO updateCustomer)
    {
        var customer = await context.Customers.FindAsync(updateCustomer.CustomerID);
        if (customer == null)
        {
            Console.WriteLine($"Customer with ID: {updateCustomer.CustomerID} was not found");
            return;
        }
        customer.Firstname = updateCustomer.Firstname;
        customer.Lastname = updateCustomer.Lastname;
        customer.Address = updateCustomer.Address;
        customer.Email = updateCustomer.Email;
        customer.Phone = updateCustomer.Phone;
        await context.SaveChangesAsync();
    }

    public async Task AddCustomer(Customer newCustomer)
    {
        await context.Customers.AddAsync(newCustomer);
        await context.SaveChangesAsync();
    }

    public async Task DeleteCustomer(int id)
    {
        var removeCustomer = await context.Customers.FindAsync(id);
        if (removeCustomer is null)
        {
            Console.WriteLine($"Customer with id: {id} was not found");
            return;
        }
        context.Customers.Remove(removeCustomer);
        await context.SaveChangesAsync();
    }
}
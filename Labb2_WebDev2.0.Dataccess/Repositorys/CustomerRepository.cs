﻿using Labb2_WebDev2._0.Dataccess.Entities;
using Labb2_WebDev2._0.Shared.Interfaces;

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
        var customer = await context.Customers.FindAsync(email);
        if (customer == null)
        {
            Console.WriteLine($"Customer with email: {email} was not found");
            return null;
        }
        return customer;
    }

    public async Task UpdateCustomer(int id, string newFirstname, string newLastname, string newAddress, string newEmail, string newPhone)
    {
        var customer = await context.Customers.FindAsync(id);
        if (customer == null)
        {
            Console.WriteLine($"Customer with ID: {id} was not found");
            return;
        }
        customer.Firstname = newFirstname;
        customer.Lastname = newLastname;
        customer.Address = newAddress;
        customer.Email = newEmail;
        customer.Phone = newPhone;
        await context.SaveChangesAsync();
    }

    public async Task AddCustomer(Customer newCustomer)
    {
        await context.Customers.AddAsync(newCustomer);
        await context.SaveChangesAsync();
    }

    public async Task DeleteCustomer(int id)
    {
        await DeleteCustomer(id);
        await context.SaveChangesAsync();
    }
}
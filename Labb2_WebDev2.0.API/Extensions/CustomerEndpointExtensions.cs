using Labb2_WebDev2._0.Dataccess.Entities;
using Labb2_WebDev2._0.Dataccess.Repositorys;
using Labb2_WebDev2._0.Shared.DTOs;

namespace Labb2_WebDev2._0.API.Extensions;

public static class CustomerEndpointExtensions
{
    public static IEndpointRouteBuilder MapCustomerEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/customers", async (CustomerRepository repo) =>
        {
            var allCustomers = await repo.GetAllCustomers();
            if (allCustomers == null)
            {
                return Results.BadRequest("No customers found");
            }
            return Results.Ok(allCustomers);
        });

        app.MapGet("/customers/{id}", async (CustomerRepository repo, int id) =>
        {
            var customer = await repo.GetCustomerById(id);
            if (customer is null)
            {
                return Results.NotFound($"Customer with ID {id} was not found");
            }

            return Results.Ok(customer);
        });

        app.MapGet("/customers/search/{email}", async (CustomerRepository repo, string email) =>
        {
            var customer = await repo.GetCustomerByEmail(email);
            if (customer is null)
            {
                return Results.NotFound($"Customer with email {email} was not found");
            }

            return Results.Ok(customer);
        });

        app.MapPut("/customers", async (CustomerRepository repo, Customer newCustomer) =>
        {
            repo.AddCustomer(newCustomer);
        });

        app.MapPatch("/customers/{id}", async (CustomerRepository repo, int customerID, CustomerDTO updateCustomer) =>
        {
            await repo.UpdateCustomer(customerID, updateCustomer);
        });

        app.MapDelete("/customers/{id}", async (CustomerRepository repo, int id) =>
        {
            var excistingCustomer = await repo.GetCustomerById(id);
            if (excistingCustomer is null)
            {
                return Results.BadRequest($"Customer with id {id} does not excists");
            }
            await repo.DeleteCustomer(id);
            return Results.Ok("Customer has been deleted");
        });

        return app;
    }
}
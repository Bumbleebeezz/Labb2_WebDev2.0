namespace Labb2_WebDev2._0.Shared.Interfaces;

public interface ICustomerService<T> where T : class
{
    Task<IEnumerable<T>> GetAllCustomers();
    Task<T?> GetCustomerById(int id);
    Task<T?> GetCustomerByEmail(string email);
    Task UpdateCustomer(int id, string newFirstname, string newLastname, string newAddress, string newEmail, string newPhone);
    Task AddCustomer(T newCustomer);
    Task DeleteCustomer(int id);
}
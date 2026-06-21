using System;

namespace Ex11_DependencyInjection
{
    // The Service Class
    public class CustomerService
    {
        private readonly ICustomerRepository _repository;

        // Constructor Injection
        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public void DisplayCustomerInfo(int id)
        {
            string customerInfo = _repository.FindCustomerById(id);
            Console.WriteLine(customerInfo);
        }
    }
}

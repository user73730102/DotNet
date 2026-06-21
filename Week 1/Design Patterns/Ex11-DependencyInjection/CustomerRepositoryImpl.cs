namespace Ex11_DependencyInjection
{
    // The Concrete Repository
    public class CustomerRepositoryImpl : ICustomerRepository
    {
        public string FindCustomerById(int id)
        {
            // Simulate database lookup
            return $"Customer with ID {id} (Fetched from Database)";
        }
    }
}

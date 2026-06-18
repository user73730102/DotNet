namespace Ex11_DependencyInjection
{
    // The Repository Interface
    public interface ICustomerRepository
    {
        string FindCustomerById(int id);
    }
}

namespace TestTask.Core.Repositories
{

    public interface IBaseDbConfiguration
    {
        string ConnectionString { get; set; }
    }

    public interface ICustomerDbConfiguration : IBaseDbConfiguration
    {
     
    }
}
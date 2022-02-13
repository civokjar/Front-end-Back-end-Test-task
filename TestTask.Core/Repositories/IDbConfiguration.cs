namespace TestTask.Core.Repositories
{
    public class CustomerDbConfiguration : ICustomerDbConfiguration
    {
        public CustomerDbConfiguration(string connectionString) {
            ConnectionString = connectionString;
        }
        public string ConnectionString { get; set; }
   
    }
    public interface IDbConfiguration
    {
        string ConnectionString { get; set; }
    }
    public interface ICustomerDbConfiguration : IDbConfiguration
    {
     
    }
    
    
}
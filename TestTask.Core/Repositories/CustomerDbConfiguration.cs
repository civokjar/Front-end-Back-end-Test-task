namespace TestTask.Core.Repositories
{
    public class CustomerDbConfiguration : ICustomerDbConfiguration
    {
        public CustomerDbConfiguration(string connectionString) {
            ConnectionString = connectionString;
        }
        public string ConnectionString { get; set; }

    }

}
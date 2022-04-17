using Microsoft.Extensions.Configuration;
using TestTask.Core.Model;
using TestTask.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Core.Repositories
{
    public class CustomerRepository: BaseRepository, ICustomerRepository
    {
        public CustomerRepository(ICustomerDbConfiguration configuration) : base(configuration)
        {
            
        }

        public async Task<Customer> Create(string name, string ssn)
        {
            return await
                  QueryFirstOrDefaultAsync<Customer>(@"
                        DECLARE @insertedId TABLE
                        (Id uniqueidentifier)
                        insert into Customers(name, SSN)
                        OUTPUT inserted.Id
                        INTO @insertedId
                        values(@name, @SocialSecurityNumber)
                        select Id as Id, @name as name, @SocialSecurityNumber as ssn from @insertedId
                    ", new { name, SocialSecurityNumber = ssn }).ConfigureAwait(false);

        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await QueryAsync<Customer>(@"SELECT Id, name, ssn FROM Customers
                                                        ", new { }).ConfigureAwait(false);
        }
    }
}

using TestTask.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Core.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> Create(string name, string ssn);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrigoTestTask.Services.Models
{
    public class CustomerSearchResponse
    {

        public IEnumerable<Customer> Customers { get; set; }
        public List<string> ErrorMessages { get; set; }

    }
    
}

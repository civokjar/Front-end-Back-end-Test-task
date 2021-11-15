using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrigoTestTask.API.Model
{
    public class CustomerSearchResponse : BaseResponse {

        public IEnumerable<CustomerData> Customers { get; set; }

    }
    public class CustomerResponse : BaseResponse
    {
        public CustomerData Customer { get; set; }
    }
    public class CustomerData
    {
        public string Name { get; set; }
        public string SocialSecurityNumber { get; set; }
    }
}

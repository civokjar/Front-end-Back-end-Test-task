using System.Collections.Generic;

namespace TestTask.API.Model
{
    public class CustomerSearchResponse : BaseResponse {

        public IEnumerable<Customer> Customers { get; set; }

    }
}

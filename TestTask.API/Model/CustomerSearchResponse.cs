using System.Collections.Generic;

namespace TestTask.API.Model
{
    public class CustomerSearchResponse : BaseResponse {

        public IEnumerable<CustomerData> Customers { get; set; }

    }
}

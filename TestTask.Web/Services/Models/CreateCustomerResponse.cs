using System.Collections.Generic;

namespace TestTask.Services.Models
{
    public class CreateCustomerResponse
    {

        public Customer Customer { get; set; }
        public List<string> ErrorMessages { get; set; }

    }

}

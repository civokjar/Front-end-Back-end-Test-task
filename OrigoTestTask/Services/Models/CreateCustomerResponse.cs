using System.Collections.Generic;

namespace OrigoTestTask.Services.Models
{
    public class CreateCustomerResponse
    {

        public Customer Customer { get; set; }
        public List<string> ErrorMessages { get; set; }

    }

}

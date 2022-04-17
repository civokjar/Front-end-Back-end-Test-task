using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.API.Model
{
    public class CreateCustomerResponse : BaseResponse
    {
        public Customer Customer { get; set; }
 
        public string ErrorMessage { get; set; }
    }
}

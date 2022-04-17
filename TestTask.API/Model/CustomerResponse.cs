using System;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.API.Model
{
    public class CustomerResponse : BaseResponse
    {
        public CustomerData Customer { get; set; }
    }
}

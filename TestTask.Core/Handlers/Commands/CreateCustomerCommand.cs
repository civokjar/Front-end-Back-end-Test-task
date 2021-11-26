using MediatR;
using TestTask.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Core.Handlers
{
    public class CreateCustomerCommand : IRequest<Customer>
    {
        public string Name { get; set; }
        public string SocialSecurityNumber { get; set; }
    }
}

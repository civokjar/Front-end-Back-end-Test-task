using MediatR;
using OrigoTestTask.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrigoTestTask.Core.Handlers
{
    public class GetCustomersQuery : IRequest<IEnumerable<Customer>>
    {
    }
}

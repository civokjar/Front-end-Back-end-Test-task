using MediatR;
using TestTask.Core.Model;
using TestTask.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestTask.Core.Handlers
{
    public partial class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IEnumerable<Customer>>
    {

        private readonly ICustomerRepository _repository;

        public GetCustomersQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;

        }

        public async Task<IEnumerable<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {

            return await _repository.GetAll();
        }
    }
}

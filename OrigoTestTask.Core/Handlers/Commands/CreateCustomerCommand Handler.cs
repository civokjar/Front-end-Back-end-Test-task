using MediatR;
using OrigoTestTask.Core.Model;
using OrigoTestTask.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrigoTestTask.Core.Handlers
{
    public partial class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
       
        private readonly ICustomerRepository _repository;

        public CreateCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;

        }

        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {

            return await _repository.Create(request.Name, request.SocialSecurityNumber);
        }
    }
  

}

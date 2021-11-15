using AutoMapper;
using OrigoTestTask.API.Model;
using OrigoTestTask.Core.Handlers;
using OrigoTestTask.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrigoTestTask.API.Mappers
{
    public class CustomerApiProfile : Profile
    {

        public CustomerApiProfile()
        {
            CreateMap<CreateCustomerRequest, CreateCustomerCommand>();

            CreateMap<Customer, CustomerResponse>();
            CreateMap<Customer, CustomerData>();
        }
    }
}

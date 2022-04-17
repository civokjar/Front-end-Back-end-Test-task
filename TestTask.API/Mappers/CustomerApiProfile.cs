using AutoMapper;
using TestTask.API.Model;
using TestTask.Core.Handlers;
using TestTask.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.API.Mappers
{
    public class CustomerApiProfile : Profile
    {

        public CustomerApiProfile()
        {
            CreateMap<CreateCustomerRequest, CreateCustomerCommand>();

            CreateMap<Core.Model.Customer, CreateCustomerResponse>();
            CreateMap<Core.Model.Customer, Model.Customer>();
        }
    }
}

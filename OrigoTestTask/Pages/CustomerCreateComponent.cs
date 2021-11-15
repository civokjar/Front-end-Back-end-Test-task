using Microsoft.AspNetCore.Components;
using OrigoTestTask.Services;
using OrigoTestTask.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrigoTestTask.Pages
{
    public class CustomerCreateComponent : ComponentBase
    {
        //[CascadingParameter]
        //EditContext CurrentEditContext { get; set; }
        public CustomerCreateViewModel customerCreateViewModel { get; set; }
        [Inject]
        protected IOrigoTestTaskApi _origoTestTaskApi { get; set; }

        protected override async Task OnInitializedAsync()
        {
            customerCreateViewModel = new CustomerCreateViewModel();

       
            await base.OnInitializedAsync();
        }
        public async Task CreateCustomer()
        {
            var request = new CreateCustomerRequest { Name = customerCreateViewModel.Name?.Trim(), SocialSecurityNumber = customerCreateViewModel.SocialSecurityNumber?.Trim() };
            var response = await _origoTestTaskApi.Create(request).ConfigureAwait(false);

            customerCreateViewModel = new CustomerCreateViewModel();
          
            if (response != null)
            {
                customerCreateViewModel.IsCreated = true;
                if (response.ErrorMessages != null) {
                    customerCreateViewModel.IsCreated = false;
                    customerCreateViewModel.ErrorMessages = response.ErrorMessages;


                }
                else
                {
                    customerCreateViewModel.Name = string.Empty;
                    customerCreateViewModel.SocialSecurityNumber = string.Empty;

                }
            }

        }

        public class CustomerCreateViewModel : Customer
        {
            public bool IsCreated { get; set; }
            public List<string> ErrorMessages { get; set; }
           
        }
     


    }
}

using Microsoft.AspNetCore.Components;
using TestTask.Services;
using TestTask.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Web.ViewModels;

namespace TestTask.Web.Pages
{
    public class CustomerCreateComponent : ComponentBase
    {
        //[CascadingParameter]
        //EditContext CurrentEditContext { get; set; }
        public CustomerCreateViewModel customerCreateViewModel { get; set; }
        [Inject]
        protected ITestTaskApi _TestTaskApi { get; set; }

        protected override async Task OnInitializedAsync()
        {
            customerCreateViewModel = new CustomerCreateViewModel();

       
            await base.OnInitializedAsync();
        }
        public async Task CreateCustomer()
        {
            var request = new CreateCustomerRequest { Name = customerCreateViewModel.Name?.Trim(), SocialSecurityNumber = customerCreateViewModel.SocialSecurityNumber?.Trim() };
            var response = await _TestTaskApi.Create(request).ConfigureAwait(false);

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

       
     


    }
}

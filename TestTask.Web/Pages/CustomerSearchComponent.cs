using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using TestTask.Services;
using TestTask.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestTask.Web.Pages
{
    public class CustomerSearchComponent : ComponentBase
    {
        //[CascadingParameter]
        //EditContext CurrentEditContext { get; set; }
        public CustomerSearchViewModel customerSearchViewModel { get; set; }
        [Inject]
        protected ITestTaskApi _TestTaskApi { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var response = await _TestTaskApi.GetAll().ConfigureAwait(false);
           
            customerSearchViewModel = new CustomerSearchViewModel();
            customerSearchViewModel.Customers = response?.Customers;
            customerSearchViewModel.ErrorMessages = response?.ErrorMessages;
            //if (this.CurrentEditContext == null)
            //{
            //    throw new InvalidOperationException($"{nameof(CustomerSearchComponent)} requires a cascading " +
            //        $"parameter of type {nameof(EditContext)}. For example, you can use {nameof(CustomerSearchComponent)} " +
            //        $"inside an EditForm.");
            //}
            await base.OnInitializedAsync();
        }
        public async Task FetchCustomers() {

            customerSearchViewModel = null;
            var response = await _TestTaskApi.GetAll().ConfigureAwait(false);

            customerSearchViewModel = new CustomerSearchViewModel();
            customerSearchViewModel.Customers = 
            response?.Customers;
            customerSearchViewModel.ErrorMessages = response?.ErrorMessages;

        }

        public class CustomerSearchViewModel : CustomerSearchResponse, INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
   
        //public async void Validate(HttpResponseMessage response, object model)
        //{
        //    var messages = new ValidationMessageStore(this.CurrentEditContext);

        //    if (response.StatusCode == HttpStatusCode.BadRequest)
        //    {
        //        var body = await response.Content.ReadAsStringAsync();
        //        var validationProblemDetails = JsonSerializer.Deserialize<ValidationProblemDetails>(body);

        //        if (validationProblemDetails.Errors != null)
        //        {
        //            messages.Clear();

        //            foreach (var error in validationProblemDetails.Errors)
        //            {
        //                var fieldIdentifier = new FieldIdentifier(model, error.Key);
        //                messages.Add(fieldIdentifier, error.Value);
        //            }
        //        }
        //    }

        //    CurrentEditContext.NotifyValidationStateChanged();
        //}

        public void Attach(RenderHandle renderHandle)
        {
            throw new NotImplementedException();
        }

        public Task SetParametersAsync(ParameterView parameters)
        {
            throw new NotImplementedException();
        }

        private class ValidationProblemDetails
        {
            [JsonPropertyName("status")]
            public int? Status { get; set; }

            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("type")]
            public string Type { get; set; }

            [JsonPropertyName("errors")]
            public IDictionary<string, string[]> Errors { get; set; }
        }


    }
}

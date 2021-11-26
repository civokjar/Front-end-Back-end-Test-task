using TestTask.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Web.ViewModels
{
    public class CustomerCreateViewModel : Customer
    {
        public bool IsCreated { get; set; }
        public List<string> ErrorMessages { get; set; }

    }
}

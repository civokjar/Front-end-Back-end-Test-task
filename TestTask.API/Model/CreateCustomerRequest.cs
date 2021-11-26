using TestTask.API.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.API.Model
{
    public class CreateCustomerRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [SwedishSocialSecurity]
        public string SocialSecurityNumber { get; set; }
    }
}

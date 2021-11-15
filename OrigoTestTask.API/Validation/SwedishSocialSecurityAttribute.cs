using OrigoTestTask.API.Validation.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrigoTestTask.API.Validation
{

    public class SwedishSocialSecurityAttribute : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            return Personnummer.Valid((string)value);
        }
       
    }
}

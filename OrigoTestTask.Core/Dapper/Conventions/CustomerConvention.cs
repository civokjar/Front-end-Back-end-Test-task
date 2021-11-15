using Dapper.FluentMap.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrigoTestTask.Core.Dapper.Conventions
{ 
    public class CustomerConvention : Convention
    {
        public CustomerConvention()
        {
            Properties()
                .Where(c => c.Name == "Name").Configure(x => x.HasColumnName("Name"));
            Properties()
                .Where(c => c.Name == "SocialSecurityNumber")
                .Configure(x => x.HasColumnName("ssn"));
            Properties()
                .Where(c => c.Name == "Id")
                .Configure(x => x.HasColumnName("Id"));


        }
    }
}


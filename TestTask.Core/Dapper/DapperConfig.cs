using Dapper.FluentMap;
using TestTask.Core.Dapper.Conventions;
using TestTask.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Core.Dapper
{
    public class DapperConfig
    {
        public static void RegisterConventions()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddConvention<CustomerConvention>().ForEntity<Customer>();
            });
        }
    }
}

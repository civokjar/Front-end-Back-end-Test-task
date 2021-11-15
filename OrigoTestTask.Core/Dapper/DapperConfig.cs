using Dapper.FluentMap;
using OrigoTestTask.Core.Dapper.Conventions;
using OrigoTestTask.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrigoTestTask.Core.Dapper
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

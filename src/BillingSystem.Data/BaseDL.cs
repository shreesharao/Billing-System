using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BillingSystem.Data
{
    public class BaseDL
    {
        protected string GetDatabaseTypeFromConfig()
        {
            var type = ConfigurationManager.AppSettings["DB"];

            return type.ToString();
        }
    }
}

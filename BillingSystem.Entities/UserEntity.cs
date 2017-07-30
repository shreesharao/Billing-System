using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Entities
{
    public class UserEntity
    {
        public string UserName { get; set; }
        public long PhNumber{ get; set; }
        public string  Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate{ get; set; }
    }
}

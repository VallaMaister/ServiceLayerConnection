using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerConnection.Model
{
    public class Login
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string CompanyDB { get; set; }
    }
}

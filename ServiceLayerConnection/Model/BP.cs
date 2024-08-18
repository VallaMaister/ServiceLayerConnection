using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerConnection.Model
{
    public class BP
    {
        public required string CardCode { get; set; }
        public required string CardName { get; set; }

        public required string FederalTaxID {  get; set; }
    }
}

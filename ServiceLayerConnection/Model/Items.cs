using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerConnection.Model
{
    public class Items
    {
        public required string ItemCode { get; set; }
        public required string ItemName { get; set; }
        public string SalesItem { get; set; }
        public string PurchaseItem { get; set; }
        public string InventoryItem { get; set; }
    }
}

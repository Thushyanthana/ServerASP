using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace server.Models
{
    public class vehicles
    {

        public long id { get; set; }
        public String part_name { get; set; }

        public String ShelveNumber { get; set; }
        public String Location { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public long AvailableQuantity   { get; set; }

         public long UnitPrice   { get; set; }



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBakingCentre.Models
{
    //each shopping cart item is added as a OrderDetail Item associated with Order Object
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int PieId { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public Pie Pie { get; set; }

    }
}

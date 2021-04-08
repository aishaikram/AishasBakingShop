using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBakingCentre.Models
{
    public interface IOrderRepository
    {
        public void CreateOrder(Order order);
        public Order GetOrderById { get; set; }
       
        public IEnumerable<OrderDetail> GetOrderDetail(int orderId);

    }
}

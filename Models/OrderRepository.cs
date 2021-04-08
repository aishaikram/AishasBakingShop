using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBakingCentre.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        private readonly Order _order;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart  shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;

        }

        
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            
            var shoppingCartItems = _shoppingCart.GetShoppingCartItems();
            order.OrderTotal = _shoppingCart.GetShoppingCartTotalPrice();
            order.OrderDetails = new List<OrderDetail>();

            //for each item in shopping cart, add order detail like pie, amount, price
            foreach ( var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = order.OrderId,
                    PieId = shoppingCartItem.Pie.PieId,
                    Amount = shoppingCartItem.Amount,
                    Price = shoppingCartItem.Pie.Price
                };
                
                order.OrderDetails.Add(orderDetail);
            }
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();

        }
        public Order GetOrderById { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerable<OrderDetail> GetOrderDetail(int orderId)
        {
            throw new NotImplementedException();
        }

       
    }
}

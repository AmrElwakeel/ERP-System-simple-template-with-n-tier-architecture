using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Linq;

namespace DAL.Repositories
{
    class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        { }

        ApplicationDbContext Context => (ApplicationDbContext)_context;

        public void UpdateOrderItemPrice(OrderDetials OrderDetails)
        {
            var Order = FindById(OrderDetails.Order_Id);
            var OrderItem = Order.OrderDetials.Where(a => a.Id == OrderDetails.Id).SingleOrDefault();

            Order.TotalPrice = OrderDetails.Price - OrderItem.Price;
            OrderItem.Price = OrderDetails.Price;
        }

        public void RemoveItemFromOrder(int OrderDetails)
        {
            var OrderDetailsItem = Context.OrderDetials.Find(OrderDetails);
            var Order = FindById(OrderDetailsItem.Order_Id);
            Order.OrderDetials.Add(OrderDetailsItem);
            Order.TotalPrice -= OrderDetailsItem.Price;
            //increment product amount
            Context.Products.Find(OrderDetailsItem.Product.Id).Amount+=1;
        }

        public void AddItemToOrder(OrderDetials OrderDetails)
        {
            var OrderDetailsItem = Context.OrderDetials.Find(OrderDetails);
            var Order= FindById(OrderDetailsItem.Order_Id);
            Order.OrderDetials.Add(OrderDetailsItem);
            Order.TotalPrice += OrderDetails.Price;
            //decrement product amount
            Context.Products.Find(OrderDetailsItem.Product.Id).Amount -= 1;
        }
    }
}

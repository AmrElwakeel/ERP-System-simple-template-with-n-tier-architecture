using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public void UpdateOrderItemPrice(OrderDetials OrderDetails);
        public void AddItemToOrder(OrderDetials OrderDetails);
        public void RemoveItemFromOrder(int OrderDetails);

    }
}

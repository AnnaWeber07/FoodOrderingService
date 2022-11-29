using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrderingService.RD;


namespace FoodOrderingService
{
    public class OrdersManager
    {
        private readonly List<Order> _orders = new();


        private readonly object _ordersLocker = new();


        public List<Order> Orders
        {
            get
            {
                lock (_ordersLocker)
                {
                    return _orders;
                }
            }
        }


        public void AddNewOrder(Order order)
        {
            Orders.Add(order);
        }


        public void RemoveOrder(Order order)
        {
            Orders.Remove(order);
        }

        public void SendToRestaurant(Order order)
        {
            //serialize order

        }

        public void SendToCient(Order order)
        {
            //serialize order

            //if order state done remove from list
        }

        public void ReceiveFromRestaurant(Order order)
        {
            //deserialize order

            AddNewOrder(order);
        }

        public void ReceiveFromClient()
        {
            //deserialize order
        }


        //logic of working with order manager флоу

        //есть список заказов, лист + linq
        //получает заказ от клиента, перенаправляет в ресторан
        //аггрегация ответа от всех ресторанов
        //отправка ответа обратно к клиенту
        //получает рейтинг от клиента и присваивает рейтинг ресторану
        //высчитывает средний рейтинг симуляции на основе общего рейтинга

    }
}

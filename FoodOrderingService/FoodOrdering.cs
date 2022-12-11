using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrderingService.RD;
using System.Runtime.CompilerServices;

namespace FoodOrderingService
{
    public class FoodOrdering : BackgroundService
    {
        private List<DataRegistration> _dataRegistration;
        private List<GetClientMenu> _getClientMenu;

        private readonly object _dataRegistrationLocker;
        private readonly object _menuLocker;


        public FoodOrderingServer orderingServer;

        public List<DataRegistration> DataRegistrations
        {
            get
            {
                lock (_dataRegistrationLocker)
                {
                    return _dataRegistration;
                }
            }
        }

        public List<GetClientMenu> GetClientMenu
        {
            get
            {
                lock (_menuLocker)
                {
                    return _getClientMenu;
                }
            }

        }

        public OrdersManager ordersManager;


        public FoodOrdering(FoodOrderingServer server)
        {
            this.orderingServer = server;
            this.orderingServer.Start(this);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            InitializeOrderManager();

            return Task.CompletedTask;
        }


        private void InitializeOrderManager()
        {
            //todo: logic of ordermanagersystem
        }

        public void RegisterData(DataRegistration incomingData)
        {
            DataRegistrations.Add(incomingData);
            var id = incomingData.RestaurantId;
            var menuList = incomingData.MenuList;

            //  ComposeClientMenu();
        }

        public void ComposeClientMenu()
        {
            var numberOfRestaurants = DataRegistrations.Count;
            if (numberOfRestaurants == 4)
            {
                foreach (DataRegistration dataRegistration in DataRegistrations)
                {

                }
            }
        }

    }
}

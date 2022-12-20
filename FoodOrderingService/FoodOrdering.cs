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
        private List<Menu> _menu = new();
        private List<DataRegistration> _dataRegistration = new();
        public GetClientMenu _getClientMenu = new();

        private readonly object _dataRegistrationLocker = new();
        private readonly object _menuLocker = new();


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

        public GetClientMenu GetClientMenu
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

        }

        public void RegisterData(DataRegistration incomingData)
        {
            DataRegistrations.Add(incomingData);
            var id = incomingData.RestaurantId;
            var menuList = incomingData.MenuList;

            var number = 1;
            
            Menu createMenu = new Menu(menuList);

            _menu.Add(createMenu);

            RestaurantData restaurantData = new(incomingData.RestaurantName, incomingData.MenuItems, _menu);

            List<RestaurantData> restaurantDatas = new();
            restaurantDatas.Add(restaurantData);

            ComposeClientMenu(number, restaurantDatas);
        }

        public void ComposeClientMenu(int number, List<RestaurantData> restaurantDatas)
        {
            GetClientMenu.datas = restaurantDatas;
            GetClientMenu.NumberOfRestaurants = number;
        }

    }
}

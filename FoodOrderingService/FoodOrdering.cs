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
        private List<RestaurantData> _restaurantData;
        private List<Menu> _composedMenu;

        private readonly object _dataLocker;
        private readonly object _menuLocker;


        public FoodOrderingServer orderingServer;

        public List<RestaurantData> RestaurantData
        {
            get
            {
                lock (_dataLocker)
                {
                    return _restaurantData;
                }
            }
        }

        public List<Menu> ComposedMenu
        {
            get
            {
                lock (_menuLocker)
                {
                    return _composedMenu;
                }
            }

        }

        public OrdersManager ordersManager;


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            InitializeOrderManager();

            return Task.CompletedTask;
        }


        private void InitializeOrderManager()
        {
            //logic of ordermanagersystem
        }

        public void RegisterData(RestaurantData incomingData)
        {
            RestaurantData.Add(incomingData);
            var id = incomingData.RestaurantId;
            var menuList = incomingData.RestaurantMenuItems;
            SeparateMenu(id, menuList.MenuValues);

        }

        public void SeparateMenu(long id, List<Food> menuList)
        {
            Menu menu = new Menu(id, menuList);
            ComposedMenu.Add(menu);

            if (ComposedMenu.Count > 3)
            {
                orderingServer.SendMenu(ComposedMenu);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingService.RestaurantData
{
    public class DTORestaurantData
    {
        //private static ObjectIDGenerator iDGenerator = new();
        //public List<Menu> ComposedMenus;

        public long RestaurantId { get; set; }
        public string RestaurantAddress { get; set; }
        public Menu RestaurantMenuItems { get; set; }
        public float Rating { get; set; }


        //public DTORestaurantData(long restaurantId, string restaurantAddress, Menu menu, float rating)
        //{
        //    RestaurantId = restaurantId;
        //    RestaurantAddress = restaurantAddress;
        //    RestaurantMenuItems = menu;
        //    Rating = rating;
        //}

    }
}

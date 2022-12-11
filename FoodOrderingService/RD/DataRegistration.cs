using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FoodOrderingService.RD
{
    public class DataRegistration
    {
        public long RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        // public string Address { get; set; }
        public int MenuItems { get; set; }
        public List<Food> MenuList { get; set; }
        public float Rating { get; set; }

        public DataRegistration()
        {

        }

        //[JsonConstructor]
        //public DataRegistration(long RestaurantId, string RestaurantName, int MenuItems,
        //    List<Food> MenuList, float Rating)
        //{
        //    this.RestaurantId = RestaurantId;
        //    this.RestaurantName = RestaurantName;
        //    this.MenuItems = MenuItems;
        //    this.MenuList = MenuList;
        //    this.Rating = Rating;
        //}

    }
}

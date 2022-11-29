using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingService.RD
{
    public class RestaurantData
    {
        public string RestaurantName { get; set; }
        public int MenuItems { get; set; }
        public List<Menu> menus { get; set; }
        public float Rating { get; set; }
    }
}

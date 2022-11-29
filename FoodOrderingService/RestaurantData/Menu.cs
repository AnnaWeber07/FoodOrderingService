using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingService.RestaurantData
{
    public class Menu
    {
        //restaurant menu parser
        public long RestaurantId { get; set; }
        public List<Food> MenuValues;

        public Menu(long restId, List<Food> menu)
        {
            RestaurantId = restId;
            MenuValues = menu;
        }

    }
}

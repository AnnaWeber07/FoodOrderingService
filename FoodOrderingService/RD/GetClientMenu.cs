using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingService.RD
{
    public class GetClientMenu
    {
        public int NumberOfRestaurants { get; set; }
        public List<RestaurantData> datas { get; set; }

        public GetClientMenu()
        {

        }

        public GetClientMenu(List<RestaurantData> datas)
        {
            NumberOfRestaurants = 1;
            this.datas = datas;
        }
    }
}

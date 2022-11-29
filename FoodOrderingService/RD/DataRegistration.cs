using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingService.RD
{
    public class DataRegistration
    {
        public long RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int MenuItems { get; set; }
        public List<Menu> RespectiveMenu { get; set; }
        public float Rating { get; set; }
    }
}

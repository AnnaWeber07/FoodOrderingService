using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingService
{
    public class OrderResponse
    {
        public long RestaurantId { get; set; }
        public string RestaurantAddress { get; set; }
        public int OrderId { get; set; }
        public TimeSpan CreatedTime { get; set; }
        public TimeSpan RegisteredTime { get; set; }
    }
}

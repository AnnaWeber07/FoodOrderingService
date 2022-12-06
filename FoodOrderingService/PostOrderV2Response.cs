using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using FoodOrderingService.RD;


namespace FoodOrderingService
{
    public class PostOrderV2Response
    {
        public long RestaurantId { get; set; }
        public long OrderId { get; set; }
        // public List<long> Items { get; set; }
        public TimeSpan CreatedTime { get; set; }
        public TimeSpan RegisteredTime { get; set; }
    }
}

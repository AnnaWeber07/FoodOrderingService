using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using FoodOrderingService.RD;


namespace FoodOrderingService
{
    public class PostOrderV2
    {
        public long RestaurantId { get; set; }
        public List<long> Items { get; set; }
        public int Priority { get; set; }
        public float MaxWait { get; set; }
        public TimeSpan CreatedTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using FoodOrderingService.RestaurantData;


namespace FoodOrderingService
{
    public class Order
    {
        private static ObjectIDGenerator idGenerator = new ObjectIDGenerator();
        public long Id { get; private set; }
        public List<long> Items { get; set; }
        public int Priority { get; set; }
        public float MaxWaitingTime { get; set; }
        public long TableId { get; set; }

        public Order()
        {
            Items = new List<long>();
            Id = idGenerator.GetId(this, out _);
        }
    }
}

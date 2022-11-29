using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingService
{
    public class PostOrderResponse
    {
        public int OrderId { get; set; }
        public List<OrderResponse> Orders { get; set; }
    }
}

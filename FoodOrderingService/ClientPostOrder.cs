using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingService
{
    public class ClientPostOrder
    {
        public long ClientId { get; set; }
        public List<Order> Orders { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingService.RD
{
    public class Menu
    {
        //restaurant menu parser
        public List<Food> MenuValues { get; set; }

        public Menu(List<Food> menu)
        {
            MenuValues = menu;
        }

    }
}

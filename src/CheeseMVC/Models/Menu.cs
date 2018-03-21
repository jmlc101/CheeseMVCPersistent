using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class Menu
    {
        public int ID { get; set; }
        public string Name { get; set; }

        // TODO - Notice the get's and set's added below? needed?
        public IList<CheeseMenu> CheeseMenus { get; set; } = new List<CheeseMenu>();

    }
}

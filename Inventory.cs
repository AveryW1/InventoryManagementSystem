using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace InventoryManagementSystem
{//Needs fields Part ID, Name, Inventory, Price, Min, Max. Create a privte variable for binding list<Part> object creation. 
    static class Inventory
    {
        public static BindingList<Product> ProductBL = new BindingList<Product>();
        public static BindingList<Part> PartBL = new BindingList<Part>();

    }

}

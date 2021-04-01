using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace InventoryManagementSystem
{//Needs fields Part ID, Name, Inventory, Price, Min, Max. Create a privte variable for binding list<Part> object creation. 
    class Inventory
    {
        public static BindingList<Product> prodBindList = new BindingList<Product>();
        public static BindingList<Part> partBindList = new BindingList<Part>();

    }
}

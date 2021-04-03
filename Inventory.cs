using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace InventoryManagementSystem
{//Needs fields Part ID, Name, Inventory, Price, Min, Max. Create a privte variable for binding list<Part> object creation. 
    //Static methods
    static class Inventory
    {
        public static BindingList<Product> ProductBL = new BindingList<Product>();
        public static BindingList<Part> PartBL = new BindingList<Part>();

        //Remember this method needs to be static since you're acting on the only, global inventory class and not an instance.
        public static void addPart(Part part)
        {
            PartBL.Add(part);
        }


    }

}

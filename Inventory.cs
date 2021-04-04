using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace InventoryManagementSystem
{//Needs fields Part ID, Name, Inventory, Price, Min, Max. Create a privte variable for binding list<Part> object creation. 
    //Static methods
    static class Inventory
    {
        public static BindingList<Product> ProductBL = new BindingList<Product>();
        public static BindingList<Part> PartBL = new BindingList<Part>();

        //This method will have to find someway to add the associated parts
        public static void addProduct(Product product)
        {
            ProductBL.Add(product);
        }
        //Remember this method needs to be static since you're acting on the only, global inventory class and not an instance.
        public static void addPart(Part part)
        {
            PartBL.Add(part);
        }

        public static bool deletePart(Part part) //Checks if part is in list, removes if true, reutrns message if not.
        {
            if (PartBL.Contains(part))//Delete is not finding the current part.
            {
                PartBL.Remove(part);
                return true;
            }
            else
            {
                return false;
            }
        }


    }

}

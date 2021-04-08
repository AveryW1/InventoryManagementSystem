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

        public static void InitializeBLs()
        {
            
            //This is test data added to pre-populate the DGVs. Can add parts here for testing. Add part method is from invetory.
            addPart(new Inhouse(002, "bolt", 1.2M, 5, 0, 10, 11003));
            addPart(new Outsourced(003, "bolt1", 13.2M, 5, 0, 10, "Tesla"));
            addPart(new Inhouse(004, "bolt2", 1.23M, 5, 0, 10, 11003));
            addPart(new Outsourced(005, "bolt3", 1.12M, 5, 0, 10, "Rain"));
        }

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

        public static void deletePart(Part part) //Checks if part is in list, removes if true, reutrns message if not. TRY FINDING BY PART ID instead of currentIdx
        {
            PartBL.Remove(part);
            
            //if (PartBL.Contains(part))//Delete is not finding the current part.
            //{
            //    PartBL.Remove(part);
            //    
            //    
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public static void updatePart(int index, Part part) //Can call property of part and update them individually.
        {
            //part.
        }

        
    }

}

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;


namespace InventoryManagementSystem
{//Needs checks for unique part and product IDs 
    //Static methods
    static class Inventory
    {
        public static BindingList<Product> ProductBL = new BindingList<Product>();
        public static BindingList<Part> PartBL = new BindingList<Part>();
        //public static BindingList<Part> Parts { get { return PartBL; } set { PartBL = value; } }

        //These properties are used to access the current(selected) part.
        public static Part currentPart { get; set; }
        public static int currentPartID { get; set; }
        //public static int currentIndex { get; set; }
       
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

        public static void deletePart(Part part)
        {
            PartBL.Remove(part);
        }

        public static void updatePart(int idx, Part part) //Can call property of part and update them individually.
        {
            //part.
        }

        public static Part lookupPart(int partID)
        {
            try
            {
                //compare input partID(int) with all part IDs in PartBL. Return Part
                for (int i = 0; i <= PartBL.Count; i++)
                {
                    if (PartBL[i].PartID == partID)
                    {
                        return PartBL[i];
                    }
                }
                return null;
            }
            catch
            {
                string message = "Part was not found by given part ID.";
                string caption = "Part not found";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                return null;
            }
        }

        
    }

}

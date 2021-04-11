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

        public static void InitializeBLs()
        {
            
            //This is test data added to pre-populate the DGVs. Can add parts here for testing. Add part method is from invetory.
            addPart(new Inhouse(002, "bolt", 1.2M, 5, 0, 10, 11003));
            addPart(new Outsourced(003, "bolt1", 13.2M, 5, 0, 10, "Tesla"));
            addPart(new Inhouse(004, "bolt2", 1.23M, 5, 0, 10, 11003));
            addPart(new Outsourced(005, "bolt3", 1.12M, 5, 0, 10, "Rain"));
            addPart(new Outsourced(055, "bolt4", 1.52M, 5, 0, 10, "Snow"));
            addPart(new Outsourced(505, "bolt5", 1.3M, 5, 0, 10, "Sleet"));
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

        //Takes info from all textboxes, saves as new part, replaces old part in same index.
        public static void updatePart(int idx, Part part)
        {
            
            
            
            
            PartBL[idx] = part;
        }

        //With exception handling, this method compares input partID(int) with all part IDs in PartBL. Return Part
        public static Part lookupPart(int partID)
        {
            try
            {
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

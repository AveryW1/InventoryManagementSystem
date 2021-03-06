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
            addPart(new Inhouse("bolt", 1.2M, 5, 0, 10, 11003));
            addPart(new Outsourced("seat", 13.2M, 5, 0, 10, "Tesla"));
            addPart(new Inhouse("net", 1.23M, 5, 0, 10, 11003));
            addPart(new Outsourced("post", 1.12M, 5, 0, 10, "Rain"));
            addPart(new Outsourced("string", 1.52M, 5, 0, 10, "Snow"));
            addPart(new Outsourced("pole", 1.3M, 5, 0, 10, "Sleet"));
            addProduct(new Product("Swing", 4.3M, 10, 0, 10));
            addProduct(new Product("Tent", 1.3M, 10, 0, 15));
            addProduct(new Product("Goal", 5.3M, 8, 0, 20));
            addProduct(new Product("Bow", 4.6M, 3, 0, 14));
            addProduct(new Product("Fishing Rod", 2.3M, 67, 0, 120));
        }

        public static void addProduct(Product product)
        {
            ProductBL.Add(product);
        }
        
        //Remember this method needs to be static since you're acting on the only, global inventory class and not an instance.
        public static void addPart(Part part)
        {
            PartBL.Add(part);
        }

        //Needs to be return bool with confirm delete
        public static bool deletePart(Part part)
        {
            if (PartBL.Remove(part))
            {
                string message = "Part has been removed.";
                string caption = "Success!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                return true;
            }
            else
                return false;
        }

        //Uses remove at since it takes ints. Must return a bool.
        public static bool removeProduct(int product)
        {
            ProductBL.RemoveAt(product);
            return true;
        }

        //Exchanges the newly updated part with the old one in the PartBL list.
        public static void updatePart(int idx, Part part)
        {
            PartBL.RemoveAt(idx);
            PartBL.Insert(idx, part);
        }

        public static void updateProduct(int idx, Product product)
        {
            ProductBL.RemoveAt(idx);
            ProductBL.Insert(idx, product);
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
                string message = "Part was not found by given part name.";
                string caption = "Part not found";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                return null;
            }
        }
        
        public static Product lookupProduct(int productID)
        {
            try
            {
                for (int i = 0; i <= ProductBL.Count; i++)
                {
                    if (ProductBL[i].ProductID == productID)
                    {
                        return ProductBL[i];
                    }
                }
                return null;
            }
            catch
            {
                string message = "Product was not found by given part name.";
                string caption = "Product not found";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                return null;
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public class Product 
    {
        //Not static since each product will contain their own list.
        public BindingList<Part> AssociatedParts = new BindingList<Part>();

        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        //Used to track current product for Add Products.
        public static Product currentProduct { get; set; }

        //Used to auto-increament product IDs
        public static int increment = 1;

        //Constructor
        public Product(int productID, string name, decimal price, int inStock, int min, int max)
        {
            ProductID = productID;
            Name = name;
            Price = price;
            InStock = inStock;
            Min = min;
            Max = max;
        }

        public Product(string name, decimal price, int inStock, int min, int max)
        {
            ProductID = increment++;
            Name = name;
            Price = price;
            InStock = inStock;
            Min = min;
            Max = max;
        }

        public void addAssociatedPart(Part part)
        {
            AssociatedParts.Add(part);
        }

        public bool removeAssociatePart(int partID)
        {
            AssociatedParts.RemoveAt(partID);
            return true;
        }

        public Part lookupAssociatedPart(int partID)
        {
            try
            {
                for (int i = 0; i <= Product.currentProduct.AssociatedParts.Count; i++)
                {
                    if (AssociatedParts[i].PartID == partID)
                    {
                        return AssociatedParts[i];
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

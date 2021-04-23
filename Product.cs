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

        public void addAssociatedPart(Part part)
        {
            AssociatedParts.Add(part);
        }

        public bool removeAssociatePart(int partID)
        {
            AssociatedParts.RemoveAt(partID);
            return true;
        }

        //Written to work for ModifyProducts search. Will not work with Add Products search.
        public Part lookupAssociatedPart(int partID)
        {
            try
            {
                for (int i = 0; i <= ModifyProducts.currentProduct.AssociatedParts.Count; i++)
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

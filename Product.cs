using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

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

        //public Part lookupAssociatedPart(int partID)
        //{
        //
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace InventoryManagementSystem
{//not inheriting from part. only similar attributes
    class Product 
    {
        //Not stitic since its not the only instance
        public BindingList<Part> AssociatedParts = new BindingList<Part>();

        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        //Constructor. Variable names coordinate with the properties of base class Part.
        public Product(int productID, string name, decimal price, int inStock, int min, int max)
        {
            ProductID = productID;
            Name = name;
            Price = price;
            InStock = inStock;
            Min = min;
            Max = max;
        }
       /*
        public void addAssociatedPart(Part part) //Should use partID as reference
        {
            AssociatedParts.Add(new());
        }
        public bool removeAssociatedPart(int s)
        {

        }

        public Part lookupAssociatedPart(int c)
        {

        }
        */
    }
}

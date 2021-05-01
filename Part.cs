using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem
{
    //Abstract class
    public abstract class Part
    {
        //Properties with auto getters/setters.
        public int PartID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        //Used to auto increment part IDs
        public static int increment = 1;

        public Part(int partID, string name, decimal price, int inStock, int min, int max)
        {
            PartID = partID;
            Name = name;
            Price = price;
            InStock = inStock;
            Min = min;
            Max = max;
        }

        public Part(string name, decimal price, int inStock, int min, int max)
        {
            PartID = increment++;
            Name = name;
            Price = price;
            InStock = inStock;
            Min = min;
            Max = max;
        }
    }

}
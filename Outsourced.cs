using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem
{
    class Outsourced : Part
    {
        public string CompanyName { get; set; }
        //Constructor
        public Outsourced(int partID, string name, decimal price, int inStock, int min, int max, string companyName) : base(partID, name, price, inStock, min, max)
        {
            CompanyName = companyName;
        }

        public Outsourced(string name, decimal price, int inStock, int min, int max, string companyName) : base(name, price, inStock, min, max)
        {
            CompanyName = companyName;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem
{
    class Inhouse : Part
    {
        public int MachineID { get; set; }
        //Constructor (Webinar: Constructors and debugging)
        public Inhouse(int partID, string name, decimal price, int inStock, int min, int max, int machineID) : base(partID, name, price, inStock, min, max)
        {
            MachineID = machineID;
        }

        public Inhouse(string name, decimal price, int inStock, int min, int max, int machineID) : base(name, price, inStock, min, max)
        {
            MachineID = machineID;
        }
    }
}

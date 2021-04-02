using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem
{
    //Abstract classes hav eno constructors or static methods.
    abstract class Part
    {
        //Properties
        public abstract int PartID { get; set; }
        public abstract string Name { get; set; }
        public abstract decimal Price { get; set; }
        public abstract int InStock { get; set; }
        public abstract int Min { get; set; }
        public abstract int Max { get; set; }

    }
}

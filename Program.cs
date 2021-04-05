using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //This is test data added to pre-populate the DGVs. Can add parts here for testing. Add part method is from invetory.
            //Inventory.addPart(new Inhouse(002, "bolt", 1.2M, 5, 0, 10, 11003));
            //Inventory.addPart(new Outsourced(003, "bolt1", 13.2M, 5, 0, 10, "Tesla"));
            //Inventory.addPart(new Inhouse(004, "bolt2", 1.23M, 5, 0, 10, 11003));
            //Inventory.addPart(new Outsourced(005, "bolt3", 1.12M, 5, 0, 10, "Rain"));
            //In main tell DGV to use the Parts BL as data source.
            Application.Run(new Main());
        }
    }
}

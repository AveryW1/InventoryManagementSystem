using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class ModifyParts : Form
    {
        public static Part currentPart { get; set; }
        public static int currentPartID { get; set; }


        //Use variable for current part selected
        public ModifyParts() 
        {
            InitializeComponent();
            textBoxModifyID.Text = currentPart.PartID.ToString();

        }

        private void buttonModifyCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

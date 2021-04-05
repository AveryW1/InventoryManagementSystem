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
        public ModifyParts()
        {
            InitializeComponent();
        }

        private void buttonModifyCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

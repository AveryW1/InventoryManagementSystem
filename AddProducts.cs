using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class AddProducts : Form
    {
        public AddProducts()
        {
            InitializeComponent();
            buildCandidatePartsDGV();
        }
        public void buildCandidatePartsDGV()
        {
            dataGridViewCParts.DataSource = Inventory.PartBL;
        }

        private void buttonAddProductsSave01_Click(object sender, EventArgs e)
        {
            Inventory.addProduct(new Product(Convert.ToInt32(textBoxProductID.Text), textBoxProductName.Text, Convert.ToInt32(textBoxProductPrice.Text), Convert.ToInt32(textBoxProductInventory.Text), Convert.ToInt32(textBoxProductMax.Text), Convert.ToInt32(textBoxProductMin.Text)));
            this.Close();
        }

        private void buttonAddProductsCancel01_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

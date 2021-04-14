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
            try
            {
                Inventory.addProduct(new Product(Convert.ToInt32(textBoxProductID.Text), textBoxProductName.Text, Convert.ToInt32(textBoxProductPrice.Text), Convert.ToInt32(textBoxProductInventory.Text), Convert.ToInt32(textBoxProductMax.Text), Convert.ToInt32(textBoxProductMin.Text)));
            }
            catch (FormatException)
            {
                string message = "Please check the format of your inputs. ID, Inventory, Price, Min, max, and machineID are intergers.";
                string caption = "Input Format Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }

            this.Close();
        }

        private void buttonAddProductsCancel01_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

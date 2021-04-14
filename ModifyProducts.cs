using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class ModifyProducts : Form
    {
        public static Product currentProduct { get; set; }
        public static int currentProductID { get; set; }
        public static int currentPModIdx { get; set; }

        
        public ModifyProducts()
        {
            InitializeComponent();
            dataGridViewMProducts.DataSource = Inventory.PartBL;
            textBoxMProductID.Text = currentProduct.ProductID.ToString();
            textBoxMProductName.Text = currentProduct.Name;
            textBoxMProductInventory.Text = currentProduct.InStock.ToString();
            textBoxMProductPrice.Text = currentProduct.Price.ToString();
            textBoxMProductMax.Text = currentProduct.Max.ToString();
            textBoxMProductMin.Text = currentProduct.Min.ToString();
        }

        private void buttonMProductsCancel01_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Updates wrong index atm.
        private void buttonMProductsSave01_Click(object sender, EventArgs e)
        {
            currentProduct = new Product(Convert.ToInt32(textBoxMProductID.Text), textBoxMProductName.Text, Convert.ToDecimal(textBoxMProductPrice.Text), Convert.ToInt32(textBoxMProductInventory.Text), Convert.ToInt32(textBoxMProductMax.Text), Convert.ToInt32(textBoxMProductMin.Text));
            Inventory.updateProduct(currentPModIdx, currentProduct);
            this.Close();
        }
    }
}

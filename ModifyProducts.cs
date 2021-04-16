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

        int currentIdx = 0;
        Part currentPart = null;
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

        private void buttonMProductsSave01_Click(object sender, EventArgs e)
        {
            currentProduct = new Product(Convert.ToInt32(textBoxMProductID.Text), textBoxMProductName.Text, Convert.ToDecimal(textBoxMProductPrice.Text), Convert.ToInt32(textBoxMProductInventory.Text), Convert.ToInt32(textBoxMProductMax.Text), Convert.ToInt32(textBoxMProductMin.Text));
            Inventory.updateProduct(currentPModIdx, currentProduct);
            this.Close();
        }

        //Will need to use same method as add parts but we're getting object reference warning.
        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            //Product.addAssociatedPart(currentPart);
        }
        
        //Need to adjust code for top DGV being PartsBL list.
        
        private void dataGridViewMProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentIdx = dataGridViewMProducts.CurrentCell.RowIndex;
            
            for (int i = 0; i < Inventory.PartBL.Count; i++)
            {
                if (Inventory.PartBL[i].PartID == (int)dataGridViewMProducts.Rows[currentIdx].Cells[0].Value)
                {
                    currentPart = Inventory.PartBL[i];
                    break;
                }
            }
        }
    }
}

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
        int currentAPIdx = 0;
        Part currentAPart = null;
        
        //Product tempProduct = null;
        public ModifyProducts()
        {
            InitializeComponent();
            dataGridViewMProducts.DataSource = Inventory.PartBL;
            dataGridViewAssoParts.DataSource = currentProduct.AssociatedParts;
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

        //Tip to remember: This had to reference an instnce of the Product class (currentProduct) since Product is not static. 
        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            currentProduct.addAssociatedPart(currentPart);
        }
        
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

        private void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to delete this part?";
            string caption = "Delete Associated Part?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (currentAPIdx >= 0)
                {
                    currentProduct.removeAssociatePart(currentAPIdx);
                    currentAPIdx = -1;
                }
                else
                {
                    string message1 = "Part not found. Please click a part in the list.";
                    string caption1 = "Failed";
                    MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                    DialogResult result1;
                    result1 = MessageBox.Show(message1, caption1, buttons1);
                }
            }
        }

        private void dataGridViewAssoParts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentAPIdx = dataGridViewAssoParts.CurrentCell.RowIndex;

            for (int i = 0; i < currentProduct.AssociatedParts.Count; i++)
            {
                if (currentProduct.AssociatedParts[i].PartID == (int)dataGridViewAssoParts.Rows[currentAPIdx].Cells[0].Value)
                {
                    currentAPart = currentProduct.AssociatedParts[i];
                    break;
                }
            }
        }

        private void buttonSearchProducts01_Click(object sender, EventArgs e)
        {
            Part searchResult = currentProduct.lookupAssociatedPart(Int32.Parse(textBoxSearchProducts01.Text));
            for (int i = 0; i < currentProduct.AssociatedParts.Count; i++)
            {
                if (currentProduct.AssociatedParts[i] == searchResult)
                {
                    dataGridViewAssoParts.ClearSelection();
                    dataGridViewAssoParts.Rows[i].Selected = true;
                }
            }
        }
    }
}

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
        int currentIdx = 0;
        Part currentPart = null;
        int currentAAIdx = 0;
        Part currentAAPart = null;

        //Used to track Product ids in use.
        List<int> ProductIDs = new List<int>();

        public AddProducts()
        {
            InitializeComponent();
            buildDGVs();
        }

        public void buildDGVs()
        {
            dataGridViewAParts.DataSource = Inventory.PartBL;
            dataGridViewAAParts.DataSource = null;
        }

        //Prevent adding doubles with if statement
        private void buttonAddProductsSave01_Click(object sender, EventArgs e)
        {
            populateIDlist();
            
            if (ProductIDs.Contains(Convert.ToInt32(textBoxProductID.Text))) 
            {
                this.Close();
            }
            else
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
            }
        }

        private void buttonAddProductsCancel01_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAddProductPart_Click(object sender, EventArgs e)
        {
            populateIDlist();

            //Needs exception handling for when user tries to add associated part with no text input in product iD
            if (ProductIDs.Contains(Convert.ToInt32(textBoxProductID.Text)))
            {
                for (int i = 0; i < Inventory.ProductBL.Count; i++)
                {
                    if (Inventory.ProductBL[i].ProductID == Convert.ToInt32(textBoxProductID.Text))
                    {
                        Inventory.ProductBL[i].AssociatedParts.Add(currentPart);
                    }
                }
            }
            else
            {
                Product tempProduct = new Product(Convert.ToInt32(textBoxProductID.Text), textBoxProductName.Text, Convert.ToInt32(textBoxProductPrice.Text), Convert.ToInt32(textBoxProductInventory.Text), Convert.ToInt32(textBoxProductMax.Text), Convert.ToInt32(textBoxProductMin.Text));
                Inventory.addProduct(tempProduct);
                tempProduct.AssociatedParts.Add(currentPart);
                dataGridViewAAParts.DataSource = tempProduct.AssociatedParts;
            }
        }

        private void dataGridViewAParts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentIdx = dataGridViewAParts.CurrentCell.RowIndex;

            for (int i = 0; i < Inventory.PartBL.Count; i++)
            {
                if (Inventory.PartBL[i].PartID == (int)dataGridViewAParts.Rows[currentIdx].Cells[0].Value)
                {
                    currentPart = Inventory.PartBL[i];
                    break;
                }
            }
        }

        //helper function
        public void populateIDlist()
        {
            for (int i = 0; i < Inventory.ProductBL.Count; i++)
            {
                ProductIDs.Add(Inventory.ProductBL[i].ProductID);
            }
        }

        //Deletes associated Part NOT PRODUCT!
        private void buttonDeleteProducts01_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to delete this part?";
            string caption = "Delete Associated Part?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    for (int i = 0; i < Inventory.ProductBL.Count; i++)
                    {
                        if (Inventory.ProductBL[i].ProductID == Convert.ToInt32(textBoxProductID.Text))
                        {
                            Inventory.ProductBL[i].AssociatedParts.Remove(currentAAPart);
                            break;
                        }
                    }
                }
                catch
                {
                    string message2 = "Please select a part in the associated parts list.";
                    string caption2 = "Select Part";
                    MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                    DialogResult result2;
                    result2 = MessageBox.Show(message2, caption2, buttons2);
                }
            }
        }

        private void dataGridViewAAParts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentAAIdx = dataGridViewAAParts.CurrentCell.RowIndex;

            for (int i = 0; i < Inventory.PartBL.Count; i++)
            {
                if (Inventory.PartBL[i].PartID == (int)dataGridViewAAParts.Rows[currentAAIdx].Cells[0].Value)
                {
                    currentAAPart = Inventory.PartBL[i];
                    break;
                }
            }
        }

        //Need to look up associated part without having to click in DGV first.
        //private void buttonSearchProducts01_Click(object sender, EventArgs e)
        //{
        //    Convert.ToInt32(textBoxSearchProducts01.Text)
        //}
    }
}
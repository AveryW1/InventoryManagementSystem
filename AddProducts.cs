﻿using System;
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

        //Prevent adding doubles with if statement
        private void buttonAddProductPart_Click(object sender, EventArgs e)
        {
            List<int> ProductIDs = new List<int>();
            List<string> ProductNames = new List<string>();

            for (int i = 0; i < Inventory.ProductBL.Count; i++)
            {
                ProductIDs.Add(Inventory.ProductBL[i].ProductID);
                ProductNames.Add(Inventory.ProductBL[i].Name);
            }


            if (ProductIDs.Contains(Convert.ToInt32(textBoxProductID.Text)) || ProductNames.Contains(textBoxProductName.Text))
            {
                //find a way to add to the already existing products associate parts list.
                //tempProduct.AssociatedParts.Add(currentPart);
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
    }
}





/* consider using this for "Save"
 List<int> ProductIDs = new List<int>();
            List<string> ProductNames = new List<string>();

            for (int i = 0; i < Inventory.ProductBL.Count; i++)
            {
                ProductIDs.Add(Inventory.ProductBL[i].ProductID);
                ProductNames.Add(Inventory.ProductBL[i].Name);
            }


            if (ProductIDs.Contains(Convert.ToInt32(textBoxProductID.Text)) || ProductNames.Contains(textBoxProductName.Text))
            {
                string message = "This product ID or name is currently in use. Please choose another or use modify to edit associated parts.";
                string caption = "Duplicate Product";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }
            else
            {
                Product tempProduct = new Product(Convert.ToInt32(textBoxProductID.Text), textBoxProductName.Text, Convert.ToInt32(textBoxProductPrice.Text), Convert.ToInt32(textBoxProductInventory.Text), Convert.ToInt32(textBoxProductMax.Text), Convert.ToInt32(textBoxProductMin.Text));
                Inventory.addProduct(tempProduct);
                tempProduct.AssociatedParts.Add(currentPart);
                dataGridViewAAParts.DataSource = tempProduct.AssociatedParts;
            }
 
 
 
 
 */
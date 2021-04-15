using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class Main : Form
    {
        //This variable serves as a control for the add parts button click event
        AddParts ap;
        ModifyParts mp;
        AddProducts apr;
        ModifyProducts mpr;

        //These variables are used by the program to "remember" what is selected in the DGVs.
        int currentIdx = 0;
        int currentPIdx = 0;
        Part currentObj = null;
        Product currentPObj = null;

        //This function creates the Binding List for Parts /w prepopulated data from Inventory.
        private void buildBindingParts()
        {
            dataGridViewParts.DataSource = Inventory.PartBL;
        }

        private void buildBindingProducts()
        {
            dataGridViewProducts.DataSource = Inventory.ProductBL;
        }

        public Main()
        {
            InitializeComponent();
            buildBindingParts();
            buildBindingProducts();
        }

        //Helper function: Shows Add Part screen.
        public void showAddParts()
        {
            if (ap == null)
            {
                ap = new AddParts();
                ap.FormClosed += new FormClosedEventHandler(ap_FormClosed);
                ap.Show();
            }
            else
                ap.Activate();
        }

        void ap_FormClosed(object sender, FormClosedEventArgs e)
        {
            ap = null;
        }

        //Helper function: Shows Modify Parts screen.
        public void showModifyParts()
        {
            if (mp == null)
            {
                mp = new ModifyParts();
                mp.FormClosed += new FormClosedEventHandler(mp_FormClosed);
                mp.Show();
            }
            else
                mp.Activate();
        }
        void mp_FormClosed(object sender, FormClosedEventArgs e)
        {
            mp = null;
        }

        public void showAddProducts()
        {
            if (apr == null)
            {
                apr = new AddProducts();
                apr.FormClosed += new FormClosedEventHandler(apr_FormClosed);
                apr.Show();
            }
            else
                apr.Activate();
        }

        void apr_FormClosed(object sender, FormClosedEventArgs e)
        {
            apr = null;
        }

        public void showModifyProducts()
        {
            if (mpr == null)
            {
                mpr = new ModifyProducts();
                mpr.FormClosed += new FormClosedEventHandler(mpr_FormClosed);
                mpr.Show();
            }
            else
                mpr.Activate();
        }
        void mpr_FormClosed(object sender, FormClosedEventArgs e)
        {
            mpr = null;
        }

        //Brings up only 1 instance of Add part window. Option to hide main if wanted. NO MDI needed.
        private void buttonAddParts_Click(object sender, EventArgs e)
        {
            showAddParts();
        }

        //Using partID to link currentIdx with the desired object from PartBL.
        private void dataGridViewParts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentIdx = dataGridViewParts.CurrentCell.RowIndex;
            
            for (int i = 0; i < Inventory.PartBL.Count; i++)
            {
                if (Inventory.PartBL[i].PartID == (int)dataGridViewParts.Rows[currentIdx].Cells[0].Value)
                {
                    currentObj = Inventory.PartBL[i];
                    break;
                }
            }
            
            //The code below should never have to run due to the break function but if so we get a popup for it.
            //Alt, throw an exception so that it can be traced in the log for the developer to check.
            //Might need to do similar for products.
            if (currentObj == null)
            {
                string message = "Part was not found within the bounds of the PartBL array.";
                string caption = "Part not found";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }

            //Lets ModifyParts know the selected part to edit for update Parts.
            //Might need to do similar for products.
            ModifyParts.currentPartID = (int)dataGridViewParts.Rows[currentIdx].Cells[0].Value;
            ModifyParts.currentPart = currentObj;
            ModifyParts.currentModIdx = currentIdx;
        }

        private void buttonDeleteParts_Click(object sender, EventArgs e) 
        {
            string message = "Are you sure you want to delete this part?";
            string caption = "Delete Part?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (currentIdx >= 0)
                {
                    for (int i = 0; i < Inventory.PartBL.Count; i++)
                    {
                        if (Inventory.PartBL[i].PartID == (int)dataGridViewParts.Rows[currentIdx].Cells[0].Value)
                        {
                            Inventory.deletePart(Inventory.PartBL[i]);
                        }
                    }
                    currentIdx = -1;
                }
            }
        }

        //Add parts shows, data of currentObj shows, edit data, ask confirm, update list obj.property = newData, 
        private void buttonModifyParts_Click(object sender, EventArgs e) 
        {
            if (!(currentObj is null))
            {
                showModifyParts();
            }
            else
            {
                string message = "Please click a part to modify";
                string caption = "Modify Which Part?";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }
        }

        private void buttonExitFromMain_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Button click takes in partID, returns part, checks the list where id matches result, and highlights result.
        private void buttonSearchParts_Click(object sender, EventArgs e)
        {
            Part searchResult = Inventory.lookupPart(Int32.Parse(textBoxSearchParts01.Text));
            for (int i = 0; i < Inventory.PartBL.Count; i++)
            {
                if (Inventory.PartBL[i] == searchResult)
                {
                    dataGridViewParts.ClearSelection();
                    dataGridViewParts.Rows[i].Selected = true;
                }
            }
        }

        private void dataGridViewProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentPIdx = dataGridViewProducts.CurrentCell.RowIndex;

            for (int i = 0; i < Inventory.ProductBL.Count; i++)
            {
                if (Inventory.ProductBL[i].ProductID == (int)dataGridViewProducts.Rows[currentPIdx].Cells[0].Value)
                {
                    currentPObj = Inventory.ProductBL[i];
                    break;
                }
            }

            ModifyProducts.currentProductID = (int)dataGridViewProducts.Rows[currentPIdx].Cells[0].Value;
            ModifyProducts.currentProduct = currentPObj;
            ModifyProducts.currentPModIdx = currentPIdx;
        }

        private void buttonAddProducts_Click(object sender, EventArgs e)
        {
            showAddProducts();
        }

        private void buttonDeleteProducts_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to delete this product?";
            string caption = "Delete Product?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (currentPIdx >= 0)
                {
                    for (int i = 0; i < Inventory.ProductBL.Count; i++)
                    {
                        if (Inventory.ProductBL[i].ProductID == (int)dataGridViewProducts.Rows[currentPIdx].Cells[0].Value)
                        {
                            Inventory.removeProduct(i);
                        }
                    }
                    currentPIdx = -1;
                }
            }
        }
        private void buttonModifyProducts_Click(object sender, EventArgs e)
        {
            if (!(currentPObj is null)) 
            {
                showModifyProducts(); 
            }
            else
            {
                string message = "Please click a product to modify";
                string caption = "Modify Which Product?";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }
        }

        private void buttonSearchProducts_Click(object sender, EventArgs e)
        {
            Product searchResult = Inventory.lookupProduct(Int32.Parse(textBoxSearchProducts01.Text));
            for (int i = 0; i < Inventory.ProductBL.Count; i++)
            {
                if (Inventory.ProductBL[i] == searchResult)
                {
                    dataGridViewProducts.ClearSelection();
                    dataGridViewProducts.Rows[i].Selected = true;
                }
            }
        }
    }
}

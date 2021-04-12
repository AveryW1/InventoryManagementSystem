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

        //These variables are used by the program to "remember" what is selected in the DGV.
        int currentIdx = 0;
        Part currentObj = null;

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
            
            //This "temporary" fix for setting currentPart at load to prevent null selection modify exception.
            //Delete after solving DGV selection changed.
            ModifyParts.currentPart = Inventory.PartBL[0];
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

        void ap_FormClosed(object sender, FormClosedEventArgs e)
        {
            ap = null;
        }

        void mp_FormClosed(object sender, FormClosedEventArgs e)
        {
            mp = null;
        }

        void apr_FormClosed(object sender, FormClosedEventArgs e)
        {
            apr = null;
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
            if (currentObj == null)
            {
                string message = "Part was not found within the bounds of the PartBL array.";
                string caption = "Part not found";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }

            //Lets ModifyParts know the selected part to edit for update Parts
            ModifyParts.currentPartID = (int)dataGridViewParts.Rows[currentIdx].Cells[0].Value;
            ModifyParts.currentPart = currentObj;
            ModifyParts.currentModIdx = currentIdx;
        }


        //Need to add checks for unique part IDs
        private void buttonDeleteParts_Click(object sender, EventArgs e) 
        {
            if(currentIdx >= 0)
            {
                for (int i = 0; i <Inventory.PartBL.Count; i++)
                {
                    if (Inventory.PartBL[i].PartID == (int)dataGridViewParts.Rows[currentIdx].Cells[0].Value)
                    {
                        Inventory.deletePart(Inventory.PartBL[i]);   
                    }
                }
                currentIdx=-1;
            }
        }

        //Add parts shows, data of currentObj shows, edit data, ask confirm, update list obj.property = newData, 
        private void buttonModifyParts_Click(object sender, EventArgs e) 
        {
            showModifyParts();
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

        private void buttonAddProducts_Click(object sender, EventArgs e)
        {
            showAddProducts();
        }
    }
}

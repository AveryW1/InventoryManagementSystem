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
        //This function creates the Binding List for Parts.
        private void buildBindingParts()
        {
            //Inventory.PartBL.Clear(); This method call will clear your DGV of any prepopulated data.
            dataGridViewParts.DataSource = Inventory.PartBL;
        }

        private void buildBindingProducts()
        {
            //Inventory.ProductBL.Clear();
            dataGridViewProducts.DataSource = Inventory.ProductBL;
        }


        public Main()
        {
            InitializeComponent();
            buildBindingParts();
            buildBindingProducts();
        }

        
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void labelPartsDGV_Click(object sender, EventArgs e)
        {

        }

        //This variable serves as a control for the add parts button click event
        AddParts ap; 

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
        private void buttonAddParts_Click(object sender, EventArgs e) //Brings up only 1 instance of Add part window. Option to hide main if wanted. NO MDI needed.
        {
            showAddParts();
        }

        void ap_FormClosed(object sender, FormClosedEventArgs e)
        {
            ap = null;
        }

        //These variables are used by the program to "remember" what is selected in the DGV.
        int currentIdx = 0;
        Part currentObj = null; //Had to use Type part due to conversion issues
        //string partID = null; //Attempt to find by partID
        private void dataGridViewParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //This could be a bug if needed to do sorting due to index changing in DGV vs the list.
            //Look for the corresponding column index for PartId to the row index. Then find the int and use it to delete from the list
            currentIdx = dataGridViewParts.CurrentCell.RowIndex;
            //systemId = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["SystemId"].Value.ToString();
            //partID = dataGridViewParts.Rows[dataGridViewParts.CurrentRow.Index].Cells["PartID"].Value.ToString(); Doesn't work
            currentObj = Inventory.PartBL[currentIdx];
        }
        

        private void dataGridViewParts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void buttonDeleteParts_Click(object sender, EventArgs e) //Delete is not finding current part.
        {
            var result = Inventory.deletePart(currentObj);
            if(result == true)
            {
                string message = "Part has been removed.";
                string caption = "Remove Success";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult messageResult;
                messageResult = MessageBox.Show(message, caption, buttons);
            }
            else
            {
                string message = "Part not found. Current index is: " + currentIdx;
                string caption = "Remove Failed";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult messageResult;
                messageResult = MessageBox.Show(message, caption, buttons);
            }
        }

        private void buttonModifyParts_Click(object sender, EventArgs e) //Add parts shows, data of currentObj shows, edit data, ask confirm, update list obj.property = newData, 
        {
            Inventory.updatePart(currentIdx, currentObj);
            showAddParts();
        }
    }
}

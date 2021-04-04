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

        AddParts ap; //This variable serves as a control for the add parts button click event
        private void buttonAddParts_Click(object sender, EventArgs e) //Brings up only 1 instance of Add part window. Option to hide main if wanted. NO MDI needed.
        {
            if (ap == null)
            {
                ap = new AddParts();
                ap.FormClosed += new FormClosedEventHandler(ap_FormClosed);
                ap.Show();
                //this.Hide(); //Causes the entire program to disappear. Likely cause nothing is on the AddParts Form yet.
            }
            else
                ap.Activate();
        }

        void ap_FormClosed(object sender, FormClosedEventArgs e)
        {
            ap = null;
        }

        //These variables are used by the program to "remember" what is selected in the DGV.
        int currentIdx = 0;
        Part currentObj = null; //Had to use Type part due to conversion issues
        private void dataGridViewParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //This could be a bug if needed to do sorting due to index changing in DGV vs the list.
            currentIdx = dataGridViewParts.CurrentCell.RowIndex;
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
    }
}

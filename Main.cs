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
        public Main()
        {
            InitializeComponent();
        }

        AddParts ap;
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void labelPartsDGV_Click(object sender, EventArgs e)
        {

        }

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

        private void menuStripMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}







/*
 * The code snippet below is to add child forms to the "Main" parent form. Add this code to an event handler, such as a button push.
 * Reference the parent form using "this" keyword. Replace child keyword with name of child form
ChildFormClass childForm = New ChildFormClass();
childForm.MdiParent = parentForm;
childForm.Show();
 */

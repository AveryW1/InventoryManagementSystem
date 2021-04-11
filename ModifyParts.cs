using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class ModifyParts : Form
    {
        //Properties created to access information from Main.cs
        public static Part currentPart { get; set; }
        public static int currentPartID { get; set; }
        public static int currentModIdx { get; set; }

        //Use variable for current part selected
        public ModifyParts() 
        {
            InitializeComponent();
            textBoxModifyID.Text = currentPart.PartID.ToString();
            textBoxModifyName.Text = currentPart.Name;
            textBoxModifyInventory.Text = currentPart.InStock.ToString();
            textBoxModifyPriceCost.Text = currentPart.Price.ToString();
            textBoxModifyMax.Text = currentPart.Max.ToString();
            textBoxModifyMin.Text = currentPart.Min.ToString();
            
            //Checks if part is inhouse/outsourced.
            //Creates temporary part that cast current part as derived type to access the derived type properties.
            if (currentPart is Inhouse)
            {
                Inhouse tempPart = (Inhouse)currentPart;
                textBoxModifyMachineID.Text = tempPart.MachineID.ToString();
                radioButtonModifyInHouse.Checked = true;
            }
            else
            {
                Outsourced tempPart = (Outsourced)currentPart;
                textBoxModifyMachineID.Text = tempPart.CompanyName;
                radioButtonModifyOutsourced.Checked = true;
                labelModifyMacIDComNA.Text = "Company Name";
            }
        }

        private void buttonModifyCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        //Not working. Updates are not being saved.
        private void buttonModifySave_Click(object sender, EventArgs e)
        {
            if (currentPart is Inhouse)
            {
                Inventory.PartBL[currentModIdx] = new Inhouse(Convert.ToInt32(textBoxModifyID.Text), textBoxModifyName.Text, Convert.ToDecimal(textBoxModifyPriceCost.Text), Convert.ToInt32(textBoxModifyInventory.Text), Convert.ToInt32(textBoxModifyMax.Text), Convert.ToInt32(textBoxModifyMin.Text), Convert.ToInt32(textBoxModifyMachineID.Text));
            }
            else
            {
                Inventory.PartBL[currentModIdx] = new Outsourced(Convert.ToInt32(textBoxModifyID.Text), textBoxModifyName.Text, Convert.ToDecimal(textBoxModifyPriceCost.Text), Convert.ToInt32(textBoxModifyInventory.Text), Convert.ToInt32(textBoxModifyMax.Text), Convert.ToInt32(textBoxModifyMin.Text), textBoxModifyMachineID.Text);
            }
            
            Inventory.updatePart(currentModIdx, currentPart);
        }
    }
}

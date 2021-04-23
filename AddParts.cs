using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class AddParts : Form
    {
        public AddParts()
        {
            InitializeComponent();
            checkBoxes();
        }
        
        private void radioButtonOutsourced_CheckedChanged(object sender, EventArgs e)
        {
            labelPartMacIDComNA.Text = "Company Name";
        }

        private void buttonPartSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonPartInHouse.Checked)
                {
                    Inventory.addPart(new Inhouse(Convert.ToInt32(textBoxPartID.Text), textBoxPartName.Text, Convert.ToDecimal(textBoxPartPriceCost.Text), Convert.ToInt32(textBoxPartInventory.Text), Convert.ToInt32(textBoxPartMax.Text), Convert.ToInt32(textBoxPartMin.Text), Convert.ToInt32(textBoxPartMachineID.Text)));
                }
                else
                {
                    Inventory.addPart(new Outsourced(Convert.ToInt32(textBoxPartID.Text), textBoxPartName.Text, Convert.ToDecimal(textBoxPartPriceCost.Text), Convert.ToInt32(textBoxPartInventory.Text), Convert.ToInt32(textBoxPartMax.Text), Convert.ToInt32(textBoxPartMin.Text), textBoxPartMachineID.Text));
                }
            }
            catch(FormatException)
            { 
                string message = "Please check the format of your inputs. ID, Inventory, Price, Min, max, and machineID are intergers. Name is a string.";
                string caption = "Input Format Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }
            this.Close();
        }

        private void radioButtonPartInHouse_CheckedChanged(object sender, EventArgs e)
        {
            labelPartMacIDComNA.Text = "Machine ID";
        }

        private void buttonPartCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*Checks if textboxes are validated before allowing save. Can run this function anytime focus is lost from a textbox.
        Use another method called allowSave to determine if save is enabled */
        private void checkBoxes()
        {
            int someNumber;
            if (!Int32.TryParse(textBoxPartID.Text, out someNumber))
            {
                textBoxPartID.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                textBoxPartID.BackColor = System.Drawing.Color.White;
            }
        }
    }
}


/*
 Check condition, set background to red, add textboxes to list, check if value of background is red, enable/disable save
 */
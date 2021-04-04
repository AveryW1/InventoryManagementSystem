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
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonOutsourced_CheckedChanged(object sender, EventArgs e)
        {
            labelPartMacIDComNA.Text = "Company Name";
        }

        private void buttonPartSave_Click(object sender, EventArgs e)
        {
            try //Attempting error handling with a dialog popup
            {
                if (radioButtonPartInHouse.Checked)
                {
                    Inventory.addPart(new Inhouse(Convert.ToInt32(textBoxPartID.Text), textBoxPartName.Text, Convert.ToDecimal(textBoxPartInventory.Text), Convert.ToInt32(textBoxPartPriceCost.Text), Convert.ToInt32(textBoxPartMax.Text), Convert.ToInt32(textBoxPartMin.Text), Convert.ToInt32(textBoxPartMachineID.Text)));
                }
                else
                {
                    Inventory.addPart(new Outsourced(Convert.ToInt32(textBoxPartID.Text), textBoxPartName.Text, Convert.ToDecimal(textBoxPartInventory.Text), Convert.ToInt32(textBoxPartPriceCost.Text), Convert.ToInt32(textBoxPartMax.Text), Convert.ToInt32(textBoxPartMin.Text), textBoxPartMachineID.Text));
                }
            }
            catch(FormatException)
            {
                //Example from microsoft documentation.
                string message = "Please check the format of your inputs. ID, Inventory, Price, Min, max, and machineID are intergers. Name is a string.";
                string caption = "Input Format Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                /*Use this if you want to close the add Part window as a reponse to the OK press.
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    this.Close();
                }*/
            }
        }

        private void radioButtonPartInHouse_CheckedChanged(object sender, EventArgs e)
        {
            labelPartMacIDComNA.Text = "Machine ID";

        }

        private void buttonPartCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

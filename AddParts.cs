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

        /*The below fucntions validate the textboxes and enables/disables save. Can run this function anytime focus is lost from a textbox.
        Use another method called allowSave to determine if save is enabled. 1 checkbox method for each field.
        Called seperately by lost focus events.
        Have to find a way to disable save if any are wrong. create save enabled function that checks color or textboxes.
        */
        private void checkBoxes_IntergersAP(Control boxName)
        {
            int someNumber;
            if (!Int32.TryParse(boxName.Text, out someNumber))
            {
                boxName.BackColor = System.Drawing.Color.Red;
                buttonPartSave.Enabled = false;
            }
            else
            {
                boxName.BackColor = System.Drawing.Color.White;
                buttonPartSave.Enabled = true;
            }
        }
        private void textBoxPartID_LostFocus (object sender, System.EventArgs e)
        {
            checkBoxes_IntergersAP(textBoxPartID);
        }

        private void textBoxPartInventory_LostFocus(object sender, System.EventArgs e)
        {
            checkBoxes_IntergersAP(textBoxPartInventory);
        }

        private void textBoxPartMax_LostFocus(object sender, System.EventArgs e)
        {
            checkBoxes_IntergersAP(textBoxPartMax);
        }

        private void textBoxPartMin_LostFocus(object sender, System.EventArgs e)
        {
            checkBoxes_IntergersAP(textBoxPartMin);
        }
    }
}


/*
 machineID/name can be handled with an if statement for radiobutton checked. others with strings or decimals.
Min Max can be handled with if statements
 */
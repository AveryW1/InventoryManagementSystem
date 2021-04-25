using System;
using System.Windows.Forms;
using System.Globalization;
using System.ComponentModel;

namespace InventoryManagementSystem
{
    public partial class AddParts : Form
    {
        //Binding list of Controls. Usable only by addparts.
        private BindingList<Control> controls = new BindingList<Control>();

        public AddParts()
        {
            InitializeComponent();

            //Adds textboxes to list and disables save at load
            controls.Add(textBoxPartID);
            controls.Add(textBoxPartInventory);
            controls.Add(textBoxPartName);
            controls.Add(textBoxPartPriceCost);
            controls.Add(textBoxPartMachineID);
            controls.Add(textBoxPartMax);
            controls.Add(textBoxPartMin);
            buttonPartSave.Enabled = false;
        }

        private void radioButtonOutsourced_CheckedChanged(object sender, EventArgs e)
        {
            labelPartMacIDComNA.Text = "Company Name";
            checkBoxes_RadioAP(textBoxPartMachineID);
        }
        private void radioButtonPartInHouse_CheckedChanged(object sender, EventArgs e)
        {
            labelPartMacIDComNA.Text = "Machine ID";
            checkBoxes_RadioAP(textBoxPartMachineID);
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
                this.Close();
            }
            catch (FormatException)
            {
                string message = "Please check the format of your inputs. ID, Inventory, Price, Min, max, and machineID are intergers. Name is a string.";
                string caption = "Input Format Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }
        }

        private void buttonPartCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*The below fucntions validate the textboxes and enables/disables save. 
        Iterates through list of controls and checks color of background.*/
        private void button_SaveEnabledCheck()
        {
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].BackColor != System.Drawing.Color.White)
                {
                    buttonPartSave.Enabled = false;
                    break;
                }
                else
                {
                    buttonPartSave.Enabled = true;
                }
            }
        }

        //Checks if input is an interger.
        private void checkBoxes_IntergersAP(Control boxName)
        {
            int someNumber;
            if (!Int32.TryParse(boxName.Text, out someNumber))
            {
                boxName.BackColor = System.Drawing.Color.MistyRose;
            }
            else
            {
                boxName.BackColor = System.Drawing.Color.White;
            }
        }

        //Checks if input is not null.
        private void checkBoxes_StringAP(Control boxName)
        {
            if (String.IsNullOrWhiteSpace(boxName.Text))
            {
                boxName.BackColor = System.Drawing.Color.MistyRose;
            }
            else
            {
                boxName.BackColor = System.Drawing.Color.White;
            }
        }

        //Checks if input is a decimal. All inputs are either passing or failing due to the req of "m"
        private void checkBoxes_DecimalAP(Control boxName)
        {
            decimal someNumber;
            NumberStyles styles = NumberStyles.Currency;
            CultureInfo culture = CultureInfo.CurrentUICulture;

            if (!decimal.TryParse(boxName.Text, styles, culture, out someNumber))
            {
                boxName.BackColor = System.Drawing.Color.MistyRose;
            }
            else
            {
                boxName.BackColor = System.Drawing.Color.White;
            }
        }



        //Checks radio button state and then checks string or int.
        private void checkBoxes_RadioAP(Control boxName)
        {
            //checks state of radio button
            if (radioButtonPartOutsourced.Checked)
            {
                checkBoxes_StringAP(boxName);
                button_SaveEnabledCheck();
            }
            else
            {
                checkBoxes_IntergersAP(boxName);
                button_SaveEnabledCheck();
            }
        }

        //Checks if Max > min
        private void checkBoxes_MinMax(Control minBox, Control maxBox)
        {
            try
            {
                if ((Int32.Parse(minBox.Text) & Int32.Parse(maxBox.Text)) >= 0)
                {
                    if (Int32.Parse(maxBox.Text) > Int32.Parse(minBox.Text))
                    {
                        minBox.BackColor = System.Drawing.Color.White;
                        maxBox.BackColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        minBox.BackColor = System.Drawing.Color.MistyRose;
                        maxBox.BackColor = System.Drawing.Color.MistyRose;
                    }
                }
            }
            catch(System.FormatException)
            {
                string message = "The minimum must be less than the maximum.\nNeither field can be blank.";
                string caption = "Min VS Max";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }
        }

        private void checkBoxes_InvOK(Control minBox, Control maxBox, Control invBox)
        {
            try
            {
                if ((Int32.Parse(minBox.Text) & Int32.Parse(maxBox.Text)) >= 0)
                {
                    if((Int32.Parse(maxBox.Text) > Int32.Parse(invBox.Text)) & (Int32.Parse(invBox.Text) > Int32.Parse(minBox.Text)))
                    {
                        invBox.BackColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        invBox.BackColor = System.Drawing.Color.MistyRose;
                    }
                }
            }
            catch(System.FormatException)
            {
                string message = "Amount in Inventory must be between the Max and Minimum values. \nInventory cannot be empty.";
                string caption = "Inventory";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }
        }

        private void textBoxPartID_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_IntergersAP(textBoxPartID);
            button_SaveEnabledCheck();
        }

        private void textBoxPartInventory_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_IntergersAP(textBoxPartInventory);
            checkBoxes_InvOK(textBoxPartMin, textBoxPartMax, textBoxPartInventory);
            button_SaveEnabledCheck();
        }

        private void textBoxPartMax_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_IntergersAP(textBoxPartMax);
            checkBoxes_MinMax(textBoxPartMin, textBoxPartMax);
            button_SaveEnabledCheck();
        }

        private void textBoxPartMin_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_IntergersAP(textBoxPartMin);
            checkBoxes_MinMax(textBoxPartMin, textBoxPartMax);
            button_SaveEnabledCheck();
        }

        private void textBoxPartName_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_StringAP(textBoxPartName);
            button_SaveEnabledCheck();
        }

        private void textBoxPartPriceCost_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_DecimalAP(textBoxPartPriceCost);
            button_SaveEnabledCheck();
        }

        private void textBoxPartMachineID_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_RadioAP(textBoxPartMachineID);
            button_SaveEnabledCheck();
        }
    }
}
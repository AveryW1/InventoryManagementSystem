using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;

namespace InventoryManagementSystem
{
    public partial class ModifyParts : Form
    {
        //Binding list for controls
        private BindingList<Control> mpcontrols = new BindingList<Control>();

        //Properties created to access information from Main.cs
        public static Part currentPart { get; set; }
        public static int currentPartID { get; set; }
        public static int currentModIdx { get; set; }

        //Use variable for current part selected
        public ModifyParts() 
        {
            InitializeComponent();

            //Adds textboxes to list and disables save at load
            mpcontrols.Add(textBoxModifyID);
            mpcontrols.Add(textBoxModifyName);
            mpcontrols.Add(textBoxModifyPriceCost);
            mpcontrols.Add(textBoxModifyInventory);
            mpcontrols.Add(textBoxModifyMax);
            mpcontrols.Add(textBoxModifyMin);
            mpcontrols.Add(textBoxModifyMachineID);
            buttonModifySave.Enabled = false;


            //Delete this try/catch once program open auto select is completed.
            try
            {
                //Populates text boxes with current part information
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
            catch (NullReferenceException ex)
            {
                string message = "Please click on a part to edit from the list./n"+ ex.Message;
                string caption = "No Part Selected";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }
        }

        private void radioButtonModifyInHouse_CheckedChanged(object sender, EventArgs e)
        {
            labelModifyMacIDComNA.Text = "Machine ID";
            checkBoxes_RadioAP(textBoxModifyMachineID);
        }

        private void radioButtonModifyOutsourced_CheckedChanged(object sender, EventArgs e)
        {
            labelModifyMacIDComNA.Text = "Company Name";
            checkBoxes_RadioAP(textBoxModifyMachineID);

        }

        private void buttonModifyCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Checks part type, creates new part, calls fx to exchange parts.
        private void buttonModifySave_Click(object sender, EventArgs e)
        {
            if (currentPart is Inhouse)
            {
                currentPart = new Inhouse(Convert.ToInt32(textBoxModifyID.Text), textBoxModifyName.Text, Convert.ToDecimal(textBoxModifyPriceCost.Text), Convert.ToInt32(textBoxModifyInventory.Text), Convert.ToInt32(textBoxModifyMax.Text), Convert.ToInt32(textBoxModifyMin.Text), Convert.ToInt32(textBoxModifyMachineID.Text));
                Inventory.updatePart(currentModIdx, currentPart);
                this.Close();
            }
            else
            {
                currentPart = new Outsourced(Convert.ToInt32(textBoxModifyID.Text), textBoxModifyName.Text, Convert.ToDecimal(textBoxModifyPriceCost.Text), Convert.ToInt32(textBoxModifyInventory.Text), Convert.ToInt32(textBoxModifyMax.Text), Convert.ToInt32(textBoxModifyMin.Text), textBoxModifyMachineID.Text);
                Inventory.updatePart(currentModIdx, currentPart);
                this.Close();
            }
        }

        /*The below fucntions validate the textboxes and enables/disables save. 
        Iterates through list of controls and checks color of background.*/
        private void button_SaveEnabledCheck()
        {
            for (int i = 0; i < mpcontrols.Count; i++)
            {
                if (mpcontrols[i].BackColor != System.Drawing.Color.White)
                {
                    buttonModifySave.Enabled = false;
                    break;
                }
                else
                {
                    buttonModifySave.Enabled = true;
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
            if (radioButtonModifyOutsourced.Checked)
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
                        string message = "The maximum must be greater than the minimum.";
                        string caption = "Check Min VS Max";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result;
                        result = MessageBox.Show(message, caption, buttons);
                    }
                }
            }
            catch (System.FormatException)
            {
            }
        }

        //Checks if the value of inventory is between max/min.
        private void checkBoxes_InvOK(Control minBox, Control maxBox, Control invBox)
        {
            try
            {
                if ((Int32.Parse(minBox.Text) & Int32.Parse(maxBox.Text)) >= 0)
                {
                    if ((Int32.Parse(maxBox.Text) >= Int32.Parse(invBox.Text)) & (Int32.Parse(invBox.Text) >= Int32.Parse(minBox.Text)))
                    {
                        invBox.BackColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        invBox.BackColor = System.Drawing.Color.MistyRose;
                        string message = "Amount in Inventory must be between the Max and Minimum values. \nInventory cannot be empty.";
                        string caption = "Inventory";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result;
                        result = MessageBox.Show(message, caption, buttons);
                    }
                }
            }
            catch (System.FormatException)
            {

            }
        }

        //Text changed events to trigger validation.
        private void textBoxModifyID_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_IntergersAP(textBoxModifyID);
            button_SaveEnabledCheck();
        }

        private void textBoxModifyInventory_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_IntergersAP(textBoxModifyInventory);
            checkBoxes_InvOK(textBoxModifyMin, textBoxModifyMax, textBoxModifyInventory);
            button_SaveEnabledCheck();
        }

        private void textBoxModifyMax_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_IntergersAP(textBoxModifyMax);
            checkBoxes_MinMax(textBoxModifyMin, textBoxModifyMax);
            checkBoxes_InvOK(textBoxModifyMin, textBoxModifyMax, textBoxModifyInventory);
            button_SaveEnabledCheck();
        }

        private void textBoxModifyMin_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_IntergersAP(textBoxModifyMin);
            checkBoxes_MinMax(textBoxModifyMin, textBoxModifyMax);
            checkBoxes_InvOK(textBoxModifyMin, textBoxModifyMax, textBoxModifyInventory);
            button_SaveEnabledCheck();
        }

        private void textBoxModifyName_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_StringAP(textBoxModifyName);
            button_SaveEnabledCheck();
        }

        private void textBoxModifyPriceCost_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_DecimalAP(textBoxModifyPriceCost);
            button_SaveEnabledCheck();
        }

        private void textBoxModifyMachineID_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_RadioAP(textBoxModifyMachineID);
            button_SaveEnabledCheck();
        }

    }
}

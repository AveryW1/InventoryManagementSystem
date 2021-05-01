using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;

namespace InventoryManagementSystem
{
    public partial class ModifyProducts : Form
    {
        public static Product currentProduct { get; set; }
        public static int currentProductID { get; set; }
        public static int currentPModIdx { get; set; }

        int currentIdx = 0;
        Part currentPart = null;
        int currentAPIdx = 0;
        Part currentAPart = null;

        //Used to track textbox controls
        private BindingList<Control> mppcontrols = new BindingList<Control>();

        //Product tempProduct = null;
        public ModifyProducts()
        {
            InitializeComponent();
            dataGridViewMProducts.DataSource = Inventory.PartBL;
            dataGridViewAssoParts.DataSource = currentProduct.AssociatedParts;
            
            //Fills textboxes with current products information
            textBoxMProductID.Text = currentProduct.ProductID.ToString();
            textBoxMProductName.Text = currentProduct.Name;
            textBoxMProductInventory.Text = currentProduct.InStock.ToString();
            textBoxMProductPrice.Text = currentProduct.Price.ToString();
            textBoxMProductMax.Text = currentProduct.Max.ToString();
            textBoxMProductMin.Text = currentProduct.Min.ToString();

            //Adds controls to list for tracking
            mppcontrols.Add(textBoxMProductID);
            mppcontrols.Add(textBoxMProductName);
            mppcontrols.Add(textBoxMProductPrice);
            mppcontrols.Add(textBoxMProductInventory);
            mppcontrols.Add(textBoxMProductMax);
            mppcontrols.Add(textBoxMProductMin);
            buttonMProductsSave01.Enabled = false;
        }

        private void buttonMProductsCancel01_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //This will transfer the contents of the current product asso parts list to a holder then into newly created product.
        private void buttonMProductsSave01_Click(object sender, EventArgs e)
        {
            BindingList<Part> tempParts = new BindingList<Part>();
            tempParts = currentProduct.AssociatedParts;
            currentProduct = new Product(Convert.ToInt32(textBoxMProductID.Text), textBoxMProductName.Text, Convert.ToDecimal(textBoxMProductPrice.Text), Convert.ToInt32(textBoxMProductInventory.Text), Convert.ToInt32(textBoxMProductMin.Text), Convert.ToInt32(textBoxMProductMax.Text));
            Inventory.updateProduct(currentPModIdx, currentProduct);
            currentProduct.AssociatedParts = tempParts;
            this.Close();
        }

        //Tip to remember: This had to reference an instnce of the Product class (currentProduct) since Product is not static. 
        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            currentProduct.addAssociatedPart(currentPart);
        }
        
        //This is for PARTS not Products.
        private void dataGridViewMProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentIdx = dataGridViewMProducts.CurrentCell.RowIndex;
            
            for (int i = 0; i < Inventory.PartBL.Count; i++)
            {
                if (Inventory.PartBL[i].PartID == (int)dataGridViewMProducts.Rows[currentIdx].Cells[0].Value)
                {
                    currentPart = Inventory.PartBL[i];
                    break;
                }
            }
            button_SaveEnabledCheck();
        }

        private void buttonDeleteProduct_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to delete this part?";
            string caption = "Delete Associated Part?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (currentAPIdx >= 0)
                {
                    currentProduct.removeAssociatePart(currentAPIdx);
                    currentAPIdx = -1;
                }
                else
                {
                    string message1 = "Part not found. Please click a part in the list.";
                    string caption1 = "Failed";
                    MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                    DialogResult result1;
                    result1 = MessageBox.Show(message1, caption1, buttons1);
                }
            }
            button_SaveEnabledCheck();
        }

        private void dataGridViewAssoParts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentAPIdx = dataGridViewAssoParts.CurrentCell.RowIndex;

            for (int i = 0; i < currentProduct.AssociatedParts.Count; i++)
            {
                if (currentProduct.AssociatedParts[i].PartID == (int)dataGridViewAssoParts.Rows[currentAPIdx].Cells[0].Value)
                {
                    currentAPart = currentProduct.AssociatedParts[i];
                    break;
                }
            }
        }

        private void buttonSearchProducts01_Click(object sender, EventArgs e)
        {
            try
            {
                //Takes user input
                string userInput = textBoxSearchProducts01.Text.ToLower();
                Part searchResult = null;

                //Take name input, finds corresponding part ID from list, passes it to lookup, sets results as searchresults.
                for (int i = 0; i < currentProduct.AssociatedParts.Count; i++)
                {
                    if (userInput == currentProduct.AssociatedParts[i].Name.ToLower())
                    {
                        searchResult = currentProduct.lookupAssociatedPart(currentProduct.AssociatedParts[i].PartID);

                        //Finds the search result in the DGV.
                        for (int j = 0; j < currentProduct.AssociatedParts.Count; j++)
                        {
                            if (searchResult.PartID == (int)dataGridViewAssoParts.Rows[j].Cells[0].Value)
                            {
                                dataGridViewAssoParts.ClearSelection();
                                dataGridViewAssoParts.Rows[j].Selected = true;
                                break;
                            }
                        }
                    }
                }
                if (searchResult == null)
                {
                    string message2 = "Part not found by name OR a valid name not entered. \nPlease check your input";
                    string caption2 = "Check Input";
                    MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                    DialogResult result2;
                    result2 = MessageBox.Show(message2, caption2, buttons2);
                }
            }
            catch (System.FormatException)
            {
                string message = "Please enter the part name (A string).";
                string caption = "Please enter a name";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }
        }

        /*The below fucntions validate the textboxes and enables/disables save. 
        Iterates through list of controls and checks color of background.*/
        private void button_SaveEnabledCheck()
        {
            for (int i = 0; i < mppcontrols.Count; i++)
            {
                if (mppcontrols[i].BackColor != System.Drawing.Color.White)
                {
                    buttonMProductsSave01.Enabled = false;
                    break;
                }
                else
                {
                    buttonMProductsSave01.Enabled = true;
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

        private void textBoxMProductID_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_IntergersAP(textBoxMProductID);
            button_SaveEnabledCheck();
        }

        private void textBoxMProductInventory_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_IntergersAP(textBoxMProductInventory);
            checkBoxes_InvOK(textBoxMProductMin, textBoxMProductMax, textBoxMProductInventory);
            button_SaveEnabledCheck();
        }

        private void textBoxMProductMax_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_IntergersAP(textBoxMProductMax);
            checkBoxes_MinMax(textBoxMProductMin, textBoxMProductMax);
            checkBoxes_InvOK(textBoxMProductMin, textBoxMProductMax, textBoxMProductInventory);
            button_SaveEnabledCheck();
        }

        private void textBoxMProductMin_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_IntergersAP(textBoxMProductMin);
            checkBoxes_MinMax(textBoxMProductMin, textBoxMProductMax);
            checkBoxes_InvOK(textBoxMProductMin, textBoxMProductMax, textBoxMProductInventory);
            button_SaveEnabledCheck();
        }

        private void textBoxMProductName_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_StringAP(textBoxMProductName);
            button_SaveEnabledCheck();
        }

        private void textBoxMProductPrice_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_DecimalAP(textBoxMProductPrice);
            button_SaveEnabledCheck();
        }
    }
}

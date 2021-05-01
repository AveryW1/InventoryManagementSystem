using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class AddProducts : Form
    {
        int currentIdx = 0;
        Part currentPart = null;
        int currentAAIdx = 0;
        Part currentAAPart = null;

        private static Product currentProduct = null;

        //Used to track Product ids in use.
        List<int> ProductIDs = new List<int>();

        //Used to track textbox controls
        private BindingList<Control> appcontrols = new BindingList<Control>();

        public AddProducts()
        {
            InitializeComponent();
            buildDGVs();
            appcontrols.Add(textBoxProductID);
            appcontrols.Add(textBoxProductName);
            appcontrols.Add(textBoxProductPrice);
            appcontrols.Add(textBoxProductInventory);
            appcontrols.Add(textBoxProductMax);
            appcontrols.Add(textBoxProductMin);
            button_SaveEnabledCheck();
        }

        public void buildDGVs()
        {
            dataGridViewAParts.DataSource = Inventory.PartBL;
            dataGridViewAAParts.DataSource = null;
        }

        //Prevent adding doubles with if statement. check if id in use with if statement to check in popilated list
        private void buttonAddProductsSave01_Click(object sender, EventArgs e)
        {
            populateIDlist();
            try
            {
                if (currentProduct != null) 
                {
                    if ((currentProduct.ProductID == Convert.ToInt32(textBoxProductID.Text)) & (currentProduct.Name == textBoxProductName.Text))
                    {
                        this.Close();
                    }
                }
                
                if (ProductIDs.Contains(Convert.ToInt32(textBoxProductID.Text)))
                {
                    string message = "This product ID is currently in use. Please choose another ID.";
                    string caption = "ID in Use";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                }
                else
                {
                    try
                    {
                        Inventory.addProduct(new Product(Convert.ToInt32(textBoxProductID.Text), textBoxProductName.Text, Convert.ToInt32(textBoxProductPrice.Text), Convert.ToInt32(textBoxProductInventory.Text), Convert.ToInt32(textBoxProductMin.Text), Convert.ToInt32(textBoxProductMax.Text)));
                        this.Close();
                    }
                    catch (FormatException)
                    {
                        string message = "Please check the format of your inputs. ID, Inventory, Price, Min, max, and machineID are intergers.";
                        string caption = "Input Format Error";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result;
                        result = MessageBox.Show(message, caption, buttons);
                    }
                }
            }
            catch (FormatException)
            {
                string message1 = "Please check the format of your inputs. ID, Inventory, Price, Min, max, and machineID are intergers.";
                string caption1 = "Input Format Error";
                MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                DialogResult result1;
                result1 = MessageBox.Show(message1, caption1, buttons1);
            }
        }

        private void buttonAddProductsCancel01_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAddProductPart_Click(object sender, EventArgs e)
        {
            populateIDlist();

            //Checks if product with ID exist, if not, creates product and adds part.
            try
            {
                if (currentProduct != null)
                {
                    currentProduct.AssociatedParts.Add(currentPart);
                }
                else if (ProductIDs.Contains(Convert.ToInt32(textBoxProductID.Text)))
                {
                    string message = "This product ID is currently in use. \nIf you wish to edit the associated parts for this product, please use Modify instead.";
                    string caption = "ID in Use";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                }
                else
                {
                    currentProduct = new Product(Convert.ToInt32(textBoxProductID.Text), textBoxProductName.Text, Convert.ToInt32(textBoxProductPrice.Text), Convert.ToInt32(textBoxProductInventory.Text), Convert.ToInt32(textBoxProductMin.Text), Convert.ToInt32(textBoxProductMax.Text));
                    Inventory.addProduct(currentProduct);
                    currentProduct.AssociatedParts.Add(currentPart);
                    dataGridViewAAParts.DataSource = currentProduct.AssociatedParts;
                }
            }
            catch (System.FormatException)
            {
                string message = "Please enter a product ID.";
                string caption = "No ID";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }
        }

        private void dataGridViewAParts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentIdx = dataGridViewAParts.CurrentCell.RowIndex;

            for (int i = 0; i < Inventory.PartBL.Count; i++)
            {
                if (Inventory.PartBL[i].PartID == (int)dataGridViewAParts.Rows[currentIdx].Cells[0].Value)
                {
                    currentPart = Inventory.PartBL[i];
                    break;
                }
            }
        }

        //helper function. Creates a list of Product IDs to check for existing parts before making a new one.
        public void populateIDlist()
        {
            for (int i = 0; i < Inventory.ProductBL.Count; i++)
            {
                ProductIDs.Add(Inventory.ProductBL[i].ProductID);
            }
        }

        //Deletes associated Part NOT PRODUCT!
        private void buttonDeleteProducts01_Click(object sender, EventArgs e)
        {
            if (currentPart != null)
            {
                string message = "Are you sure you want to delete this part?";
                string caption = "Delete Associated Part?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    for (int i = 0; i < Inventory.ProductBL.Count; i++)
                    {
                        if (Inventory.ProductBL[i].ProductID == Convert.ToInt32(textBoxProductID.Text))
                        {
                            Inventory.ProductBL[i].AssociatedParts.Remove(currentAAPart);
                            break;
                        }
                    }
                }
            }
            else
            {
                string message2 = "No part selected.";
                string caption2 = "Select Part";
                MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                DialogResult result2;
                result2 = MessageBox.Show(message2, caption2, buttons2);
            }
            button_SaveEnabledCheck();
        }

        private void dataGridViewAAParts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentAAIdx = dataGridViewAAParts.CurrentCell.RowIndex;

            for (int i = 0; i < Inventory.PartBL.Count; i++)
            {
                if (Inventory.PartBL[i].PartID == (int)dataGridViewAAParts.Rows[currentAAIdx].Cells[0].Value)
                {
                    currentAAPart = Inventory.PartBL[i];
                    break;
                }
            }
        }

        private void buttonSearchAssoPart_Click(object sender, EventArgs e)
        {
            try
            {
                //Takes user input
                string userInput = textBoxSearchAssoPart.Text.ToLower();
                Part searchResult = null;

                //Take name input, finds corresponding part ID from list, passes it to lookup, sets results as searchresults.
                for (int i = 0; i < Product.currentProduct.AssociatedParts.Count; i++)
                {
                    if (userInput == Product.currentProduct.AssociatedParts[i].Name.ToLower())
                    {
                        searchResult = Product.currentProduct.lookupAssociatedPart(Product.currentProduct.AssociatedParts[i].PartID);

                        //Finds the search result in the DGV.
                        for (int j = 0; j < Product.currentProduct.AssociatedParts.Count; j++)
                        {
                            if (searchResult.PartID == (int)dataGridViewAAParts.Rows[j].Cells[0].Value)
                            {
                                dataGridViewAAParts.ClearSelection();
                                dataGridViewAAParts.Rows[j].Selected = true;
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

        /*The below fucntions validate the textboxes and enables/disables save/add. 
        Iterates through list of controls and checks color of background.*/
        private void button_SaveEnabledCheck()
        {
            for (int i = 0; i < appcontrols.Count; i++)
            {
                if (appcontrols[i].BackColor != System.Drawing.Color.White)
                {
                    buttonAddProductsSave01.Enabled = false;
                    buttonAddProductPart.Enabled = false;
                    break;
                }
                else
                {
                    buttonAddProductsSave01.Enabled = true;
                    buttonAddProductPart.Enabled = true;
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

        private void textBoxProductID_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_IntergersAP(textBoxProductID);
            button_SaveEnabledCheck();
        }

        private void textBoxProductInventory_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_IntergersAP(textBoxProductInventory);
            checkBoxes_InvOK(textBoxProductMin, textBoxProductMax, textBoxProductInventory);
            button_SaveEnabledCheck();
        }

        private void textBoxProductMax_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_IntergersAP(textBoxProductMax);
            checkBoxes_MinMax(textBoxProductMin, textBoxProductMax);
            checkBoxes_InvOK(textBoxProductMin, textBoxProductMax, textBoxProductInventory);
            button_SaveEnabledCheck();
        }

        private void textBoxProductMin_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_IntergersAP(textBoxProductMin);
            checkBoxes_MinMax(textBoxProductMin, textBoxProductMax);
            checkBoxes_InvOK(textBoxProductMin, textBoxProductMax, textBoxProductInventory);
            button_SaveEnabledCheck();
        }

        private void textBoxProductName_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_StringAP(textBoxProductName);
            button_SaveEnabledCheck();
        }

        private void textBoxProductPrice_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_DecimalAP(textBoxProductPrice);
            button_SaveEnabledCheck();
        }
    }
}
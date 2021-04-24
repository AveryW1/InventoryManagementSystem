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
        Product currentProduct = null;

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
            buttonAddProductsSave01.Enabled = false;
        }

        public void buildDGVs()
        {
            dataGridViewAParts.DataSource = Inventory.PartBL;
            dataGridViewAAParts.DataSource = null;
        }

        //Prevent adding doubles with if statement
        private void buttonAddProductsSave01_Click(object sender, EventArgs e)
        {
            populateIDlist();
            
            if (ProductIDs.Contains(Convert.ToInt32(textBoxProductID.Text))) 
            {
                this.Close();
            }
            else
            {
                try
                {
                    Inventory.addProduct(new Product(Convert.ToInt32(textBoxProductID.Text), textBoxProductName.Text, Convert.ToInt32(textBoxProductPrice.Text), Convert.ToInt32(textBoxProductInventory.Text), Convert.ToInt32(textBoxProductMax.Text), Convert.ToInt32(textBoxProductMin.Text)));
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

        private void buttonAddProductsCancel01_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAddProductPart_Click(object sender, EventArgs e)
        {
            populateIDlist();

            //Needs exception handling for when user tries to add associated part with no text input in product iD
            if (ProductIDs.Contains(Convert.ToInt32(textBoxProductID.Text)))
            {
                for (int i = 0; i < Inventory.ProductBL.Count; i++)
                {
                    if (Inventory.ProductBL[i].ProductID == Convert.ToInt32(textBoxProductID.Text))
                    {
                        Inventory.ProductBL[i].AssociatedParts.Add(currentPart);
                    }
                }
                //Sets current product
                findCurrentProduct();
            }
            else
            {
                Product tempProduct = new Product(Convert.ToInt32(textBoxProductID.Text), textBoxProductName.Text, Convert.ToInt32(textBoxProductPrice.Text), Convert.ToInt32(textBoxProductInventory.Text), Convert.ToInt32(textBoxProductMax.Text), Convert.ToInt32(textBoxProductMin.Text));
                Inventory.addProduct(tempProduct);
                tempProduct.AssociatedParts.Add(currentPart);
                dataGridViewAAParts.DataSource = tempProduct.AssociatedParts;
                findCurrentProduct();
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
            string message = "Are you sure you want to delete this part?";
            string caption = "Delete Associated Part?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
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
                catch
                {
                    string message2 = "Please select a part in the associated parts list.";
                    string caption2 = "Select Part";
                    MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                    DialogResult result2;
                    result2 = MessageBox.Show(message2, caption2, buttons2);
                }
            }
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

        //Helper Function. Sets current Product for later use.
        private void findCurrentProduct()
        {
            for (int i = 0; i < Inventory.ProductBL.Count; i++)
            {
                if (Inventory.ProductBL[i].ProductID == Convert.ToInt32(textBoxProductID.Text))
                {
                    currentProduct = Inventory.ProductBL[i];
                }
            }
        }

        /*The below fucntions validate the textboxes and enables/disables save. 
        Iterates through list of controls and checks color of background.*/
        private void button_SaveEnabledCheck()
        {
            for (int i = 0; i < appcontrols.Count; i++)
            {
                if (appcontrols[i].BackColor != System.Drawing.Color.White)
                {
                    buttonAddProductsSave01.Enabled = false;
                    break;
                }
                else
                {
                    buttonAddProductsSave01.Enabled = true;
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

        private void textBoxProductID_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_IntergersAP(textBoxProductID);
            button_SaveEnabledCheck();
        }

        private void textBoxProductInventory_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_IntergersAP(textBoxProductInventory);
            button_SaveEnabledCheck();
        }

        private void textBoxProductMax_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_IntergersAP(textBoxProductMax);
            button_SaveEnabledCheck();
        }

        private void textBoxProductMin_TextChanged(object sender, System.EventArgs e)
        {
            checkBoxes_IntergersAP(textBoxProductMin);
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
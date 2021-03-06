using System;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class Main : Form
    {
        //This variable serves as a control for the add parts button click event
        AddParts ap;
        ModifyParts mp;
        AddProducts apr;
        ModifyProducts mpr;

        //These variables are used by the program to "remember" what is selected in the DGVs.
        int currentIdx = 0;
        int currentPIdx = 0;
        Part currentObj = null;
        Product currentPObj = null;

        //This function creates the Binding List for Parts /w prepopulated data from Inventory.
        private void buildBindingParts()
        {
            dataGridViewParts.DataSource = Inventory.PartBL;
        }

        private void buildBindingProducts()
        {
            dataGridViewProducts.DataSource = Inventory.ProductBL;
        }

        public Main()
        {
            InitializeComponent();
            buildBindingParts();
            buildBindingProducts();
        }

        //Helper function: Shows Add Part screen.
        public void showAddParts()
        {
            if (ap == null)
            {
                ap = new AddParts();
                ap.FormClosed += new FormClosedEventHandler(ap_FormClosed);
                ap.Show();
            }
            else
                ap.Activate();
        }

        void ap_FormClosed(object sender, FormClosedEventArgs e)
        {
            ap = null;
        }

        //Helper function: Shows Modify Parts screen.
        public void showModifyParts()
        {
            if (mp == null)
            {
                mp = new ModifyParts();
                mp.FormClosed += new FormClosedEventHandler(mp_FormClosed);
                mp.Show();
            }
            else
                mp.Activate();
        }
        void mp_FormClosed(object sender, FormClosedEventArgs e)
        {
            mp = null;
        }

        public void showAddProducts()
        {
            if (apr == null)
            {
                apr = new AddProducts();
                apr.FormClosed += new FormClosedEventHandler(apr_FormClosed);
                apr.Show();
            }
            else
                apr.Activate();
        }

        void apr_FormClosed(object sender, FormClosedEventArgs e)
        {
            apr = null;
        }

        public void showModifyProducts()
        {
            if (mpr == null)
            {
                mpr = new ModifyProducts();
                mpr.FormClosed += new FormClosedEventHandler(mpr_FormClosed);
                mpr.Show();
            }
            else
                mpr.Activate();
        }
        void mpr_FormClosed(object sender, FormClosedEventArgs e)
        {
            mpr = null;
        }

        //Brings up only 1 instance of Add part window. Option to hide main if wanted. NO MDI needed.
        private void buttonAddParts_Click(object sender, EventArgs e)
        {
            showAddParts();
        }

        //Using partID to link currentIdx with the desired object from PartBL.
        private void dataGridViewParts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentIdx = dataGridViewParts.CurrentCell.RowIndex;
            
            for (int i = 0; i < Inventory.PartBL.Count; i++)
            {
                if (Inventory.PartBL[i].PartID == (int)dataGridViewParts.Rows[currentIdx].Cells[0].Value)
                {
                    currentObj = Inventory.PartBL[i];
                    break;
                }
            }
            
            //The code below should never have to run due to the break function but if so we get a popup for it.
            //Alt, throw an exception so that it can be traced in the log for the developer to check.
            //Might need to do similar for products.
            if (currentObj == null)
            {
                string message = "Part was not found within the bounds of the PartBL array.";
                string caption = "Part not found";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }

            //Lets ModifyParts know the selected part to edit for update Parts.
            //Might need to do similar for products.
            ModifyParts.currentPartID = (int)dataGridViewParts.Rows[currentIdx].Cells[0].Value;
            ModifyParts.currentPart = currentObj;
            ModifyParts.currentModIdx = currentIdx;
        }

        private void buttonDeleteParts_Click(object sender, EventArgs e) 
        {
            string message = "Are you sure you want to delete this part?";
            string caption = "Delete Part?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (currentIdx >= 0)
                {
                    for (int i = 0; i < Inventory.PartBL.Count; i++)
                    {
                        if (Inventory.PartBL[i].PartID == (int)dataGridViewParts.Rows[currentIdx].Cells[0].Value)
                        {
                            Inventory.deletePart(Inventory.PartBL[i]);
                        }
                    }
                    currentIdx = -1;
                }
            }
        }

        //Add parts shows, data of currentObj shows, edit data, ask confirm, update list obj.property = newData, 
        private void buttonModifyParts_Click(object sender, EventArgs e) 
        {
            if (!(currentObj is null))
            {
                showModifyParts();
            }
            else
            {
                string message = "Please click a part to modify";
                string caption = "Modify Which Part?";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }
        }

        private void buttonExitFromMain_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Button click takes in partID, returns part, checks the list where id matches result, and highlights result.
        //add try catch for system.formatexception or disable search unless int is entered.
        //FINISH THIS search through DGV
        private void buttonSearchParts_Click(object sender, EventArgs e)
        {
            try
            {
                //Takes user input
                string userInput = textBoxSearchParts01.Text.ToLower();
                Part searchResult = null;

                //Take name input, finds corresponding part ID from list, passes it to lookup, sets results as searchresults.
                for (int i = 0; i < Inventory.PartBL.Count; i++)
                {
                    if (userInput == Inventory.PartBL[i].Name.ToLower())
                    {
                        searchResult = Inventory.lookupPart(Inventory.PartBL[i].PartID);

                        //Finds the search result in the DGV.
                        for (int j = 0; j < Inventory.PartBL.Count; j++)
                        {
                            if (searchResult.PartID == (int)dataGridViewParts.Rows[j].Cells[0].Value)
                            {
                                dataGridViewParts.ClearSelection();
                                dataGridViewParts.Rows[j].Selected = true;
                                break;
                            }
                        }
                    }
                }
                if (searchResult == null)
                {
                    string message2 = "Part not found by name OR a valid name not entered. \n Please check your input";
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

        private void dataGridViewProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentPIdx = dataGridViewProducts.CurrentCell.RowIndex;

            for (int i = 0; i < Inventory.ProductBL.Count; i++)
            {
                if (Inventory.ProductBL[i].ProductID == (int)dataGridViewProducts.Rows[currentPIdx].Cells[0].Value)
                {
                    currentPObj = Inventory.ProductBL[i];
                    break;
                }
            }
            ModifyProducts.currentProductID = (int)dataGridViewProducts.Rows[currentPIdx].Cells[0].Value;
            ModifyProducts.currentProduct = currentPObj;
            Product.currentProduct = currentPObj;
            ModifyProducts.currentPModIdx = currentPIdx;
        }

        private void buttonAddProducts_Click(object sender, EventArgs e)
        {
            showAddProducts();
        }

        private void buttonDeleteProducts_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to delete this product?";
            string caption = "Delete Product?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (currentPIdx >= 0)
                {
                    //Can't use currentPObj here since removeProduct requires type INT. Requirements constraint.
                    for (int i = 0; i < Inventory.ProductBL.Count; i++)
                    {
                        if (Inventory.ProductBL[i].ProductID == (int)dataGridViewProducts.Rows[currentPIdx].Cells[0].Value)
                        {
                            //Checks if Associated parts list is populated. Prevents delete if so.
                            if (Inventory.ProductBL[i].AssociatedParts.Count == 0)
                            {
                                Inventory.removeProduct(i);
                            }
                            else
                            {
                                string message1 = "Product has associated parts. Please delete the parts to delete the product.";
                                string caption1 = "Product has Associated Parts";
                                MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                                DialogResult result1;
                                result1 = MessageBox.Show(message1, caption1, buttons1);
                            }
                            
                        }
                    }
                    currentPIdx = -1;
                }
            }
        }
        private void buttonModifyProducts_Click(object sender, EventArgs e)
        {
            if (!(currentPObj is null)) 
            {
                showModifyProducts(); 
            }
            else
            {
                string message = "Please click a product to modify";
                string caption = "Modify Which Product?";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }
        }

        private void buttonSearchProducts_Click(object sender, EventArgs e)
        {
            try
            {
                //Takes user input
                string userInput = textBoxSearchProducts01.Text.ToLower();
                Product searchResult = null;

                //Take name input, finds corresponding part ID from list, passes it to lookup, sets results as searchresults.
                for (int i = 0; i < Inventory.ProductBL.Count; i++)
                {
                    if (userInput == Inventory.ProductBL[i].Name.ToLower())
                    {
                        searchResult = Inventory.lookupProduct(Inventory.ProductBL[i].ProductID);

                        //Finds the search result in the DGV.
                        for (int j = 0; j < Inventory.ProductBL.Count; j++)
                        {
                            if (searchResult.ProductID == (int)dataGridViewProducts.Rows[j].Cells[0].Value)
                            {
                                dataGridViewProducts.ClearSelection();
                                dataGridViewProducts.Rows[j].Selected = true;
                                break;
                            }
                        }
                    }
                }
                if (searchResult == null)
                {
                    string message2 = "Product not found by name OR a valid name not entered. \n Please check your input";
                    string caption2 = "Check Input";
                    MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                    DialogResult result2;
                    result2 = MessageBox.Show(message2, caption2, buttons2);
                }
            }
            catch (System.FormatException)
            {
                string message = "Please enter the product name (A string).";
                string caption = "Please enter a name";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }

            //try
            //{
            //    Product searchResult = Inventory.lookupProduct(Int32.Parse(textBoxSearchProducts01.Text));
            //    for (int i = 0; i < Inventory.ProductBL.Count; i++)
            //    {
            //        if (Inventory.ProductBL[i] == searchResult)
            //        {
            //            dataGridViewProducts.ClearSelection();
            //            dataGridViewProducts.Rows[i].Selected = true;
            //        }
            //    }
            //}
            //catch (System.FormatException)
            //{
            //    string message = "Please enter the product ID";
            //    string caption = "Enter a Product ID (a number)";
            //    MessageBoxButtons buttons = MessageBoxButtons.OK;
            //    DialogResult result;
            //    result = MessageBox.Show(message, caption, buttons);
            //}
        }
    }
}


namespace InventoryManagementSystem
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelMainScreen = new System.Windows.Forms.Label();
            this.labelPartsDGV = new System.Windows.Forms.Label();
            this.labelProductsDGV = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewParts = new System.Windows.Forms.DataGridView();
            this.buttonSearchParts = new System.Windows.Forms.Button();
            this.textBoxSearchParts01 = new System.Windows.Forms.TextBox();
            this.buttonDeleteParts = new System.Windows.Forms.Button();
            this.buttonModifyParts = new System.Windows.Forms.Button();
            this.buttonAddParts = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.buttonSearchProducts = new System.Windows.Forms.Button();
            this.textBoxSearchProducts01 = new System.Windows.Forms.TextBox();
            this.buttonDeleteProducts = new System.Windows.Forms.Button();
            this.buttonModifyProducts = new System.Windows.Forms.Button();
            this.buttonAddProducts = new System.Windows.Forms.Button();
            this.buttonExitFromMain = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParts)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMainScreen
            // 
            this.labelMainScreen.AutoSize = true;
            this.labelMainScreen.BackColor = System.Drawing.Color.Silver;
            this.labelMainScreen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelMainScreen.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelMainScreen.Location = new System.Drawing.Point(12, 9);
            this.labelMainScreen.Name = "labelMainScreen";
            this.labelMainScreen.Size = new System.Drawing.Size(334, 31);
            this.labelMainScreen.TabIndex = 0;
            this.labelMainScreen.Text = "Inventory Management System";
            // 
            // labelPartsDGV
            // 
            this.labelPartsDGV.AutoSize = true;
            this.labelPartsDGV.BackColor = System.Drawing.Color.Silver;
            this.labelPartsDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelPartsDGV.Location = new System.Drawing.Point(293, 15);
            this.labelPartsDGV.Name = "labelPartsDGV";
            this.labelPartsDGV.Size = new System.Drawing.Size(51, 24);
            this.labelPartsDGV.TabIndex = 1;
            this.labelPartsDGV.Text = "Parts";
            // 
            // labelProductsDGV
            // 
            this.labelProductsDGV.AutoSize = true;
            this.labelProductsDGV.BackColor = System.Drawing.Color.Silver;
            this.labelProductsDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelProductsDGV.Location = new System.Drawing.Point(298, 15);
            this.labelProductsDGV.Name = "labelProductsDGV";
            this.labelProductsDGV.Size = new System.Drawing.Size(80, 24);
            this.labelProductsDGV.TabIndex = 2;
            this.labelProductsDGV.Text = "Products";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewParts);
            this.panel1.Controls.Add(this.buttonSearchParts);
            this.panel1.Controls.Add(this.textBoxSearchParts01);
            this.panel1.Controls.Add(this.buttonDeleteParts);
            this.panel1.Controls.Add(this.buttonModifyParts);
            this.panel1.Controls.Add(this.buttonAddParts);
            this.panel1.Controls.Add(this.labelPartsDGV);
            this.panel1.Location = new System.Drawing.Point(13, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 450);
            this.panel1.TabIndex = 3;
            // 
            // dataGridViewParts
            // 
            this.dataGridViewParts.AllowUserToAddRows = false;
            this.dataGridViewParts.AllowUserToDeleteRows = false;
            this.dataGridViewParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewParts.Location = new System.Drawing.Point(20, 54);
            this.dataGridViewParts.Name = "dataGridViewParts";
            this.dataGridViewParts.RowHeadersVisible = false;
            this.dataGridViewParts.RowTemplate.Height = 25;
            this.dataGridViewParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewParts.Size = new System.Drawing.Size(655, 336);
            this.dataGridViewParts.TabIndex = 8;
            this.dataGridViewParts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewParts_CellClick);
            // 
            // buttonSearchParts
            // 
            this.buttonSearchParts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSearchParts.Location = new System.Drawing.Point(20, 396);
            this.buttonSearchParts.Name = "buttonSearchParts";
            this.buttonSearchParts.Size = new System.Drawing.Size(75, 27);
            this.buttonSearchParts.TabIndex = 7;
            this.buttonSearchParts.Text = "Search";
            this.buttonSearchParts.UseVisualStyleBackColor = true;
            this.buttonSearchParts.Click += new System.EventHandler(this.buttonSearchParts_Click);
            // 
            // textBoxSearchParts01
            // 
            this.textBoxSearchParts01.Location = new System.Drawing.Point(101, 394);
            this.textBoxSearchParts01.Name = "textBoxSearchParts01";
            this.textBoxSearchParts01.PlaceholderText = "Search by Part ID here";
            this.textBoxSearchParts01.Size = new System.Drawing.Size(253, 29);
            this.textBoxSearchParts01.TabIndex = 6;
            // 
            // buttonDeleteParts
            // 
            this.buttonDeleteParts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDeleteParts.Location = new System.Drawing.Point(600, 396);
            this.buttonDeleteParts.Name = "buttonDeleteParts";
            this.buttonDeleteParts.Size = new System.Drawing.Size(75, 29);
            this.buttonDeleteParts.TabIndex = 4;
            this.buttonDeleteParts.Text = "Delete";
            this.buttonDeleteParts.UseVisualStyleBackColor = true;
            this.buttonDeleteParts.Click += new System.EventHandler(this.buttonDeleteParts_Click);
            // 
            // buttonModifyParts
            // 
            this.buttonModifyParts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonModifyParts.Location = new System.Drawing.Point(520, 396);
            this.buttonModifyParts.Name = "buttonModifyParts";
            this.buttonModifyParts.Size = new System.Drawing.Size(74, 29);
            this.buttonModifyParts.TabIndex = 3;
            this.buttonModifyParts.Text = "Modify";
            this.buttonModifyParts.UseVisualStyleBackColor = true;
            this.buttonModifyParts.Click += new System.EventHandler(this.buttonModifyParts_Click);
            // 
            // buttonAddParts
            // 
            this.buttonAddParts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAddParts.Location = new System.Drawing.Point(463, 396);
            this.buttonAddParts.Name = "buttonAddParts";
            this.buttonAddParts.Size = new System.Drawing.Size(51, 29);
            this.buttonAddParts.TabIndex = 2;
            this.buttonAddParts.Text = "Add";
            this.buttonAddParts.UseVisualStyleBackColor = true;
            this.buttonAddParts.Click += new System.EventHandler(this.buttonAddParts_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewProducts);
            this.panel2.Controls.Add(this.buttonSearchProducts);
            this.panel2.Controls.Add(this.textBoxSearchProducts01);
            this.panel2.Controls.Add(this.buttonDeleteProducts);
            this.panel2.Controls.Add(this.buttonModifyProducts);
            this.panel2.Controls.Add(this.buttonAddProducts);
            this.panel2.Controls.Add(this.labelProductsDGV);
            this.panel2.Location = new System.Drawing.Point(750, 104);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(700, 450);
            this.panel2.TabIndex = 4;
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.AllowUserToAddRows = false;
            this.dataGridViewProducts.AllowUserToDeleteRows = false;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewProducts.Location = new System.Drawing.Point(18, 54);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.RowHeadersVisible = false;
            this.dataGridViewProducts.RowTemplate.Height = 25;
            this.dataGridViewProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProducts.Size = new System.Drawing.Size(655, 336);
            this.dataGridViewProducts.TabIndex = 11;
            this.dataGridViewProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProducts_CellClick);
            // 
            // buttonSearchProducts
            // 
            this.buttonSearchProducts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSearchProducts.Location = new System.Drawing.Point(18, 394);
            this.buttonSearchProducts.Name = "buttonSearchProducts";
            this.buttonSearchProducts.Size = new System.Drawing.Size(75, 27);
            this.buttonSearchProducts.TabIndex = 10;
            this.buttonSearchProducts.Text = "Search";
            this.buttonSearchProducts.UseVisualStyleBackColor = true;
            this.buttonSearchProducts.Click += new System.EventHandler(this.buttonSearchProducts_Click);
            // 
            // textBoxSearchProducts01
            // 
            this.textBoxSearchProducts01.Location = new System.Drawing.Point(99, 394);
            this.textBoxSearchProducts01.Name = "textBoxSearchProducts01";
            this.textBoxSearchProducts01.PlaceholderText = "Search by Product ID here";
            this.textBoxSearchProducts01.Size = new System.Drawing.Size(253, 29);
            this.textBoxSearchProducts01.TabIndex = 9;
            // 
            // buttonDeleteProducts
            // 
            this.buttonDeleteProducts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDeleteProducts.Location = new System.Drawing.Point(597, 396);
            this.buttonDeleteProducts.Name = "buttonDeleteProducts";
            this.buttonDeleteProducts.Size = new System.Drawing.Size(75, 29);
            this.buttonDeleteProducts.TabIndex = 7;
            this.buttonDeleteProducts.Text = "Delete";
            this.buttonDeleteProducts.UseVisualStyleBackColor = true;
            this.buttonDeleteProducts.Click += new System.EventHandler(this.buttonDeleteProducts_Click);
            // 
            // buttonModifyProducts
            // 
            this.buttonModifyProducts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonModifyProducts.Location = new System.Drawing.Point(517, 396);
            this.buttonModifyProducts.Name = "buttonModifyProducts";
            this.buttonModifyProducts.Size = new System.Drawing.Size(74, 29);
            this.buttonModifyProducts.TabIndex = 6;
            this.buttonModifyProducts.Text = "Modify";
            this.buttonModifyProducts.UseVisualStyleBackColor = true;
            this.buttonModifyProducts.Click += new System.EventHandler(this.buttonModifyProducts_Click);
            // 
            // buttonAddProducts
            // 
            this.buttonAddProducts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAddProducts.Location = new System.Drawing.Point(460, 396);
            this.buttonAddProducts.Name = "buttonAddProducts";
            this.buttonAddProducts.Size = new System.Drawing.Size(51, 29);
            this.buttonAddProducts.TabIndex = 5;
            this.buttonAddProducts.Text = "Add";
            this.buttonAddProducts.UseVisualStyleBackColor = true;
            this.buttonAddProducts.Click += new System.EventHandler(this.buttonAddProducts_Click);
            // 
            // buttonExitFromMain
            // 
            this.buttonExitFromMain.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonExitFromMain.Location = new System.Drawing.Point(1347, 560);
            this.buttonExitFromMain.Name = "buttonExitFromMain";
            this.buttonExitFromMain.Size = new System.Drawing.Size(75, 25);
            this.buttonExitFromMain.TabIndex = 5;
            this.buttonExitFromMain.Text = "Exit";
            this.buttonExitFromMain.UseVisualStyleBackColor = true;
            this.buttonExitFromMain.Click += new System.EventHandler(this.buttonExitFromMain_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1461, 599);
            this.Controls.Add(this.buttonExitFromMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelMainScreen);
            this.Font = new System.Drawing.Font("Candara", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParts)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMainScreen;
        private System.Windows.Forms.Label labelPartsDGV;
        private System.Windows.Forms.Label labelProductsDGV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonModifyParts;
        private System.Windows.Forms.Button buttonAddParts;
        private System.Windows.Forms.Button buttonDeleteParts;
        private System.Windows.Forms.Button buttonDeleteProducts;
        private System.Windows.Forms.Button buttonModifyProducts;
        private System.Windows.Forms.Button buttonAddProducts;
        private System.Windows.Forms.Button buttonExitFromMain;
        private System.Windows.Forms.TextBox textBoxSearchParts01;
        private System.Windows.Forms.TextBox textBoxSearchProducts01;
        private System.Windows.Forms.Button buttonSearchParts;
        private System.Windows.Forms.Button buttonSearchProducts;
        private System.Windows.Forms.DataGridView dataGridViewParts;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
    }
}


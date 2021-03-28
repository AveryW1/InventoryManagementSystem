
namespace InventoryManagementSystem
{
    partial class Form1
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
            this.buttonModifyParts = new System.Windows.Forms.Button();
            this.buttonAddParts = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonDeleteParts = new System.Windows.Forms.Button();
            this.buttonDeleteProducts = new System.Windows.Forms.Button();
            this.buttonModifyProducts = new System.Windows.Forms.Button();
            this.buttonAddProducts = new System.Windows.Forms.Button();
            this.buttonExitFromMain = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelMainScreen
            // 
            this.labelMainScreen.AutoSize = true;
            this.labelMainScreen.BackColor = System.Drawing.Color.Silver;
            this.labelMainScreen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelMainScreen.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelMainScreen.Location = new System.Drawing.Point(13, 13);
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
            this.labelPartsDGV.Click += new System.EventHandler(this.labelPartsDGV_Click);
            // 
            // labelProductsDGV
            // 
            this.labelProductsDGV.AutoSize = true;
            this.labelProductsDGV.BackColor = System.Drawing.Color.Silver;
            this.labelProductsDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelProductsDGV.Location = new System.Drawing.Point(293, 15);
            this.labelProductsDGV.Name = "labelProductsDGV";
            this.labelProductsDGV.Size = new System.Drawing.Size(80, 24);
            this.labelProductsDGV.TabIndex = 2;
            this.labelProductsDGV.Text = "Products";
            this.labelProductsDGV.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonDeleteParts);
            this.panel1.Controls.Add(this.buttonModifyParts);
            this.panel1.Controls.Add(this.buttonAddParts);
            this.panel1.Controls.Add(this.labelPartsDGV);
            this.panel1.Location = new System.Drawing.Point(13, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 450);
            this.panel1.TabIndex = 3;
            // 
            // buttonModifyParts
            // 
            this.buttonModifyParts.Location = new System.Drawing.Point(520, 396);
            this.buttonModifyParts.Name = "buttonModifyParts";
            this.buttonModifyParts.Size = new System.Drawing.Size(74, 29);
            this.buttonModifyParts.TabIndex = 3;
            this.buttonModifyParts.Text = "Modify";
            this.buttonModifyParts.UseVisualStyleBackColor = true;
            // 
            // buttonAddParts
            // 
            this.buttonAddParts.Location = new System.Drawing.Point(464, 396);
            this.buttonAddParts.Name = "buttonAddParts";
            this.buttonAddParts.Size = new System.Drawing.Size(51, 29);
            this.buttonAddParts.TabIndex = 2;
            this.buttonAddParts.Text = "Add";
            this.buttonAddParts.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonDeleteProducts);
            this.panel2.Controls.Add(this.buttonModifyProducts);
            this.panel2.Controls.Add(this.buttonAddProducts);
            this.panel2.Controls.Add(this.labelProductsDGV);
            this.panel2.Location = new System.Drawing.Point(777, 104);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(700, 450);
            this.panel2.TabIndex = 4;
            // 
            // buttonDeleteParts
            // 
            this.buttonDeleteParts.Location = new System.Drawing.Point(601, 396);
            this.buttonDeleteParts.Name = "buttonDeleteParts";
            this.buttonDeleteParts.Size = new System.Drawing.Size(75, 29);
            this.buttonDeleteParts.TabIndex = 4;
            this.buttonDeleteParts.Text = "Delete";
            this.buttonDeleteParts.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteProducts
            // 
            this.buttonDeleteProducts.Location = new System.Drawing.Point(598, 396);
            this.buttonDeleteProducts.Name = "buttonDeleteProducts";
            this.buttonDeleteProducts.Size = new System.Drawing.Size(75, 29);
            this.buttonDeleteProducts.TabIndex = 7;
            this.buttonDeleteProducts.Text = "Delete";
            this.buttonDeleteProducts.UseVisualStyleBackColor = true;
            // 
            // buttonModifyProducts
            // 
            this.buttonModifyProducts.Location = new System.Drawing.Point(517, 396);
            this.buttonModifyProducts.Name = "buttonModifyProducts";
            this.buttonModifyProducts.Size = new System.Drawing.Size(74, 29);
            this.buttonModifyProducts.TabIndex = 6;
            this.buttonModifyProducts.Text = "Modify";
            this.buttonModifyProducts.UseVisualStyleBackColor = true;
            // 
            // buttonAddProducts
            // 
            this.buttonAddProducts.Location = new System.Drawing.Point(461, 396);
            this.buttonAddProducts.Name = "buttonAddProducts";
            this.buttonAddProducts.Size = new System.Drawing.Size(51, 29);
            this.buttonAddProducts.TabIndex = 5;
            this.buttonAddProducts.Text = "Add";
            this.buttonAddProducts.UseVisualStyleBackColor = true;
            // 
            // buttonExitFromMain
            // 
            this.buttonExitFromMain.Location = new System.Drawing.Point(1375, 570);
            this.buttonExitFromMain.Name = "buttonExitFromMain";
            this.buttonExitFromMain.Size = new System.Drawing.Size(75, 34);
            this.buttonExitFromMain.TabIndex = 5;
            this.buttonExitFromMain.Text = "Exit";
            this.buttonExitFromMain.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1499, 616);
            this.Controls.Add(this.buttonExitFromMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelMainScreen);
            this.Font = new System.Drawing.Font("Candara", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
    }
}


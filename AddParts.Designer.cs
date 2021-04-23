
namespace InventoryManagementSystem
{
    partial class AddParts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelAddParts = new System.Windows.Forms.Panel();
            this.textBoxPartMin = new System.Windows.Forms.TextBox();
            this.textBoxPartMax = new System.Windows.Forms.TextBox();
            this.textBoxPartMachineID = new System.Windows.Forms.TextBox();
            this.textBoxPartPriceCost = new System.Windows.Forms.TextBox();
            this.textBoxPartName = new System.Windows.Forms.TextBox();
            this.textBoxPartInventory = new System.Windows.Forms.TextBox();
            this.textBoxPartID = new System.Windows.Forms.TextBox();
            this.radioButtonPartOutsourced = new System.Windows.Forms.RadioButton();
            this.radioButtonPartInHouse = new System.Windows.Forms.RadioButton();
            this.labelPartMacIDComNA = new System.Windows.Forms.Label();
            this.labelPartMin = new System.Windows.Forms.Label();
            this.labelPartMax = new System.Windows.Forms.Label();
            this.labelPartPriceCost = new System.Windows.Forms.Label();
            this.labelPartInventory = new System.Windows.Forms.Label();
            this.labelPartName = new System.Windows.Forms.Label();
            this.labelPartID = new System.Windows.Forms.Label();
            this.labelAddPart = new System.Windows.Forms.Label();
            this.buttonPartSave = new System.Windows.Forms.Button();
            this.buttonPartCancel = new System.Windows.Forms.Button();
            this.panelAddParts.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAddParts
            // 
            this.panelAddParts.Controls.Add(this.textBoxPartMin);
            this.panelAddParts.Controls.Add(this.textBoxPartMax);
            this.panelAddParts.Controls.Add(this.textBoxPartMachineID);
            this.panelAddParts.Controls.Add(this.textBoxPartPriceCost);
            this.panelAddParts.Controls.Add(this.textBoxPartInventory);
            this.panelAddParts.Controls.Add(this.labelPartInventory);
            this.panelAddParts.Controls.Add(this.textBoxPartName);
            this.panelAddParts.Controls.Add(this.textBoxPartID);
            this.panelAddParts.Controls.Add(this.radioButtonPartOutsourced);
            this.panelAddParts.Controls.Add(this.radioButtonPartInHouse);
            this.panelAddParts.Controls.Add(this.labelPartMacIDComNA);
            this.panelAddParts.Controls.Add(this.labelPartMin);
            this.panelAddParts.Controls.Add(this.labelPartMax);
            this.panelAddParts.Controls.Add(this.labelPartPriceCost);
            this.panelAddParts.Controls.Add(this.labelPartName);
            this.panelAddParts.Controls.Add(this.labelPartID);
            this.panelAddParts.Location = new System.Drawing.Point(28, 55);
            this.panelAddParts.Name = "panelAddParts";
            this.panelAddParts.Size = new System.Drawing.Size(347, 222);
            this.panelAddParts.TabIndex = 1;
            // 
            // textBoxPartMin
            // 
            this.textBoxPartMin.Location = new System.Drawing.Point(243, 161);
            this.textBoxPartMin.Name = "textBoxPartMin";
            this.textBoxPartMin.Size = new System.Drawing.Size(62, 23);
            this.textBoxPartMin.TabIndex = 15;
            this.textBoxPartMin.LostFocus += new System.EventHandler(this.textBoxPartMin_LostFocus);
            // 
            // textBoxPartMax
            // 
            this.textBoxPartMax.Location = new System.Drawing.Point(124, 161);
            this.textBoxPartMax.Name = "textBoxPartMax";
            this.textBoxPartMax.Size = new System.Drawing.Size(62, 23);
            this.textBoxPartMax.TabIndex = 14;
            this.textBoxPartMax.LostFocus += new System.EventHandler(this.textBoxPartMax_LostFocus);
            // 
            // textBoxPartMachineID
            // 
            this.textBoxPartMachineID.Location = new System.Drawing.Point(124, 192);
            this.textBoxPartMachineID.Name = "textBoxPartMachineID";
            this.textBoxPartMachineID.Size = new System.Drawing.Size(180, 23);
            this.textBoxPartMachineID.TabIndex = 13;
            // 
            // textBoxPartPriceCost
            // 
            this.textBoxPartPriceCost.Location = new System.Drawing.Point(124, 103);
            this.textBoxPartPriceCost.Name = "textBoxPartPriceCost";
            this.textBoxPartPriceCost.Size = new System.Drawing.Size(180, 23);
            this.textBoxPartPriceCost.TabIndex = 12;
            // 
            // textBoxPartName
            // 
            this.textBoxPartName.Location = new System.Drawing.Point(124, 74);
            this.textBoxPartName.Name = "textBoxPartName";
            this.textBoxPartName.Size = new System.Drawing.Size(180, 23);
            this.textBoxPartName.TabIndex = 11;
            // 
            // textBoxPartInventory
            // 
            this.textBoxPartInventory.Location = new System.Drawing.Point(124, 132);
            this.textBoxPartInventory.Name = "textBoxPartInventory";
            this.textBoxPartInventory.Size = new System.Drawing.Size(180, 23);
            this.textBoxPartInventory.TabIndex = 10;
            this.textBoxPartInventory.LostFocus += new System.EventHandler(this.textBoxPartInventory_LostFocus);
            // 
            // textBoxPartID
            // 
            this.textBoxPartID.Location = new System.Drawing.Point(124, 45);
            this.textBoxPartID.Name = "textBoxPartID";
            this.textBoxPartID.Size = new System.Drawing.Size(180, 23);
            this.textBoxPartID.TabIndex = 9;
            this.textBoxPartID.LostFocus += new System.EventHandler(this.textBoxPartID_LostFocus);
            // 
            // radioButtonPartOutsourced
            // 
            this.radioButtonPartOutsourced.AutoSize = true;
            this.radioButtonPartOutsourced.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonPartOutsourced.Location = new System.Drawing.Point(215, 10);
            this.radioButtonPartOutsourced.Name = "radioButtonPartOutsourced";
            this.radioButtonPartOutsourced.Size = new System.Drawing.Size(108, 23);
            this.radioButtonPartOutsourced.TabIndex = 8;
            this.radioButtonPartOutsourced.TabStop = true;
            this.radioButtonPartOutsourced.Text = "Outsourced";
            this.radioButtonPartOutsourced.UseVisualStyleBackColor = true;
            this.radioButtonPartOutsourced.CheckedChanged += new System.EventHandler(this.radioButtonOutsourced_CheckedChanged);
            // 
            // radioButtonPartInHouse
            // 
            this.radioButtonPartInHouse.AutoSize = true;
            this.radioButtonPartInHouse.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonPartInHouse.Location = new System.Drawing.Point(124, 10);
            this.radioButtonPartInHouse.Name = "radioButtonPartInHouse";
            this.radioButtonPartInHouse.Size = new System.Drawing.Size(87, 23);
            this.radioButtonPartInHouse.TabIndex = 7;
            this.radioButtonPartInHouse.TabStop = true;
            this.radioButtonPartInHouse.Text = "In-House";
            this.radioButtonPartInHouse.UseVisualStyleBackColor = true;
            this.radioButtonPartInHouse.CheckedChanged += new System.EventHandler(this.radioButtonPartInHouse_CheckedChanged);
            // 
            // labelPartMacIDComNA
            // 
            this.labelPartMacIDComNA.AutoSize = true;
            this.labelPartMacIDComNA.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPartMacIDComNA.Location = new System.Drawing.Point(22, 196);
            this.labelPartMacIDComNA.Name = "labelPartMacIDComNA";
            this.labelPartMacIDComNA.Size = new System.Drawing.Size(84, 19);
            this.labelPartMacIDComNA.TabIndex = 6;
            this.labelPartMacIDComNA.Text = "Machine ID";
            // 
            // labelPartMin
            // 
            this.labelPartMin.AutoSize = true;
            this.labelPartMin.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPartMin.Location = new System.Drawing.Point(202, 165);
            this.labelPartMin.Name = "labelPartMin";
            this.labelPartMin.Size = new System.Drawing.Size(35, 19);
            this.labelPartMin.TabIndex = 5;
            this.labelPartMin.Text = "Min";
            // 
            // labelPartMax
            // 
            this.labelPartMax.AutoSize = true;
            this.labelPartMax.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPartMax.Location = new System.Drawing.Point(67, 165);
            this.labelPartMax.Name = "labelPartMax";
            this.labelPartMax.Size = new System.Drawing.Size(39, 19);
            this.labelPartMax.TabIndex = 4;
            this.labelPartMax.Text = "Max";
            // 
            // labelPartPriceCost
            // 
            this.labelPartPriceCost.AutoSize = true;
            this.labelPartPriceCost.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPartPriceCost.Location = new System.Drawing.Point(31, 107);
            this.labelPartPriceCost.Name = "labelPartPriceCost";
            this.labelPartPriceCost.Size = new System.Drawing.Size(77, 19);
            this.labelPartPriceCost.TabIndex = 3;
            this.labelPartPriceCost.Text = "Price/Cost";
            // 
            // labelPartInventory
            // 
            this.labelPartInventory.AutoSize = true;
            this.labelPartInventory.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPartInventory.Location = new System.Drawing.Point(31, 136);
            this.labelPartInventory.Name = "labelPartInventory";
            this.labelPartInventory.Size = new System.Drawing.Size(75, 19);
            this.labelPartInventory.TabIndex = 2;
            this.labelPartInventory.Text = "Inventory";
            // 
            // labelPartName
            // 
            this.labelPartName.AutoSize = true;
            this.labelPartName.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPartName.Location = new System.Drawing.Point(57, 78);
            this.labelPartName.Name = "labelPartName";
            this.labelPartName.Size = new System.Drawing.Size(49, 19);
            this.labelPartName.TabIndex = 1;
            this.labelPartName.Text = "Name";
            // 
            // labelPartID
            // 
            this.labelPartID.AutoSize = true;
            this.labelPartID.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPartID.Location = new System.Drawing.Point(83, 49);
            this.labelPartID.Name = "labelPartID";
            this.labelPartID.Size = new System.Drawing.Size(23, 19);
            this.labelPartID.TabIndex = 0;
            this.labelPartID.Text = "ID";
            // 
            // labelAddPart
            // 
            this.labelAddPart.AutoSize = true;
            this.labelAddPart.BackColor = System.Drawing.Color.Silver;
            this.labelAddPart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelAddPart.Font = new System.Drawing.Font("Candara", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAddPart.Location = new System.Drawing.Point(12, 9);
            this.labelAddPart.Name = "labelAddPart";
            this.labelAddPart.Size = new System.Drawing.Size(85, 26);
            this.labelAddPart.TabIndex = 2;
            this.labelAddPart.Text = "Add Part";
            // 
            // buttonPartSave
            // 
            this.buttonPartSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPartSave.Font = new System.Drawing.Font("Candara", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonPartSave.Location = new System.Drawing.Point(219, 283);
            this.buttonPartSave.Name = "buttonPartSave";
            this.buttonPartSave.Size = new System.Drawing.Size(75, 25);
            this.buttonPartSave.TabIndex = 3;
            this.buttonPartSave.Text = "Save";
            this.buttonPartSave.UseVisualStyleBackColor = true;
            this.buttonPartSave.Click += new System.EventHandler(this.buttonPartSave_Click);
            // 
            // buttonPartCancel
            // 
            this.buttonPartCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPartCancel.Font = new System.Drawing.Font("Candara", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonPartCancel.Location = new System.Drawing.Point(300, 283);
            this.buttonPartCancel.Name = "buttonPartCancel";
            this.buttonPartCancel.Size = new System.Drawing.Size(75, 25);
            this.buttonPartCancel.TabIndex = 4;
            this.buttonPartCancel.Text = "Cancel";
            this.buttonPartCancel.UseVisualStyleBackColor = true;
            this.buttonPartCancel.Click += new System.EventHandler(this.buttonPartCancel_Click);
            // 
            // AddParts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(406, 352);
            this.Controls.Add(this.buttonPartCancel);
            this.Controls.Add(this.buttonPartSave);
            this.Controls.Add(this.labelAddPart);
            this.Controls.Add(this.panelAddParts);
            this.Name = "AddParts";
            this.Text = "AddParts";
            this.panelAddParts.ResumeLayout(false);
            this.panelAddParts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelAddParts;
        private System.Windows.Forms.Label labelAddPart;
        private System.Windows.Forms.Label labelPartInventory;
        private System.Windows.Forms.Label labelPartName;
        private System.Windows.Forms.Label labelPartID;
        private System.Windows.Forms.TextBox textBoxPartMin;
        private System.Windows.Forms.TextBox textBoxPartMax;
        private System.Windows.Forms.TextBox textBoxPartMachineID;
        private System.Windows.Forms.TextBox textBoxPartPriceCost;
        private System.Windows.Forms.TextBox textBoxPartName;
        private System.Windows.Forms.TextBox textBoxPartInventory;
        private System.Windows.Forms.TextBox textBoxPartID;
        private System.Windows.Forms.RadioButton radioButtonPartOutsourced;
        private System.Windows.Forms.RadioButton radioButtonPartInHouse;
        private System.Windows.Forms.Label labelPartMacIDComNA;
        private System.Windows.Forms.Label labelPartMin;
        private System.Windows.Forms.Label labelPartMax;
        private System.Windows.Forms.Label labelPartPriceCost;
        private System.Windows.Forms.Button buttonPartSave;
        private System.Windows.Forms.Button buttonPartCancel;
    }
}
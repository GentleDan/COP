namespace FurnitureFactoryView
{
    partial class FormSupplier
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.dateTimePickerDelivery = new System.Windows.Forms.DateTimePicker();
            this.inputUserControlFrequency = new WindowsFormsComponentsKalachikov.InputUserControl();
            this.labelName = new System.Windows.Forms.Label();
            this.labelDateDelivery = new System.Windows.Forms.Label();
            this.labelFrequency = new System.Windows.Forms.Label();
            this.userControlListManagerName = new WindowsFormsControlLibrary.UserControlList();
            this.labelManagerName = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(12, 48);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(180, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // dateTimePickerDelivery
            // 
            this.dateTimePickerDelivery.Location = new System.Drawing.Point(12, 104);
            this.dateTimePickerDelivery.Name = "dateTimePickerDelivery";
            this.dateTimePickerDelivery.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDelivery.TabIndex = 1;
            // 
            // inputUserControlFrequency
            // 
            this.inputUserControlFrequency.Location = new System.Drawing.Point(12, 387);
            this.inputUserControlFrequency.Max = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.inputUserControlFrequency.Min = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inputUserControlFrequency.Name = "inputUserControlFrequency";
            this.inputUserControlFrequency.Size = new System.Drawing.Size(253, 25);
            this.inputUserControlFrequency.TabIndex = 3;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(13, 29);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(60, 13);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Название:";
            // 
            // labelDateDelivery
            // 
            this.labelDateDelivery.AutoSize = true;
            this.labelDateDelivery.Location = new System.Drawing.Point(12, 85);
            this.labelDateDelivery.Name = "labelDateDelivery";
            this.labelDateDelivery.Size = new System.Drawing.Size(86, 13);
            this.labelDateDelivery.TabIndex = 5;
            this.labelDateDelivery.Text = "Дата поставки:";
            // 
            // labelFrequency
            // 
            this.labelFrequency.AutoSize = true;
            this.labelFrequency.Location = new System.Drawing.Point(13, 371);
            this.labelFrequency.Name = "labelFrequency";
            this.labelFrequency.Size = new System.Drawing.Size(102, 13);
            this.labelFrequency.TabIndex = 6;
            this.labelFrequency.Text = "Частота поставок:";
            // 
            // userControlListManagerName
            // 
            this.userControlListManagerName.Location = new System.Drawing.Point(12, 169);
            this.userControlListManagerName.Name = "userControlListManagerName";
            this.userControlListManagerName.SelectedItem = null;
            this.userControlListManagerName.Size = new System.Drawing.Size(253, 183);
            this.userControlListManagerName.TabIndex = 7;
            // 
            // labelManagerName
            // 
            this.labelManagerName.AutoSize = true;
            this.labelManagerName.Location = new System.Drawing.Point(12, 150);
            this.labelManagerName.Name = "labelManagerName";
            this.labelManagerName.Size = new System.Drawing.Size(98, 13);
            this.labelManagerName.TabIndex = 8;
            this.labelManagerName.Text = "ФИО менеджера:";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 441);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(208, 441);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 10;
            this.buttonExit.Text = "Закрыть";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // FormSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 476);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelManagerName);
            this.Controls.Add(this.userControlListManagerName);
            this.Controls.Add(this.labelFrequency);
            this.Controls.Add(this.labelDateDelivery);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.inputUserControlFrequency);
            this.Controls.Add(this.dateTimePickerDelivery);
            this.Controls.Add(this.textBoxName);
            this.Name = "FormSupplier";
            this.Text = "Поставщик";
            this.Load += new System.EventHandler(this.FormSupplier_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.DateTimePicker dateTimePickerDelivery;
        private WindowsFormsComponentsKalachikov.InputUserControl inputUserControlFrequency;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelDateDelivery;
        private System.Windows.Forms.Label labelFrequency;
        private WindowsFormsControlLibrary.UserControlList userControlListManagerName;
        private System.Windows.Forms.Label labelManagerName;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonExit;
    }
}
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
            this.inputUserControlFrequency = new WindowsFormsControlLibraryKalachikov.InputUserControl();
            this.labelName = new System.Windows.Forms.Label();
            this.labelDateDelivery = new System.Windows.Forms.Label();
            this.labelFrequency = new System.Windows.Forms.Label();
            this.labelManagerName = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.listBoxDates = new System.Windows.Forms.ListBox();
            this.buttonAddDate = new System.Windows.Forms.Button();
            this.userControlListManagerName = new WindowsFormsControlLibrary.UserControlList();
            this.buttonClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Location = new System.Drawing.Point(12, 30);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(239, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // dateTimePickerDelivery
            // 
            this.dateTimePickerDelivery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerDelivery.Location = new System.Drawing.Point(12, 75);
            this.dateTimePickerDelivery.Name = "dateTimePickerDelivery";
            this.dateTimePickerDelivery.Size = new System.Drawing.Size(165, 20);
            this.dateTimePickerDelivery.TabIndex = 1;
            // 
            // inputUserControlFrequency
            // 
            this.inputUserControlFrequency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputUserControlFrequency.Location = new System.Drawing.Point(12, 451);
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
            this.inputUserControlFrequency.Size = new System.Drawing.Size(100, 25);
            this.inputUserControlFrequency.TabIndex = 3;
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(9, 8);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(60, 13);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Название:";
            // 
            // labelDateDelivery
            // 
            this.labelDateDelivery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDateDelivery.AutoSize = true;
            this.labelDateDelivery.Location = new System.Drawing.Point(12, 59);
            this.labelDateDelivery.Name = "labelDateDelivery";
            this.labelDateDelivery.Size = new System.Drawing.Size(86, 13);
            this.labelDateDelivery.TabIndex = 5;
            this.labelDateDelivery.Text = "Дата поставки:";
            this.labelDateDelivery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFrequency
            // 
            this.labelFrequency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFrequency.AutoSize = true;
            this.labelFrequency.Location = new System.Drawing.Point(9, 435);
            this.labelFrequency.Name = "labelFrequency";
            this.labelFrequency.Size = new System.Drawing.Size(102, 13);
            this.labelFrequency.TabIndex = 6;
            this.labelFrequency.Text = "Частота поставок:";
            // 
            // labelManagerName
            // 
            this.labelManagerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelManagerName.AutoSize = true;
            this.labelManagerName.Location = new System.Drawing.Point(12, 230);
            this.labelManagerName.Name = "labelManagerName";
            this.labelManagerName.Size = new System.Drawing.Size(98, 13);
            this.labelManagerName.TabIndex = 8;
            this.labelManagerName.Text = "ФИО менеджера:";
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonSave.Location = new System.Drawing.Point(12, 477);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonExit.Location = new System.Drawing.Point(229, 477);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 10;
            this.buttonExit.Text = "Закрыть";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // listBoxDates
            // 
            this.listBoxDates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxDates.FormattingEnabled = true;
            this.listBoxDates.Location = new System.Drawing.Point(12, 113);
            this.listBoxDates.Name = "listBoxDates";
            this.listBoxDates.Size = new System.Drawing.Size(235, 108);
            this.listBoxDates.TabIndex = 11;
            // 
            // buttonAddDate
            // 
            this.buttonAddDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddDate.Location = new System.Drawing.Point(253, 113);
            this.buttonAddDate.Name = "buttonAddDate";
            this.buttonAddDate.Size = new System.Drawing.Size(66, 20);
            this.buttonAddDate.TabIndex = 12;
            this.buttonAddDate.Text = "Добавить";
            this.buttonAddDate.UseVisualStyleBackColor = true;
            this.buttonAddDate.Click += new System.EventHandler(this.buttonAddDate_Click);
            // 
            // userControlListManagerName
            // 
            this.userControlListManagerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlListManagerName.Location = new System.Drawing.Point(12, 249);
            this.userControlListManagerName.Name = "userControlListManagerName";
            this.userControlListManagerName.SelectedItem = null;
            this.userControlListManagerName.Size = new System.Drawing.Size(292, 183);
            this.userControlListManagerName.TabIndex = 7;
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Location = new System.Drawing.Point(253, 190);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(66, 20);
            this.buttonClear.TabIndex = 13;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // FormSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 518);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonAddDate);
            this.Controls.Add(this.listBoxDates);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSupplier_FormClosing);
            this.Load += new System.EventHandler(this.FormSupplier_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.DateTimePicker dateTimePickerDelivery;
        private WindowsFormsControlLibraryKalachikov.InputUserControl inputUserControlFrequency;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelDateDelivery;
        private System.Windows.Forms.Label labelFrequency;
        private WindowsFormsControlLibrary.UserControlList userControlListManagerName;
        private System.Windows.Forms.Label labelManagerName;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.ListBox listBoxDates;
        private System.Windows.Forms.Button buttonAddDate;
        private System.Windows.Forms.Button buttonClear;
    }
}
namespace ExcelPluginReport
{
    partial class FormReport
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
            this.buttonCreateReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCreateReport
            // 
            this.buttonCreateReport.Location = new System.Drawing.Point(58, 40);
            this.buttonCreateReport.Name = "buttonCreateReport";
            this.buttonCreateReport.Size = new System.Drawing.Size(175, 100);
            this.buttonCreateReport.TabIndex = 0;
            this.buttonCreateReport.Text = "Создать";
            this.buttonCreateReport.UseVisualStyleBackColor = true;
            this.buttonCreateReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 186);
            this.Controls.Add(this.buttonCreateReport);
            this.Name = "FormReport";
            this.Text = "Отчет";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateReport;
    }
}
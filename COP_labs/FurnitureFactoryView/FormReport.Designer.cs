namespace FurnitureFactoryView
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
            this.buttonReport = new System.Windows.Forms.Button();
            this.comboBoxPlugin = new System.Windows.Forms.ComboBox();
            this.labelPlugins = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonReport
            // 
            this.buttonReport.Location = new System.Drawing.Point(60, 74);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(149, 26);
            this.buttonReport.TabIndex = 2;
            this.buttonReport.Text = "Создать";
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // comboBoxPlugin
            // 
            this.comboBoxPlugin.FormattingEnabled = true;
            this.comboBoxPlugin.Location = new System.Drawing.Point(60, 38);
            this.comboBoxPlugin.Name = "comboBoxPlugin";
            this.comboBoxPlugin.Size = new System.Drawing.Size(149, 21);
            this.comboBoxPlugin.TabIndex = 3;
            // 
            // labelPlugins
            // 
            this.labelPlugins.AutoSize = true;
            this.labelPlugins.Location = new System.Drawing.Point(60, 19);
            this.labelPlugins.Name = "labelPlugins";
            this.labelPlugins.Size = new System.Drawing.Size(58, 13);
            this.labelPlugins.TabIndex = 4;
            this.labelPlugins.Text = "Плагины: ";
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 127);
            this.Controls.Add(this.labelPlugins);
            this.Controls.Add(this.comboBoxPlugin);
            this.Controls.Add(this.buttonReport);
            this.Name = "FormReport";
            this.Text = "Отчет";
            this.Load += new System.EventHandler(this.FormReportPlugin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.ComboBox comboBoxPlugin;
        private System.Windows.Forms.Label labelPlugins;
    }
}
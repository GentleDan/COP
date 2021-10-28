namespace FurnitureFactoryView
{
    partial class FormManagers
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
            this.dataGridViewManagers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManagers)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewManagers
            // 
            this.dataGridViewManagers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewManagers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewManagers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewManagers.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewManagers.Name = "dataGridViewManagers";
            this.dataGridViewManagers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewManagers.Size = new System.Drawing.Size(571, 193);
            this.dataGridViewManagers.TabIndex = 0;
            this.dataGridViewManagers.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellEndEdit);
            this.dataGridViewManagers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewManagers_KeyDown);
            // 
            // FormManagers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 193);
            this.Controls.Add(this.dataGridViewManagers);
            this.Name = "FormManagers";
            this.Text = "Менеджеры";
            this.Load += new System.EventHandler(this.FormManagers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewManagers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewManagers;
    }
}
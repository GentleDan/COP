namespace ViberMessangerPlugin
{
    partial class FormSendMessege
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
            this.labelReciever = new System.Windows.Forms.Label();
            this.labelMessege = new System.Windows.Forms.Label();
            this.buttonSendMessege = new System.Windows.Forms.Button();
            this.textBoxReciever = new System.Windows.Forms.TextBox();
            this.textBoxMessege = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelReciever
            // 
            this.labelReciever.AutoSize = true;
            this.labelReciever.Location = new System.Drawing.Point(21, 41);
            this.labelReciever.Name = "labelReciever";
            this.labelReciever.Size = new System.Drawing.Size(69, 13);
            this.labelReciever.TabIndex = 0;
            this.labelReciever.Text = "Получатель:";
            // 
            // labelMessege
            // 
            this.labelMessege.AutoSize = true;
            this.labelMessege.Location = new System.Drawing.Point(21, 93);
            this.labelMessege.Name = "labelMessege";
            this.labelMessege.Size = new System.Drawing.Size(100, 13);
            this.labelMessege.TabIndex = 1;
            this.labelMessege.Text = "Текст сообщения:";
            // 
            // buttonSendMessege
            // 
            this.buttonSendMessege.Location = new System.Drawing.Point(141, 143);
            this.buttonSendMessege.Name = "buttonSendMessege";
            this.buttonSendMessege.Size = new System.Drawing.Size(203, 25);
            this.buttonSendMessege.TabIndex = 2;
            this.buttonSendMessege.Text = "Отправить сообщение";
            this.buttonSendMessege.UseVisualStyleBackColor = true;
            this.buttonSendMessege.Click += new System.EventHandler(this.buttonSendMessege_Click);
            // 
            // textBoxReciever
            // 
            this.textBoxReciever.Location = new System.Drawing.Point(158, 33);
            this.textBoxReciever.Name = "textBoxReciever";
            this.textBoxReciever.Size = new System.Drawing.Size(265, 20);
            this.textBoxReciever.TabIndex = 3;
            // 
            // textBoxMessege
            // 
            this.textBoxMessege.Location = new System.Drawing.Point(158, 86);
            this.textBoxMessege.Name = "textBoxMessege";
            this.textBoxMessege.Size = new System.Drawing.Size(265, 20);
            this.textBoxMessege.TabIndex = 4;
            // 
            // FormSendMessege
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 187);
            this.Controls.Add(this.textBoxMessege);
            this.Controls.Add(this.textBoxReciever);
            this.Controls.Add(this.buttonSendMessege);
            this.Controls.Add(this.labelMessege);
            this.Controls.Add(this.labelReciever);
            this.Name = "FormSendMessege";
            this.Text = "Отправить сообщение";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelReciever;
        private System.Windows.Forms.Label labelMessege;
        private System.Windows.Forms.Button buttonSendMessege;
        private System.Windows.Forms.TextBox textBoxReciever;
        private System.Windows.Forms.TextBox textBoxMessege;
    }
}
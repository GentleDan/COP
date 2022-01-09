namespace ComponentsCheck
{
    partial class FormTest
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonFirst = new System.Windows.Forms.Button();
            this.buttonSecond = new System.Windows.Forms.Button();
            this.buttonThird = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonFirst
            // 
            this.buttonFirst.Location = new System.Drawing.Point(27, 85);
            this.buttonFirst.Name = "buttonFirst";
            this.buttonFirst.Size = new System.Drawing.Size(155, 81);
            this.buttonFirst.TabIndex = 0;
            this.buttonFirst.Text = "First";
            this.buttonFirst.UseVisualStyleBackColor = true;
            this.buttonFirst.Click += new System.EventHandler(this.buttonFirst_Click);
            // 
            // buttonSecond
            // 
            this.buttonSecond.Location = new System.Drawing.Point(247, 85);
            this.buttonSecond.Name = "buttonSecond";
            this.buttonSecond.Size = new System.Drawing.Size(155, 81);
            this.buttonSecond.TabIndex = 1;
            this.buttonSecond.Text = "Second";
            this.buttonSecond.UseVisualStyleBackColor = true;
            this.buttonSecond.Click += new System.EventHandler(this.buttonSecond_Click);
            // 
            // buttonThird
            // 
            this.buttonThird.Location = new System.Drawing.Point(467, 85);
            this.buttonThird.Name = "buttonThird";
            this.buttonThird.Size = new System.Drawing.Size(155, 81);
            this.buttonThird.TabIndex = 2;
            this.buttonThird.Text = "Third";
            this.buttonThird.UseVisualStyleBackColor = true;
            this.buttonThird.Click += new System.EventHandler(this.buttonThird_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 263);
            this.Controls.Add(this.buttonThird);
            this.Controls.Add(this.buttonSecond);
            this.Controls.Add(this.buttonFirst);
            this.Name = "FormTest";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFirst;
        private System.Windows.Forms.Button buttonSecond;
        private System.Windows.Forms.Button buttonThird;
    }
}


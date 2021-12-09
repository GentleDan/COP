namespace ViberMessangerPlugin
{
    partial class FormInfo
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
            this.labelBotName = new System.Windows.Forms.Label();
            this.labelBotToken = new System.Windows.Forms.Label();
            this.labelBotWebhook = new System.Windows.Forms.Label();
            this.labelBotOwner = new System.Windows.Forms.Label();
            this.labelBotSubs = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelToken = new System.Windows.Forms.Label();
            this.labelWebhook = new System.Windows.Forms.Label();
            this.labelOwner = new System.Windows.Forms.Label();
            this.labelSubs = new System.Windows.Forms.Label();
            this.buttonGetInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelBotName
            // 
            this.labelBotName.AutoSize = true;
            this.labelBotName.Location = new System.Drawing.Point(13, 31);
            this.labelBotName.Name = "labelBotName";
            this.labelBotName.Size = new System.Drawing.Size(32, 13);
            this.labelBotName.TabIndex = 0;
            this.labelBotName.Text = "Имя:";
            // 
            // labelBotToken
            // 
            this.labelBotToken.AutoSize = true;
            this.labelBotToken.Location = new System.Drawing.Point(12, 67);
            this.labelBotToken.Name = "labelBotToken";
            this.labelBotToken.Size = new System.Drawing.Size(41, 13);
            this.labelBotToken.TabIndex = 1;
            this.labelBotToken.Text = "Токен:";
            // 
            // labelBotWebhook
            // 
            this.labelBotWebhook.AutoSize = true;
            this.labelBotWebhook.Location = new System.Drawing.Point(12, 102);
            this.labelBotWebhook.Name = "labelBotWebhook";
            this.labelBotWebhook.Size = new System.Drawing.Size(45, 13);
            this.labelBotWebhook.TabIndex = 2;
            this.labelBotWebhook.Text = "Вебхук:";
            // 
            // labelBotOwner
            // 
            this.labelBotOwner.AutoSize = true;
            this.labelBotOwner.Location = new System.Drawing.Point(12, 137);
            this.labelBotOwner.Name = "labelBotOwner";
            this.labelBotOwner.Size = new System.Drawing.Size(59, 13);
            this.labelBotOwner.TabIndex = 3;
            this.labelBotOwner.Text = "Владелец:";
            // 
            // labelBotSubs
            // 
            this.labelBotSubs.AutoSize = true;
            this.labelBotSubs.Location = new System.Drawing.Point(12, 176);
            this.labelBotSubs.Name = "labelBotSubs";
            this.labelBotSubs.Size = new System.Drawing.Size(112, 13);
            this.labelBotSubs.TabIndex = 4;
            this.labelBotSubs.Text = "Кол-во подписчиков:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(242, 31);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(0, 13);
            this.labelName.TabIndex = 5;
            // 
            // labelToken
            // 
            this.labelToken.AutoSize = true;
            this.labelToken.Location = new System.Drawing.Point(245, 67);
            this.labelToken.Name = "labelToken";
            this.labelToken.Size = new System.Drawing.Size(0, 13);
            this.labelToken.TabIndex = 6;
            // 
            // labelWebhook
            // 
            this.labelWebhook.AutoSize = true;
            this.labelWebhook.Location = new System.Drawing.Point(245, 102);
            this.labelWebhook.Name = "labelWebhook";
            this.labelWebhook.Size = new System.Drawing.Size(0, 13);
            this.labelWebhook.TabIndex = 7;
            // 
            // labelOwner
            // 
            this.labelOwner.AutoSize = true;
            this.labelOwner.Location = new System.Drawing.Point(245, 137);
            this.labelOwner.Name = "labelOwner";
            this.labelOwner.Size = new System.Drawing.Size(0, 13);
            this.labelOwner.TabIndex = 8;
            // 
            // labelSubs
            // 
            this.labelSubs.AutoSize = true;
            this.labelSubs.Location = new System.Drawing.Point(245, 176);
            this.labelSubs.Name = "labelSubs";
            this.labelSubs.Size = new System.Drawing.Size(0, 13);
            this.labelSubs.TabIndex = 9;
            // 
            // buttonGetInfo
            // 
            this.buttonGetInfo.Location = new System.Drawing.Point(164, 217);
            this.buttonGetInfo.Name = "buttonGetInfo";
            this.buttonGetInfo.Size = new System.Drawing.Size(254, 47);
            this.buttonGetInfo.TabIndex = 10;
            this.buttonGetInfo.Text = "Получить информацию";
            this.buttonGetInfo.UseVisualStyleBackColor = true;
            this.buttonGetInfo.Click += new System.EventHandler(this.buttonGetInfo_Click);
            // 
            // FormInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 288);
            this.Controls.Add(this.buttonGetInfo);
            this.Controls.Add(this.labelSubs);
            this.Controls.Add(this.labelOwner);
            this.Controls.Add(this.labelWebhook);
            this.Controls.Add(this.labelToken);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelBotSubs);
            this.Controls.Add(this.labelBotOwner);
            this.Controls.Add(this.labelBotWebhook);
            this.Controls.Add(this.labelBotToken);
            this.Controls.Add(this.labelBotName);
            this.Name = "FormInfo";
            this.Text = "Информация о боте";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBotName;
        private System.Windows.Forms.Label labelBotToken;
        private System.Windows.Forms.Label labelBotWebhook;
        private System.Windows.Forms.Label labelBotOwner;
        private System.Windows.Forms.Label labelBotSubs;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelToken;
        private System.Windows.Forms.Label labelWebhook;
        private System.Windows.Forms.Label labelOwner;
        private System.Windows.Forms.Label labelSubs;
        private System.Windows.Forms.Button buttonGetInfo;
    }
}
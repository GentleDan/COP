namespace FurnitureFactoryView
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.controlOutputlListBox = new ClassLibraryControlsFilippov.ControlOutputlListBox();
            this.componentDiagramPdf = new ClassLibraryComponentsFilippov.ComponentDiagramPdf(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.менеджерыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьПростойДокументToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьДокументСТаблицейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьДокументСДиаграммойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.componentExcelTables = new WindowsFormsComponentLibrary.ComponentExcelTables(this.components);
            this.docWithTable = new ComponentLibrary.DocWithTable();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlOutputlListBox
            // 
            this.controlOutputlListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlOutputlListBox.Location = new System.Drawing.Point(0, 0);
            this.controlOutputlListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.controlOutputlListBox.Name = "controlOutputlListBox";
            this.controlOutputlListBox.SelectedIndex = -1;
            this.controlOutputlListBox.Size = new System.Drawing.Size(865, 348);
            this.controlOutputlListBox.TabIndex = 0;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.редактироватьToolStripMenuItem,
            this.удалитьToolStripMenuItem,
            this.менеджерыToolStripMenuItem,
            this.создатьПростойДокументToolStripMenuItem,
            this.создатьДокументСТаблицейToolStripMenuItem,
            this.создатьДокументСДиаграммойToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(296, 158);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.AddSupplier);
            // 
            // редактироватьToolStripMenuItem
            // 
            this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            this.редактироватьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.редактироватьToolStripMenuItem.Text = "Редактировать";
            this.редактироватьToolStripMenuItem.Click += new System.EventHandler(this.UpdateSupplier);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.DeleteSupplier);
            // 
            // менеджерыToolStripMenuItem
            // 
            this.менеджерыToolStripMenuItem.Name = "менеджерыToolStripMenuItem";
            this.менеджерыToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.менеджерыToolStripMenuItem.Text = "Менеджеры";
            this.менеджерыToolStripMenuItem.Click += new System.EventHandler(this.OpenManagersForm);
            // 
            // создатьПростойДокументToolStripMenuItem
            // 
            this.создатьПростойДокументToolStripMenuItem.Name = "создатьПростойДокументToolStripMenuItem";
            this.создатьПростойДокументToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.создатьПростойДокументToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.создатьПростойДокументToolStripMenuItem.Text = "Создать простой документ";
            this.создатьПростойДокументToolStripMenuItem.Click += new System.EventHandler(this.CreateSimpleDocument);
            // 
            // создатьДокументСТаблицейToolStripMenuItem
            // 
            this.создатьДокументСТаблицейToolStripMenuItem.Name = "создатьДокументСТаблицейToolStripMenuItem";
            this.создатьДокументСТаблицейToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.создатьДокументСТаблицейToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.создатьДокументСТаблицейToolStripMenuItem.Text = "Создать документ с таблицей";
            this.создатьДокументСТаблицейToolStripMenuItem.Click += new System.EventHandler(this.CreateDocumentTable);
            // 
            // создатьДокументСДиаграммойToolStripMenuItem
            // 
            this.создатьДокументСДиаграммойToolStripMenuItem.Name = "создатьДокументСДиаграммойToolStripMenuItem";
            this.создатьДокументСДиаграммойToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.создатьДокументСДиаграммойToolStripMenuItem.Size = new System.Drawing.Size(295, 22);
            this.создатьДокументСДиаграммойToolStripMenuItem.Text = "Создать документ с диаграммой";
            this.создатьДокументСДиаграммойToolStripMenuItem.Click += new System.EventHandler(this.CreateDocumentChart);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 348);
            this.ContextMenuStrip = this.contextMenuStrip;
            this.Controls.Add(this.controlOutputlListBox);
            this.Name = "FormMain";
            this.Text = "Поставщики";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibraryControlsFilippov.ControlOutputlListBox controlOutputlListBox;
        private ClassLibraryComponentsFilippov.ComponentDiagramPdf componentDiagramPdf;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem менеджерыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьПростойДокументToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьДокументСТаблицейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьДокументСДиаграммойToolStripMenuItem;
        private WindowsFormsComponentLibrary.ComponentExcelTables componentExcelTables;
        private ComponentLibrary.DocWithTable docWithTable;
    }
}


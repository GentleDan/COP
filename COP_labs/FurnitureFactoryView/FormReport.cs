using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FurnitureFactoryBusinessLogic.PluginsLogic.Interfaces;
using FurnitureFactoryBusinessLogic.PluginsLogic.Managers;
using FurnitureFactoryBusinessLogic.PluginsLogic.HelperModels;
using Unity;
using static FurnitureFactoryBusinessLogic.PluginsLogic.HelperModels.ChartConfigModel;

namespace FurnitureFactoryView
{
    public partial class FormReport : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private IReportPlugin _reporter;
        private PluginExcelManager _manager;
        public FormReport(PluginExcelManager manager)
        {
            _manager = manager;
            InitializeComponent();
            _reporter = _manager.plugins["Report"];
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            _reporter.OpenFile();
            _reporter.AddParagraph(new ParagraphConfigModel()
            {
                Bold = true,
                Font = "Consolas",
                Text = "Первый абзац",
                Cells = new int[] { 1, 1 }
            });;

            _reporter.AddImage(new ImageConfigModel()
            {
                Path = @"C:\Users\Gentle_Dan\source\repos\COP\COP_labs\FurnitureFactoryView\Images\monke.jpg",
                Coordinates = new int[] { 550, 0, 750, 200 }
            }); ;
            List<DiagramSeries> thatlist = new List<DiagramSeries>() { new DiagramSeries{ Name = "Добрый день", Values = new double[] { 15, 18, 30, 20, 15, 17 } }, 
                new DiagramSeries { Name = "Добрый вечер", Values = new double[] { 18, 11, 45, 24, 10, 7 } } };
            _reporter.AddChart(new ChartConfigModel()
            {
                Title = "Глистограмма",
                Data = thatlist
            });
            _reporter.AddTable(new TableConfigModel()
            {
                TitleName = "Таблица",
                Text = new List<string> { "check", "test", "check", "test" }
            });

            var fbd = new SaveFileDialog();
            fbd.FileName = "test.xls";
            fbd.Filter = "xls file | *.xls";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _reporter.SaveDocument(fbd.FileName);
                    {
                        MessageBox.Show("Файл был создан успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

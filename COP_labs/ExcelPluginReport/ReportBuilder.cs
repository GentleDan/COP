using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureFactoryBusinessLogic.PluginsLogic.Interfaces;
using FurnitureFactoryBusinessLogic.PluginsLogic.HelperModels;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;

namespace ExcelPluginReport
{
    [Export(typeof(IReportPlugin))]
    public class ReportBuilder : IReportPlugin
    {
        Application excel;
        Workbook workBook;
        Worksheet sheet;
        public string PluginType => "ExcelReport";
        public void CreateDocument()
        {
            excel = new Application { SheetsInNewWorkbook = 1, Visible = false, DisplayAlerts = false };
            workBook = excel.Workbooks.Add(Type.Missing);
            sheet = (Worksheet)excel.Worksheets.get_Item(1);
        }
        public void AddChart(ChartConfigModel config)
        {
            Chart excelchart = (Chart)excel.Charts.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            excelchart.Activate();
            excelchart.Select(Type.Missing);
            excel.ActiveChart.ChartType = XlChartType.xlBarStacked;
            excel.ActiveChart.HasTitle = true;
            excel.ActiveChart.ChartTitle.Text = config.Title;
            excel.ActiveChart.ChartTitle.Font.Size = 14;
            excel.ActiveChart.ChartTitle.Font.Color = 255;
            excel.ActiveChart.HasLegend = false;
            SeriesCollection seriesCollection = (SeriesCollection)excel.ActiveChart.SeriesCollection(Type.Missing);
            int index = 1;
            foreach (var element in config.Data)
            {
                var this_series = seriesCollection.NewSeries();
                this_series.Name = config.Data.ElementAt(index-1).Name;
                this_series.Values = config.Data.ElementAt(index-1).Values;
                index++;
            }

            excel.ActiveChart.Location(XlChartLocation.xlLocationAsObject, "Лист1");
            sheet.Shapes.Item(1).Height = 300;
            sheet.Shapes.Item(1).Width = 300;
        }

        public void AddImage(ImageConfigModel config)
        {
            sheet.Shapes.AddPicture(config.Path, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, config.Coordinates[0], config.Coordinates[1], config.Coordinates[2], config.Coordinates[3]);
        }

        public void AddParagraph(ParagraphConfigModel config)
        {
            Range range = sheet.get_Range("A1", "A1");
            range.Cells.Font.Name = config.Font;
            range.Font.Bold = config.Bold;
            string text = config.Text.ToString();
            sheet.Cells[config.Cells[0], config.Cells[1]] = text;
        }

        public void AddTable(TableConfigModel config)
        {
            sheet.Cells[3, 1] = config.TitleName;
            int index = 4;
            foreach (var element in config.Text)
            {
                sheet.Cells[index, 1] = element;
                index++;
            }
            Excel.Range rangeTitle = sheet.get_Range("A3", "A3");
            rangeTitle.Font.Bold = true;
            Excel.Range range = sheet.get_Range("A3", "A7");
            range.Borders.Color = ColorTranslator.ToOle(Color.Black);
        }

        public void SaveDocument(string filepath)
        { 
            excel.Application.ActiveWorkbook.SaveAs(filepath, XlSaveAsAccessMode.xlNoChange);
            excel.Quit();
        }
    }
}

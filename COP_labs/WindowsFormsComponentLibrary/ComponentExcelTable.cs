using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using WindowsFormsComponentLibrary.Models;
using Microsoft.Office.Interop.Excel;

namespace WindowsFormsComponentLibrary
{
    public partial class ComponentExcelTable : Component
    {
        private List<PropertyInfo> propertyInGivenOrder;
        public ComponentExcelTable()
        {
            InitializeComponent();
        }

        public ComponentExcelTable(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public bool CreateDoc<T>(ExcelTableConfig<T> config)
        {
            if (string.IsNullOrEmpty(config.FileName) || string.IsNullOrEmpty(config.Title))
            {
                throw new Exception("Не задан путь до файла или загаловок");
            }
            if (config.Headers == null || config.Headers.Count == 0)
            {
                throw new Exception("Не заданы заголовки таблицы");
            }
            if (config.PropertiesOrder == null || config.PropertiesOrder.Count == 0)
            {
                throw new Exception("Не задан порядок свойств");
            }
            if (config.ColumnsWidth == null || config.ColumnsWidth.Count == 0)
            {
                throw new Exception("Не задана ширина столбцов");
            }
            if (config.RowsHeight == null || config.RowsHeight.Count == 0)
            {
                throw new Exception("Не задана высота строк");
            }
            if (config.Data == null || config.Data.Count == 0)
            {
                throw new Exception("Не задана данные для таблицы");
            }
            if (config.PropertiesOrder.Count != config.ColumnsWidth.Count ||
                config.ColumnsWidth.Count != config.Headers.Count ||
                config.RowsHeight.Count - 1 != config.Data.Count)
            {
                throw new Exception("Данные не согласованы");
            }

            Application excel = new Application { SheetsInNewWorkbook = 1, Visible = false, DisplayAlerts = false };
            Workbook workBook = excel.Workbooks.Add(Type.Missing);
            Worksheet sheet = (Worksheet)excel.Worksheets.get_Item(1);
            sheet.Name = "Лист";
            sheet.Cells[1, 1] = config.Title;
            int dataIndexRow = 2;
            int dataIndexColumn = 1;

            var rangeHead = sheet.Range[sheet.Cells[dataIndexRow, dataIndexColumn], sheet.Cells[dataIndexRow, config.Headers.Count]];
            var rangeFirstColumn = sheet.Range[sheet.Cells[dataIndexRow, dataIndexColumn], sheet.Cells[config.Data.Count + dataIndexRow, dataIndexColumn]];
            rangeHead.Cells.Font.Size = 11;
            rangeHead.Cells.Font.Bold = true;
            rangeHead.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangeFirstColumn.Cells.Font.Size = 11;
            rangeFirstColumn.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            rangeFirstColumn.Cells.Font.Bold = true;


            for (int i = 0; i < config.Headers.Count; i++)
            {
                sheet.Columns[i + dataIndexColumn].ColumnWidth = config.ColumnsWidth[i];
                sheet.Cells[dataIndexRow, i + dataIndexColumn] = config.Headers[i];
            }

            for (int i = 0; i < config.RowsHeight.Count; i++)
            {
                sheet.Rows[i + dataIndexRow].RowHeight = config.RowsHeight[i];
            }

            dataIndexRow++;
            SetPropOrder<T>(config.PropertiesOrder);
            for (int i = 0; i < config.Data.Count; i++)
            {
                for (int j = 0; j < propertyInGivenOrder.Count; j++)
                {
                    var test = propertyInGivenOrder[j].GetValue(config.Data[i]);
                    sheet.Cells[i + dataIndexRow, j + dataIndexColumn] = test.ToString();
                }
            }

            sheet.UsedRange.Borders.Item[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            sheet.UsedRange.Borders.Item[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            sheet.UsedRange.Borders.Item[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            sheet.UsedRange.Borders.Item[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
            sheet.UsedRange.Borders.Item[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
            sheet.UsedRange.Borders.Item[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            sheet.UsedRange.Cells.Font.Name = "Tahoma";
            excel.Application.ActiveWorkbook.SaveAs(config.FileName, XlSaveAsAccessMode.xlNoChange);
            excel.Quit();
            return true;
        }
        private void SetPropOrder<T>(List<string> propertyOrder)
        {
            propertyInGivenOrder = new List<PropertyInfo>();
            var type = typeof(T);
            for (int i = 0; i < propertyOrder.Count; i++)
            {
                var propInfo = type.GetProperty(propertyOrder[i]);
                if (propInfo == null)
                {
                    throw new Exception("У объекта нет свойства " + propertyOrder[i]);
                }
                propertyInGivenOrder.Add(propInfo);
            }
        }
    }
}

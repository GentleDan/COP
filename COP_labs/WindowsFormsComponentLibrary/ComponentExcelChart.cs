using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using WindowsFormsComponentLibrary.Models;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing.Spreadsheet;
using DocumentFormat.OpenXml.Drawing;

namespace WindowsFormsComponentLibrary
{
    public partial class ComponentExcelChart : Component
    {
        public ComponentExcelChart()
        {
            InitializeComponent();
        }

        public ComponentExcelChart(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public bool CreateDoc(ExcelChartInfo info)
        {
            string sheetName = "Лист";
            using (SpreadsheetDocument spreadsheetDocument =
           SpreadsheetDocument.Create(info.FileName, SpreadsheetDocumentType.Workbook))
            {
                // Создаем книгу (в ней хранятся листы)
                WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
                workbookpart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();
                // Получаем/создаем хранилище текстов для книги
                SharedStringTablePart shareStringPart =
               spreadsheetDocument.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Count() > 0
                ?
               spreadsheetDocument.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First()
                :
               spreadsheetDocument.WorkbookPart.AddNewPart<SharedStringTablePart>();
                // Создаем SharedStringTable, если его нет
                if (shareStringPart.SharedStringTable == null)
                {
                    shareStringPart.SharedStringTable = new SharedStringTable();
                }
                // Создаем лист в книгу
                WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(new SheetData());
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    ShareStringPart = shareStringPart,
                    ColumnName = "A",
                    RowIndex = 1,
                    Text = info.Title
                });
                MergeCells(new ExcelMergeParameters
                {
                    Worksheet = worksheetPart.Worksheet,
                    CellFromName = "A1",
                    CellToName = "C1"
                });
                // Добавляем лист в книгу
                DocumentFormat.OpenXml.Spreadsheet.Sheets sheets =
                spreadsheetDocument.WorkbookPart.Workbook.AppendChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>(new DocumentFormat.OpenXml.Spreadsheet.Sheets());
                Sheet sheet = new Sheet()
                {
                    Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = sheetName
                };
                sheets.Append(sheet);

                workbookpart.Workbook.Save();
            }
            InsertChartInSpreadsheet(info.FileName, sheetName, info.ChartName, info.Data, info.chartLocation);
            return true;
        }

        private static void InsertChartInSpreadsheet(string docName, string worksheetName, string title,
    Dictionary<string, int> data, ChartLocation chartLocation)
        {
            // Open the document for editing.
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(docName, true))
            {
                IEnumerable<Sheet> sheets = document.WorkbookPart.Workbook.Descendants<Sheet>().
        Where(s => s.Name == worksheetName);
                if (sheets.Count() == 0)
                {
                    // The specified worksheet does not exist.
                    return;
                }
                WorksheetPart worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(sheets.First().Id);

                // Add a new drawing to the worksheet.
                DrawingsPart drawingsPart = worksheetPart.AddNewPart<DrawingsPart>();
                worksheetPart.Worksheet.Append(new DocumentFormat.OpenXml.Spreadsheet.Drawing()
                { Id = worksheetPart.GetIdOfPart(drawingsPart) });
                worksheetPart.Worksheet.Save();

                // Add a new chart and set the chart language to English-US.
                ChartPart chartPart = drawingsPart.AddNewPart<ChartPart>();
                chartPart.ChartSpace = new ChartSpace();
                chartPart.ChartSpace.Append(new EditingLanguage() { Val = new StringValue("en-US") });
                DocumentFormat.OpenXml.Drawing.Charts.Chart chart = chartPart.ChartSpace.AppendChild<DocumentFormat.OpenXml.Drawing.Charts.Chart>(
                    new DocumentFormat.OpenXml.Drawing.Charts.Chart());

                // Create a new clustered column chart.
                PlotArea plotArea = chart.AppendChild<PlotArea>(new PlotArea());
                Layout layout = plotArea.AppendChild<Layout>(new Layout());
                BarChart barChart = plotArea.AppendChild<BarChart>(new BarChart(new BarDirection()
                { Val = new EnumValue<BarDirectionValues>(BarDirectionValues.Column) },
                    new BarGrouping() { Val = new EnumValue<BarGroupingValues>(BarGroupingValues.Clustered) }));

                uint i = 0;

                // Iterate through each key in the Dictionary collection and add the key to the chart Series
                // and add the corresponding value to the chart Values.
                foreach (string key in data.Keys)
                {
                    BarChartSeries barChartSeries = barChart.AppendChild<BarChartSeries>(new BarChartSeries(new Index()
                    {
                        Val =
         new UInt32Value(i)
                    },
                        new Order() { Val = new UInt32Value(i) },
                        new SeriesText(new NumericValue() { Text = key })));

                    StringLiteral strLit = barChartSeries.AppendChild<CategoryAxisData>(new CategoryAxisData()).AppendChild<StringLiteral>(new StringLiteral());
                    strLit.Append(new PointCount() { Val = new UInt32Value(1U) });
                    strLit.AppendChild<StringPoint>(new StringPoint() { Index = new UInt32Value(0U) }).Append(new NumericValue(title));

                    NumberLiteral numLit = barChartSeries.AppendChild<DocumentFormat.OpenXml.Drawing.Charts.Values>(
                        new DocumentFormat.OpenXml.Drawing.Charts.Values()).AppendChild<NumberLiteral>(new NumberLiteral());
                    numLit.Append(new FormatCode("General"));
                    numLit.Append(new PointCount() { Val = new UInt32Value(1U) });
                    numLit.AppendChild<NumericPoint>(new NumericPoint() { Index = new UInt32Value(0u) }).Append
        (new NumericValue(data[key].ToString()));

                    i++;
                }

                barChart.Append(new AxisId() { Val = new UInt32Value(48650112u) });
                barChart.Append(new AxisId() { Val = new UInt32Value(48672768u) });

                // Add the Category Axis.
                CategoryAxis catAx = plotArea.AppendChild<CategoryAxis>(new CategoryAxis(new AxisId()
                { Val = new UInt32Value(48650112u) }, new Scaling(new DocumentFormat.OpenXml.Drawing.Charts.Orientation()
                {
                    Val = new EnumValue<DocumentFormat.
        OpenXml.Drawing.Charts.OrientationValues>(DocumentFormat.OpenXml.Drawing.Charts.OrientationValues.MinMax)
                }),
                    //START NEW CODE
                    new Delete() { Val = false },
                    //END NEW CODE
                    new AxisPosition() { Val = new EnumValue<AxisPositionValues>(AxisPositionValues.Bottom) },
                    //START NEW CODE
                    new DocumentFormat.OpenXml.Drawing.Charts.NumberingFormat() { FormatCode = "General", SourceLinked = false },
                    new MajorTickMark() { Val = TickMarkValues.Outside },
                    new MinorTickMark() { Val = TickMarkValues.Cross },
                    //END NEW CODE
                    new TickLabelPosition() { Val = new EnumValue<TickLabelPositionValues>(TickLabelPositionValues.NextTo) },
                    new CrossingAxis() { Val = new UInt32Value(48672768U) },
                    new Crosses() { Val = new EnumValue<CrossesValues>(CrossesValues.AutoZero) },
                    new AutoLabeled() { Val = new BooleanValue(true) },
                    new LabelAlignment() { Val = new EnumValue<LabelAlignmentValues>(LabelAlignmentValues.Center) },
                    new LabelOffset() { Val = new UInt16Value((ushort)100) },
                    //START NEW CODE
                    new NoMultiLevelLabels() { Val = true }
                    //END NEW CODE
                    ));

                // Add the Value Axis.
                ValueAxis valAx = plotArea.AppendChild<ValueAxis>(new ValueAxis(new AxisId() { Val = new UInt32Value(48672768u) },
                    new Scaling(new DocumentFormat.OpenXml.Drawing.Charts.Orientation()
                    {
                        Val = new EnumValue<DocumentFormat.OpenXml.Drawing.Charts.OrientationValues>(
                        DocumentFormat.OpenXml.Drawing.Charts.OrientationValues.MinMax)
                    }),
                    //START NEW CODE
                    new Delete() { Val = false },
                    //END NEW CODE
                    new AxisPosition() { Val = new EnumValue<AxisPositionValues>(AxisPositionValues.Left) },
                    new MajorGridlines(),
                    new DocumentFormat.OpenXml.Drawing.Charts.NumberingFormat()
                    {
                        FormatCode = new StringValue("General"),
                        SourceLinked = new BooleanValue(true)
                    },
                        //START NEW CODE
                        new MajorTickMark() { Val = TickMarkValues.Outside },
                        new MinorTickMark() { Val = TickMarkValues.Cross },
                    //END NEW CODE
                    new TickLabelPosition()
                    {
                        Val = new EnumValue<TickLabelPositionValues>
        (TickLabelPositionValues.NextTo)
                    }, new CrossingAxis() { Val = new UInt32Value(48650112U) },
                    new Crosses() { Val = new EnumValue<CrossesValues>(CrossesValues.AutoZero) },
                    new CrossBetween() { Val = new EnumValue<CrossBetweenValues>(CrossBetweenValues.Between) }));

                EnumValue<LegendPositionValues> enumValue;
                switch (chartLocation)
                {
                    case ChartLocation.Bottom:
                        {
                            enumValue = new EnumValue<LegendPositionValues>(LegendPositionValues.Bottom);
                            break;
                        }
                    case ChartLocation.Left:
                        {
                            enumValue = new EnumValue<LegendPositionValues>(LegendPositionValues.Left);
                            break;
                        }
                    case ChartLocation.Right:
                        {
                            enumValue = new EnumValue<LegendPositionValues>(LegendPositionValues.Right);
                            break;
                        }
                    case ChartLocation.Top:
                        {
                            enumValue = new EnumValue<LegendPositionValues>(LegendPositionValues.Top);
                            break;
                        }
                    case ChartLocation.TopRight:
                        {
                            enumValue = new EnumValue<LegendPositionValues>(LegendPositionValues.TopRight);
                            break;
                        }
                    default:
                        {
                            enumValue = new EnumValue<LegendPositionValues>(LegendPositionValues.Right);
                            break;
                        }
                }

                // Add the chart Legend.
                Legend legend = chart.AppendChild<Legend>(new Legend(new LegendPosition() { Val = enumValue },
                    new Layout()));

                chart.Append(new PlotVisibleOnly() { Val = new BooleanValue(true) });

                // Save the chart part.
                chartPart.ChartSpace.Save();

                // Position the chart on the worksheet using a TwoCellAnchor object.
                drawingsPart.WorksheetDrawing = new WorksheetDrawing();
                TwoCellAnchor twoCellAnchor = drawingsPart.WorksheetDrawing.AppendChild<TwoCellAnchor>(new TwoCellAnchor());
                twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.FromMarker(new ColumnId("1"),
                    new ColumnOffset("581025"),
                    new RowId("1"),
                    new RowOffset("114300")));
                twoCellAnchor.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.ToMarker(new ColumnId("9"),
                    new ColumnOffset("276225"),
                    new RowId("16"),
                    new RowOffset("0")));

                // Append a GraphicFrame to the TwoCellAnchor object.
                DocumentFormat.OpenXml.Drawing.Spreadsheet.GraphicFrame graphicFrame =
                    twoCellAnchor.AppendChild<DocumentFormat.OpenXml.
        Drawing.Spreadsheet.GraphicFrame>(new DocumentFormat.OpenXml.Drawing.
        Spreadsheet.GraphicFrame());
                graphicFrame.Macro = "";

                graphicFrame.Append(new DocumentFormat.OpenXml.Drawing.Spreadsheet.NonVisualGraphicFrameProperties(
                    new DocumentFormat.OpenXml.Drawing.Spreadsheet.NonVisualDrawingProperties() { Id = new UInt32Value(2u), Name = "Chart 1" },
                    new DocumentFormat.OpenXml.Drawing.Spreadsheet.NonVisualGraphicFrameDrawingProperties()));

                graphicFrame.Append(new Transform(new Offset() { X = 0L, Y = 0L },
                                                                        new Extents() { Cx = 0L, Cy = 0L }));

                graphicFrame.Append(new Graphic(new GraphicData(new ChartReference() { Id = drawingsPart.GetIdOfPart(chartPart) })
                { Uri = "http://schemas.openxmlformats.org/drawingml/2006/chart" }));

                twoCellAnchor.Append(new ClientData());

                // Save the WorksheetDrawing object.
                drawingsPart.WorksheetDrawing.Save();
            }
        }

        private void InsertCellInWorksheet(ExcelCellParameters cellParameters)
        {
            SheetData sheetData = cellParameters.Worksheet.GetFirstChild<SheetData>();
            // Ищем строку, либо добавляем ее
            Row row;
            if (sheetData.Elements<Row>().Where(r => r.RowIndex == cellParameters.RowIndex).Count() != 0)
            {
                row = sheetData.Elements<Row>().Where(r => r.RowIndex == cellParameters.RowIndex).First();
            }
            else
            {
                row = new Row() { RowIndex = cellParameters.RowIndex };
                sheetData.Append(row);
            }
            // Ищем нужную ячейку
            Cell cell;
            if (row.Elements<Cell>().Where(c => c.CellReference.Value == cellParameters.CellReference).Count() > 0)
            {
                cell = row.Elements<Cell>().Where(c => c.CellReference.Value == cellParameters.CellReference).First();
            }
            else
            {
                // Все ячейки должны быть последовательно друг за другом расположены
                // нужно определить, после какой вставлять
                Cell refCell = null;
                foreach (Cell rowCell in row.Elements<Cell>())
                {
                    if (string.Compare(rowCell.CellReference.Value, cellParameters.CellReference, true) > 0)
                    {
                        refCell = rowCell;
                        break;
                    }
                }
                Cell newCell = new Cell()
                {
                    CellReference = cellParameters.CellReference
                };
                row.InsertBefore(newCell, refCell);
                cell = newCell;
            }
            // вставляем новый текст
            cellParameters.ShareStringPart.SharedStringTable.AppendChild(new SharedStringItem(new DocumentFormat.OpenXml.Spreadsheet.Text(cellParameters.Text)));
            cellParameters.ShareStringPart.SharedStringTable.Save();
            cell.CellValue = new CellValue((cellParameters.ShareStringPart.SharedStringTable.Elements<SharedStringItem>().Count() - 1).ToString());
            cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
            cell.StyleIndex = cellParameters.StyleIndex;
        }
        private void MergeCells(ExcelMergeParameters mergeParameters)
        {
            MergeCells mergeCells;
            if (mergeParameters.Worksheet.Elements<MergeCells>().Count() > 0)
            {
                mergeCells = mergeParameters.Worksheet.Elements<MergeCells>().First();
            }
            else
            {
                mergeCells = new MergeCells();
                if (mergeParameters.Worksheet.Elements<CustomSheetView>().Count() > 0)
                {
                    mergeParameters.Worksheet.InsertAfter(mergeCells, mergeParameters.Worksheet.Elements<CustomSheetView>().First());
                }
                else
                {
                    mergeParameters.Worksheet.InsertAfter(mergeCells,
                    mergeParameters.Worksheet.Elements<SheetData>().First());
                }
            }
            MergeCell mergeCell = new MergeCell()
            {
                Reference = new StringValue(mergeParameters.Merge)
            };
            mergeCells.Append(mergeCell);
        }
    }
}

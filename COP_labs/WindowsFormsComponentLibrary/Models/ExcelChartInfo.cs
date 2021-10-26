using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsComponentLibrary.Models
{
    public class ExcelChartInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public string ChartName { get; set; }
        public ChartLocation chartLocation { get; set; }
        public Dictionary<string, int> Data { get; set; }
    }
}

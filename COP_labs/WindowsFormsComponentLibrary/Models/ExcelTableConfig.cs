using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsComponentLibrary.Models
{
    public class ExcelTableConfig<T>
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<int> ColumnsWidth { get; set; }
        public List<int> RowsHeight { get; set; }
        public List<string> Headers { get; set; }
        public List<string> PropertiesOrder { get; set; }
        public List<T> Data { get; set; }
    }
}

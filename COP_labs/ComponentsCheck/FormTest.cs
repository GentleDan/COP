using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsComponentLibrary;
using WindowsFormsComponentLibrary.Models;

namespace ComponentsCheck
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void buttonFirst_Click(object sender, EventArgs e)
        {
            ComponentExcelTables report = new ComponentExcelTables();
            List<string[,]> data = new List<string[,]>();
            data.Add(new string[,] { { "row1col1", "row1col2", "row1col3", "row1col4", "row1col5" } });
            data.Add(new string[,] { { "row2col1", "row2col2", "row2col3", "row2col4", "row2col5" } });
            data.Add(new string[,] { { "row3col1", "row3col2", "row3col3", "row3col4", "row3col5" } });
            var sfd = new SaveFileDialog();
            sfd.Filter = "xlsx file | *.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(sfd.FileName))
                {
                    MessageBox.Show("The path is not specified", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (report.CreateDoc(new ExcelInfo
                { FileName = sfd.FileName, Data = data, Title = "Example" }))
                {
                    MessageBox.Show("The file was created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("An unexpected error has occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSecond_Click(object sender, EventArgs e)
        {
            ComponentExcelTable report = new ComponentExcelTable();
            List<int> ColWidth = new List<int>() { 50, 50, 50 };
            List<int> RowsHeight = new List<int>() { 50, 50, 50 };
            List<string> Headers = new List<string>() { "Name", "Age", "Phone Number" };
            List<string> Props = new List<string>() { "Name", "Age", "Phone" };
            List<ExampleModel> Data = new List<ExampleModel>() { 
                new ExampleModel {Name = "Andrew", Age = 20, Phone = "89021205478" }, 
                new ExampleModel { Name = "John", Age = 15, Phone = "89045458748" } };
            var sfd = new SaveFileDialog();
            sfd.Filter = "xls file | *.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(sfd.FileName))
                {
                    MessageBox.Show("The path is not specified", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (report.CreateDoc(new ExcelTableConfig<ExampleModel>
                { FileName = sfd.FileName, Title = "Example", ColumnsWidth = ColWidth, RowsHeight = RowsHeight, Headers = Headers, PropertiesOrder = Props, Data = Data }))
                {
                    MessageBox.Show("The file was created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("An unexpected error has occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonThird_Click(object sender, EventArgs e)
        {

        }
    }
}

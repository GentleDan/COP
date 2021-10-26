using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary
{
    public partial class UserControlTable : UserControl
    {
        public UserControlTable()
        {
            InitializeComponent();
        }

        public void SetColumns(List<ColumnProperty> properties)
        {
            foreach (var column in properties)
            {
                int index = dataGridView.Columns.Add(column.PropertyName, column.Header);
                dataGridView.Columns[index].Visible = column.Visible;
                dataGridView.Columns[index].Width = column.Width;
            }
        }

        public void Clear()
        {
            dataGridView.Rows.Clear();
        }

        public int SelectedRowIndex
        {
            get
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    return dataGridView.SelectedRows[0].Index;
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                if (value > -1 && value < dataGridView.Rows.Count)
                {
                    dataGridView.Rows[value].Selected = true;
                }
            }
        }

        public T GetSelectedObject<T>() where T : class, new()
        {
            string inpString;
            T item;
            if (dataGridView.SelectedRows.Count != 0)
            {
                T tempItem = Activator.CreateInstance<T>();
                foreach (DataGridViewCell cell in dataGridView.SelectedRows[0].Cells)
                {
                    Type type = tempItem.GetType();
                    object tag = dataGridView.Columns[cell.ColumnIndex].Tag;
                    inpString = tag?.ToString();
                    PropertyInfo prop = type.GetProperty(inpString);
                    if (prop != null)
                    {
                        prop.SetValue(tempItem, cell.Value);
                    }
                }
                item = tempItem;
            }
            else
            {
                item = default;
            }
            return item;
        }

        public void AddElement<T>(T item, int column, int row)
        {
            object value;
            if (column >= 0 && column <= dataGridView.Columns.Count && item != null)
            {
                while (dataGridView.Rows.Count <= row)
                {
                    dataGridView.Rows.Add();
                }
                DataGridViewCell element = dataGridView.Rows[row].Cells[column];
                PropertyInfo property = element.GetType().GetProperty(dataGridView.Columns[column].Tag.ToString());
                if (property != null)
                {
                    value = property.GetValue(element, null);
                }
                else
                {
                    value = null;
                }
                element.Value = value;
            }
        }
    }
}

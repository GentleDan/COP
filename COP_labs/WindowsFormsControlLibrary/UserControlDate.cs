using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace WindowsFormsControlLibrary
{
    public partial class UserControlDate : UserControl
    {
        public UserControlDate()
        {
            InitializeComponent();
        }

        public DateTime? Date
        {
            get
            {
                if (checkBox.Checked)
                {
                    return null;
                }
                if (textBox.Text == string.Empty)
                {
                    throw new ArgumentNullException();
                }
                try
                {
                    DateTime dt = DateTime.ParseExact(textBox.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                catch (Exception)
                {
                    throw new FormatException("Неверный формат даты");
                }
            }
            set
            {
                if (value.HasValue)
                {
                    textBox.Text = value.Value.ToString("dd.MM.yyyy");
                }
                checkBox.Checked = !value.HasValue;
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                textBox.Text = String.Empty;
                textBox.Enabled = false;
            }
            else
            {
                textBox.Enabled = true;
            }
        }
    }
}

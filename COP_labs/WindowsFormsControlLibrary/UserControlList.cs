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
    public partial class UserControlList : UserControl
    {
        public UserControlList()
        {
            InitializeComponent();
        }

        public ListBox.ObjectCollection Items
        {
            get
            {
                return listBox.Items;
            }
        }

        public void Clear() => listBox.Items.Clear();

        public string SelectedItem
        {
            get
            {
                if (listBox.SelectedItem == null)
                {
                    return null;
                }
                else
                {
                    return listBox.SelectedItem.ToString();
                }
            }
            set
            {
                listBox.SelectedItem = value;
            }
        }

        public event EventHandler ListBoxSelectedElementChange
        {
            add => listBox.SelectedIndexChanged += value;
            remove => listBox.SelectedIndexChanged -= value;
        }
    }
}

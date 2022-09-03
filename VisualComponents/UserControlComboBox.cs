using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualComponents
{
    public partial class UserControlComboBox : UserControl
    {
        public string SelectedValue
        {
            get => comboBox.SelectedItem != null ? comboBox.SelectedItem.ToString() : string.Empty;
            set
            {
                if (comboBox.Items.Contains(value))
                {
                    comboBox.SelectedItem = value;
                }
            }
        }

        private event EventHandler _selectedItemChange;

        public event EventHandler SetChangeItemEvent
        {
            add { _selectedItemChange += value; }
            remove { _selectedItemChange -= value; }
        }

        public UserControlComboBox()
        {
            InitializeComponent();
            comboBox.SelectedIndexChanged += (sender, e) =>
            {
                _selectedItemChange?.Invoke(sender, e);
            };
        }

        public void InsertData(List<string> list)
        {
            foreach(string item in list)
            {
                comboBox.Items.Add(item);
            }
        }
        public void ClearList()
        {
            comboBox.Items.Clear();
            comboBox.Text = string.Empty;
        }
    }
}

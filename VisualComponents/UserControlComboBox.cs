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
            set => comboBox.SelectedItem = value;
        }

        private event EventHandler _selectdItemChange;

        public event EventHandler SetChangeItemEvent
        {
            add { _selectdItemChange += value; }
            remove { _selectdItemChange -= value; }
        }

        public UserControlComboBox()
        {
            InitializeComponent();
            SetChangeItemEvent += SelectedItemChange;
            comboBox.SelectedIndexChanged += (sender, e) =>
            {
                _selectdItemChange?.Invoke(sender, e);
            };
        }

        private void SelectedItemChange(object sender, EventArgs e)
        {
            SelectedValue = comboBox.SelectedItem?.ToString();
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

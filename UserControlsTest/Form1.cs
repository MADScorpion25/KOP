using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlsTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            userControlComboBox1.InsertData(new List<string>() { "Значение 1", "Значение 2", "Значение 3", "Значение 4", "Значение 5" });
            userControlListBox.SetVisualLayout("Машина марки {Brand}, {ProductionYear} года выпуска", '{', '}');
            userControlListBox.SetListData(new List<Car>() { new Car("Lada", 2018), new Car("Volkswagen", 2010), new Car("Volvo", 2020) });
            userControlComboBox1.SetChangeItemEvent += incrementLabelEvents;
            userControlTextBox.SetToolTip("example@gmail.com");
            userControlTextBox.SetChangeValueEvent += incrementLabelEvents;
            userControlTextBox.Pattern = new Regex(@"^([\w\.\-]+)@gmail.com");
        }
        private void incrementLabelEvents(object sender, EventArgs e)
        {
            labelEvents.Text = (Convert.ToInt32(labelEvents.Text) + 1).ToString();
        }

        private void buttonClearComboBox_Click(object sender, EventArgs e)
        {
            userControlComboBox1.ClearList();
        }

        private void buttonGetObject_Click(object sender, EventArgs e)
        {
            labelObjectInfo.Text = userControlListBox.GetSelectedObject<Car>()?.ToString();
        }

        private void buttonGetFromComboBox_Click(object sender, EventArgs e)
        {
            labelComboBox.Text = userControlComboBox1.SelectedValue;
        }

        private void buttonGetFromTextBox_Click(object sender, EventArgs e)
        {
            try
            {
                labelForTextBox.Text = userControlTextBox.Content;
            }
            catch(Exception ex)
            {
                labelForTextBox.Text = ex.Message;
            }
        }

        private void buttonSetComboBoxItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxForComboBoxItem.Text))
            {
                userControlComboBox1.SelectedValue = textBoxForComboBoxItem.Text;
            }
        }
    }
}

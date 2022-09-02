using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlsTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            userControlComboBox.InsertData(new List<string>() { "Значение 1", "Значение 2", "Значение 3", "Значение 4", "Значение 5" });
            userControlListBox.SetVisualLayout("Машина марки {Brand}, {ProductionYear} года выпуска", '{', '}');
            userControlListBox.SetListData(new List<Car>() { new Car("Lada", 2018), new Car("Volswagen", 2010), new Car("Volvo", 2020) });
            userControlComboBox.SetChangeItemEvent += incrementLabelEvents;
        }
        private void incrementLabelEvents(object sender, EventArgs e)
        {
            labelEvents.Text = (Convert.ToInt32(labelEvents.Text) + 1).ToString();
        }

        private void buttonClearComboBox_Click(object sender, EventArgs e)
        {
            userControlComboBox.ClearList();
        }

        private void buttonGetObject_Click(object sender, EventArgs e)
        {
            labelObjectInfo.Text = userControlListBox.GetSelectedObject<Car>()?.ToString();
        }

        private void buttonGetFromComboBox_Click(object sender, EventArgs e)
        {
            labelComboBox.Text = userControlComboBox.SelectedValue;
        }
    }
}

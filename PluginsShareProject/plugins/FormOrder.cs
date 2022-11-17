using InternetShopBusinessLogic.BusinessLogic;
using InternetShopContracts.BindingModels;
using InternetShopContracts.BusinessLogicsContracts;
using InternetShopContracts.ViewModels;
using InternetShopDatabaseImplement.implements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluginsShareProject.plugins
{
    public partial class FormOrder : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        private readonly IOrderLogic orderLogic;
        private readonly IOrderStatusLogic orderStatusLogic;
        private bool DataChanged;
        public FormOrder(IOrderLogic orderLogic, IOrderStatusLogic orderStatusLogic)
        {
            InitializeComponent();
            this.orderLogic = orderLogic;
            this.orderStatusLogic = orderStatusLogic;
            DataChanged = false;
            var data = orderStatusLogic.Read(null);
            var list = data.Select(l => l.Status).ToList();
            userControlComboBox1.InsertData(list);
            textBox1.TextChanged += Changed;
            richTextBox1.TextChanged += Changed;
            userControlComboBox1.SetChangeItemEvent += Changed;
            numericTextBox1.AddListener(Changed);
        }

        private void Changed(object sender, EventArgs e)
        {
            DataChanged = true;
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = orderLogic.Read(new OrderBindingModel { Id = id })?[0];
                    int? sum;
                    if (view.OrderSum != "оплачен скидками")
                    {
                        sum = Convert.ToInt32(view.OrderSum);
                    }

                    if (view != null)
                    {
                        textBox1.Text = view.CustomerFIO;
                        richTextBox1.Text = view.ProductDescription;
                        userControlComboBox1.SelectedValue = view.OrderStatus;
                        if (view.OrderSum != "оплачен скидками")
                        {
                            numericTextBox1.NumberValue = Convert.ToInt32(view.OrderSum);
                        }
                        else
                        {
                            numericTextBox1.NumberValue = null;
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (DataChanged)
            {
                if (MessageBox.Show("Сохранить изменения перед закрытием?", "Закрыть", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Save();
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            if (textBox1.Text != "" && richTextBox1.Text != "" && userControlComboBox1.SelectedValue != null)
            {
                if (id != null)
                {
                    orderLogic.CreateOrUpdate(new OrderBindingModel()
                    {
                        Id = id,
                        CustomerFIO = textBox1.Text,
                        ProductDescription = richTextBox1.Text,
                        OrderStatus = userControlComboBox1.SelectedValue,
                        OrderSum = numericTextBox1.NumberValue != null ? numericTextBox1.NumberValue.ToString() : "оплачен скидками"
                    });                }
                else
                {
                    orderLogic.CreateOrUpdate(new OrderBindingModel()
                    {
                        CustomerFIO = textBox1.Text,
                        ProductDescription = richTextBox1.Text,
                        OrderStatus = userControlComboBox1.SelectedValue,
                        OrderSum = numericTextBox1.NumberValue != null ? numericTextBox1.NumberValue.ToString() : "оплачен скидками"
                    });
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Все поля, кроме суммы, являются обязательными");
            }
        }
    }
}

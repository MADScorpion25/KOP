using InternetShopBusinessLogic.BusinessLogic;
using InternetShopContracts.BindingModels;
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

namespace InternetShopApp.plugins
{
    public partial class FormOrder : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        private OrderLogic orderLogic;
        private OrderStatusLogic orderStatusLogic;
        private bool DataChanged;
        public FormOrder(OrderStorage orderStorage, OrderStatusStorage orderStatusStorage)
        {
            InitializeComponent();
            DataChanged = false;
            orderLogic = new OrderLogic(orderStorage);
            orderStatusLogic = new OrderStatusLogic(orderStatusStorage);
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
                    if (view != null)
                    {
                        textBox1.Text = view.CustomerFIO;
                        richTextBox1.Text = view.ProductDescription;
                        userControlComboBox1.SelectedValue = view.OrderStatus;
                        numericTextBox1.Text = view.OrderSum != null ? view.OrderSum.ToString() : "";
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

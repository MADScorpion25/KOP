using InternetShopBusinessLogic.BusinessLogic;
using InternetShopContracts.BindingModels;
using InternetShopContracts.BusinessLogicsContracts;
using InternetShopContracts.ViewModels;
using InternetShopDatabaseImplement.implements;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PluginsShareProject.plugins
{
    public partial class FormOrderStatus : Form
    {
        private readonly IOrderStatusLogic orderStatusLogic;
        List<OrderStatusViewModel> data;

        public FormOrderStatus(IOrderStatusLogic orderStatusLogic)
        {
            InitializeComponent();
            this.orderStatusLogic = orderStatusLogic;
        }
        private void LoadData()
        {
            try
            {
                data = orderStatusLogic.Read(null);
                if (data != null)
                {
                    dataGridViewStatuses.DataSource = data;
                    dataGridViewStatuses.Columns[0].Visible = false;
                    dataGridViewStatuses.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormOrderStatus_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void dataGridViewStatuses_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var typeName = (string)dataGridViewStatuses.CurrentRow.Cells[1].Value;
            if (!string.IsNullOrEmpty(typeName))
            {
                if (dataGridViewStatuses.CurrentRow.Cells[0].Value != null)
                {
                    orderStatusLogic.CreateOrUpdate(new OrderStatusBindingModel()
                    {
                        Id = Convert.ToInt32(dataGridViewStatuses.CurrentRow.Cells[0].Value),
                        Status = (string)dataGridViewStatuses.CurrentRow.Cells[1].EditedFormattedValue
                    });
                }
                else
                {
                    orderStatusLogic.CreateOrUpdate(new OrderStatusBindingModel()
                    {
                        Status = (string)dataGridViewStatuses.CurrentRow.Cells[1].EditedFormattedValue
                    });
                }
            }
            else
            {
                MessageBox.Show("Введена пустая строка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
        }
        private void dataGridViewStatuses_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Insert)
            {
                if (dataGridViewStatuses.Rows.Count == 0)
                {
                    data.Add(new OrderStatusViewModel());
                    dataGridViewStatuses.DataSource = new List<OrderStatusViewModel>(data);
                    dataGridViewStatuses.CurrentCell = dataGridViewStatuses.Rows[0].Cells[1];
                    return;
                }
                if (dataGridViewStatuses.Rows[dataGridViewStatuses.Rows.Count - 1].Cells[1].Value != null)
                {
                    data.Add(new OrderStatusViewModel());
                    dataGridViewStatuses.DataSource = new List<OrderStatusViewModel>(data);
                    dataGridViewStatuses.CurrentCell = dataGridViewStatuses.Rows[dataGridViewStatuses.Rows.Count - 1].Cells[1];
                    return;
                }
            }
            if (e.KeyData == Keys.Delete)
            {
                if (MessageBox.Show("Удалить выбранный элемент", "Удаление",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    orderStatusLogic.Delete(new OrderStatusBindingModel() { Id = (int)dataGridViewStatuses.CurrentRow.Cells[0].Value });
                    LoadData();
                }
            }
        }
    }
}

using ControlLibrary;
using InternetShopBusinessLogic.BusinessLogic;
using PluginsConventionLibrary.plugins;
using InternetShopDatabaseImplement.implements;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using InternetShopContracts.BindingModels;
using NonVisualComponents;
using UnvisualComponents;
using NonVisualCompAddition;

namespace InternetShopApp.plugins
{
    class AppPluginConvension : IPluginsConvention
    {
        private TreeViewControl treeViewControl;
        private OrderLogic orderLogic;
        private OrderStorage orderStorage;
        private OrderStatusLogic orderStatusLogic;
        private OrderStatusStorage orderStatusStorage;
        public AppPluginConvension()
        {
            treeViewControl = new TreeViewControl(new List<string> { "OrderStatus", "OrderSum", "Id", "CustomerFIO" });
            orderStorage = new OrderStorage();
            orderStatusStorage = new OrderStatusStorage();
            orderLogic = new OrderLogic(orderStorage);
            orderStatusLogic = new OrderStatusLogic(new OrderStatusStorage());
        }
        public string PluginName => "Orders";

        public UserControl GetControl => treeViewControl;

        public PluginsConventionElement GetElement => treeViewControl.GetSelectedObject<OrderConvensionElement>();

        public bool CreateChartDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
            {
                var data = orderLogic.Read(null);
                var statusData = orderStatusLogic.Read(null);
                Dictionary<string, int> stat = new Dictionary<string, int>();
                foreach (var status in statusData)
                {
                    stat.Add(status.Status, 0);
                }
                foreach (var order in data)
                {
                    stat[order.OrderStatus] = stat[order.OrderStatus] + 1;
                }
                DocumentWithDiagram diaDoc = new DocumentWithDiagram();
                diaDoc.CreateCircleDiagrammExcel(saveDocument.FileName, "Кол-во заказов по статусам", "Статистика заказов", stat, LegendPosition.Top);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool CreateSimpleDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
            {
                var data = orderLogic.Read(new OrderBindingModel { OrderSum = null });
                string[] info = new string[data.Count];
                int i = 0;
                foreach (var order in data)
                {
                    info[i] = order.CustomerFIO + " - " + order.ProductDescription;
                }
                TextDocument doc = new TextDocument();
                doc.CreateWordChart(saveDocument.FileName, "Информация об оплаченных заказах", info);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool CreateTableDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
            {
                var data = orderLogic.Read(null);
                SavePdfWithHeaders pdfTableDoc = new SavePdfWithHeaders();
                pdfTableDoc.CreatePdf(saveDocument.FileName, "Информация по заказам", new List<string> { "2cm", "4cm", "4cm", "4cm" }, new List<string> { "1cm", "1cm", "1cm", "1cm" },
                    new List<Tuple<string, string>>
                    {
                    new Tuple<string, string>("ID", "Id"),
                    new Tuple<string, string>("ФИО заказчика", "CustomerFIO"),
                    new Tuple<string, string>("Статус заказа", "OrderStatus"),
                    new Tuple<string, string>("Сумма заказа", "OrderSum")
                    }, data);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool DeleteElement(PluginsConventionElement element)
        {
            try
            {
                orderLogic.Delete(new OrderBindingModel() { Id = element.Id });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public Form GetForm(PluginsConventionElement element)
        {
            FormOrder formProduct = new FormOrder(orderStorage, orderStatusStorage);
            if (element != null)
            {
                formProduct.Id = element.Id;
            }
            return formProduct;
        }

        public void ReloadData()
        {
            treeViewControl = new TreeViewControl(new List<string> { "OrderStatus", "OrderSum", "Id", "CustomerFIO" });
            var data = orderLogic.Read(null);
            treeViewControl.RecursiveFill(data);
        }
    }
}

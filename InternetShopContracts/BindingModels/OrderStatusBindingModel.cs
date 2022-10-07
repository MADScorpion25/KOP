using System;
using System.Collections.Generic;
using System.Text;

namespace InternetShopContracts.BindingModels
{
    public class OrderStatusBindingModel
    {
        public int? Id { get; set; }
        public string Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace InternetShopContracts.BindingModels
{
    public class OrderBindingModel
    {
        public int? Id { get; set; }
        public string CustomerFIO { get; set; }
        public string ProductDescription { get; set; }
        public string OrderStatus { get; set; }
        public string OrderSum { get; set; }
    }
}

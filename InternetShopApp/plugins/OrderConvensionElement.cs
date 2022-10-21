using PluginsConventionLibrary.plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShopApp.plugins
{
    class OrderConvensionElement : PluginsConventionElement
    {
        public string CustomerFIO { get; set; }
        public string ProductDescription { get; set; }
        public string OrderStatus { get; set; }
        public string OrderSum { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InternetShopDatabaseImplement.models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string CustomerFIO { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public string OrderStatus { get; set; }
        public string OrderSum { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InternetShopDatabaseImplement.models
{
    public class OrderStatus
    {
        public int Id { get; set; }
        [Required]
        public string Status { get; set; }
    }
}

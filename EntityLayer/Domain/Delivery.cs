﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Domain
{
    public class Delivery
    {
        [Key]
        public int Id { get; set; }
        public double TotalPrice { get; set; } // Bir gönderideki toplam tutarı gösterir. Ama ürün bazında değil.
        public int TotalQuantity { get; set; } // Bir gönderideki toplam ürün sayısını gösterir. Ama ürün bazında değil.
        public string Adress { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public bool IsDraft { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public ICollection<DeliveryItem> DeliveryDetail { get; }

    }
}

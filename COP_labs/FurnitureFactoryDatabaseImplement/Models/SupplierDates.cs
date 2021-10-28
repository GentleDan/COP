using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FurnitureFactoryDatabaseImplement.Models
{
    public class SupplierDates
    {
        public int Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}

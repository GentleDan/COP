using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureFactoryDatabaseImplement.Models
{
   public class Supplier
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ManagerFullName { get; set; }
        [Required]
        public int DeliveryFrequency { get; set; }
        [ForeignKey("SupplierDateId")]
        public virtual List<SupplierDates> SupplierDates { get; set; }
    }
}

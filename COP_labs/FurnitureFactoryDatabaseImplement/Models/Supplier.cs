using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace FurnitureFactoryDatabaseImplement.Models
{
   public class Supplier
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DeliveryDate { get; set; }
        [Required]
        public string ManagerFullName { get; set; }
        [Required]
        public int DeliveryFrequency { get; set; }
    }
}

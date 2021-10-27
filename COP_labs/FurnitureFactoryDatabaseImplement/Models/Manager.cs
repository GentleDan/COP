using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FurnitureFactoryDatabaseImplement.Models
{
    public class Manager
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

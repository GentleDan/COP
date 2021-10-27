using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureFactoryBusinessLogic.ViewModels
{
    public class SupplierViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DeliveryDate { get; set; }
        public string ManagerFullName { get; set; }
        public int DeliveryFrequency { get; set; }
    }
}

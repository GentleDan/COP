using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureFactoryBusinessLogic.BindingModels
{
    public class SupplierBindingModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string ManagerFullName { get; set; }
        public List<DateTime> DeliveryDate { get; set; }
        public int DeliveryFrequency { get; set; }
    }
}

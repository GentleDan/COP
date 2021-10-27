using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FurnitureFactoryBusinessLogic.ViewModels
{
    public class ManagerViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
    }
}

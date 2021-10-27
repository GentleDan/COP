using System;
using System.Collections.Generic;
using System.Text;
using FurnitureFactoryBusinessLogic.BindingModels;
using FurnitureFactoryBusinessLogic.ViewModels;

namespace FurnitureFactoryBusinessLogic.Interfaces
{
    public interface ISupplierStorage
    {
        List<SupplierViewModel> GetFullList();
        List<SupplierViewModel> GetFilteredList(SupplierBindingModel model);
        SupplierViewModel GetElement(SupplierBindingModel model);
        void Insert(SupplierBindingModel model);
        void Update(SupplierBindingModel model);
        void Delete(SupplierBindingModel model);
    }
}

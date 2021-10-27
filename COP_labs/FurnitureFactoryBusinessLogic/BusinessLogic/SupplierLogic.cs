using System;
using System.Collections.Generic;
using System.Text;
using FurnitureFactoryBusinessLogic.BindingModels;
using FurnitureFactoryBusinessLogic.ViewModels;
using FurnitureFactoryBusinessLogic.Interfaces;

namespace FurnitureFactoryBusinessLogic.BusinessLogic
{
    public class SupplierLogic
    {
        private readonly ISupplierStorage _supplierStorage;

        public SupplierLogic(ISupplierStorage supplierStorage)
        {
            _supplierStorage = supplierStorage;
        }

        public List<SupplierViewModel> Read(SupplierBindingModel model)
        {
            if (model is null)
            {
                return _supplierStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<SupplierViewModel> { _supplierStorage.GetElement(model) };
            }
            return _supplierStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(SupplierBindingModel model)
        {
            var supplier = _supplierStorage.GetElement(new SupplierBindingModel
            {
                Name = model.Name
            });
            if (!(supplier is null) && !supplier.Id.Equals(model.Id))
            {
                throw new Exception("Уже есть поставщик с таким названием");
            }
            if (model.Id.HasValue)
            {
                _supplierStorage.Update(model);
            }
            else
            {
                _supplierStorage.Insert(model);
            }
        }
        public void Delete(SupplierBindingModel model)
        {
            var supplier = _supplierStorage.GetElement(new SupplierBindingModel
            {
                Id = model.Id
            });
            if (supplier is null)
            {
                throw new Exception("Поставщик не найден");
            }
            _supplierStorage.Delete(model);
        }
    }
}

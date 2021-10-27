using System;
using System.Collections.Generic;
using System.Text;
using FurnitureFactoryBusinessLogic.Interfaces;
using FurnitureFactoryBusinessLogic.BindingModels;
using FurnitureFactoryBusinessLogic.ViewModels;
using System.Linq;
using FurnitureFactoryDatabaseImplement.Models;

namespace FurnitureFactoryDatabaseImplement.Implements
{
    public class SupplierStorage : ISupplierStorage
    {
        public List<SupplierViewModel> GetFullList()
        {
            using (var context = new FurnitureFactoryDatabase())
            {
                return context.Suppliers.Select(rec => new SupplierViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    ManagerFullName = rec.ManagerFullName,
                    DeliveryDate = rec.DeliveryDate.ToString(),
                    DeliveryFrequency = rec.DeliveryFrequency,
                })
                .ToList();
            }
        }

        public List<SupplierViewModel> GetFilteredList(SupplierBindingModel model)
        {
            if (model is null)
            {
                return null;
            }
            using (var context = new FurnitureFactoryDatabase())
            {
                return context.Suppliers
                .Where(rec => rec.Name.Equals(model.Name))
                .Select(rec => new SupplierViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    ManagerFullName = rec.ManagerFullName,
                    DeliveryDate = rec.DeliveryDate.ToString(),
                    DeliveryFrequency = rec.DeliveryFrequency
                })
                .ToList();
            }
        }

        public SupplierViewModel GetElement(SupplierBindingModel model)
        {
            if (model is null)
            {
                return null;
            }
            using (var context = new FurnitureFactoryDatabase())
            {
                var supplier = context.Suppliers
                .FirstOrDefault(rec => rec.Name == model.Name || rec.Id == model.Id);
                return supplier is null ? null :
                new SupplierViewModel
                {
                    Id = supplier.Id,
                    Name = supplier.Name,
                    ManagerFullName = supplier.ManagerFullName,
                    DeliveryDate = supplier.DeliveryDate.ToString(),
                    DeliveryFrequency = supplier.DeliveryFrequency
                };
            }
        }

        public void Insert(SupplierBindingModel model)
        {
            using (var context = new FurnitureFactoryDatabase())
            {
                context.Suppliers.Add(CreateModel(model, new Supplier()));
                context.SaveChanges();
            }
        }

        public void Update(SupplierBindingModel model)
        {
            using (var context = new FurnitureFactoryDatabase())
            {
                var supplier = context.Suppliers.FirstOrDefault(rec => rec.Id == model.Id);
                if (supplier is null)
                {
                    throw new Exception("Поставщик не найден");
                }
                CreateModel(model, supplier);
                context.SaveChanges();
            }
        }

        public void Delete(SupplierBindingModel model)
        {
            using (var context = new FurnitureFactoryDatabase())
            {
                var supplier = context.Suppliers.FirstOrDefault(rec => rec.Id == model.Id);
                if (supplier is null)
                {
                    throw new Exception("Поставщик не найден");
                }

                context.Suppliers.Remove(supplier);
                context.SaveChanges();
            }
        }

        private Supplier CreateModel(SupplierBindingModel model, Supplier supplier)
        {
            supplier.Name = model.Name;
            supplier.ManagerFullName = model.ManagerFullName;
            supplier.DeliveryDate = model.DeliveryDate;
            supplier.DeliveryFrequency = model.DeliveryFrequency;
            return supplier;
        }
    }
}

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
                    DeliveryDate = context.SupplierDates
                    .Where(x => rec.Id == x.SupplierId).Select(y => y.DeliveryDate).ToList(),
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
                    DeliveryDate = context.SupplierDates
                    .Where(x => rec.Id == x.SupplierId).Select(y => y.DeliveryDate).ToList(),
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
                    DeliveryDate = context.SupplierDates
                    .Where(x => supplier.Id == x.SupplierId).Select(y => y.DeliveryDate).ToList(),
                    DeliveryFrequency = supplier.DeliveryFrequency
                };
            }
        }

        public void Insert(SupplierBindingModel model)
        {
            using (var context = new FurnitureFactoryDatabase())
            {
                var supplier = CreateModel(model, new Supplier());
                context.Suppliers.Add(supplier);
                context.SaveChanges();
                if (model.DeliveryDate != null)
                {
                    context.SupplierDates.AddRange(model.DeliveryDate.Select(x => new SupplierDates
                    { SupplierId = supplier.Id, DeliveryDate = x }).ToList());
                }
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
                context.SupplierDates
                  .RemoveRange(context.SupplierDates
                  .Where(rec => rec.SupplierId == model.Id).ToList());
                if (model.DeliveryDate != null && model.DeliveryDate.Count > 0)
                    context.SupplierDates.AddRange(model.DeliveryDate.Select(x => new SupplierDates
                { SupplierId = (int) model.Id, DeliveryDate = x }).ToList());
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
                context.SupplierDates
                 .RemoveRange(context.SupplierDates
                 .Where(rec => rec.SupplierId == model.Id).ToList());
                context.SaveChanges();
            }
        }

        private Supplier CreateModel(SupplierBindingModel model, Supplier supplier)
        {
            supplier.Name = model.Name;
            supplier.ManagerFullName = model.ManagerFullName;
            supplier.DeliveryFrequency = model.DeliveryFrequency;
            return supplier;
        }
    }
}

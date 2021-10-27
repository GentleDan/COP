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
    public class ManagerStorage : IManagerStorage
    {
        public List<ManagerViewModel> GetFullList()
        {
            using (var context = new FurnitureFactoryDatabase())
            {
                return context.Managers.Select(rec => new ManagerViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name
                })
                .ToList();
            }
        }

        public ManagerViewModel GetElement(ManagerBindingModel model)
        {
            if (model is null)
            {
                return null;
            }
            using (var context = new FurnitureFactoryDatabase())
            {
                var manager = context.Managers
                .FirstOrDefault(rec => rec.Name == model.Name || rec.Id == model.Id);
                return manager is null ? null :
                new ManagerViewModel
                {
                    Id = manager.Id,
                    Name = manager.Name
                };
            }
        }

        public void Insert(ManagerBindingModel model)
        {
            using (var context = new FurnitureFactoryDatabase())
            {
                Manager newManager = new Manager
                {
                    Name = model.Name
                };
                context.Managers.Add(newManager);
                context.SaveChanges();
            }
        }

        public void Update(ManagerBindingModel model)
        {
            using (var context = new FurnitureFactoryDatabase())
            {
                var manager = context.Managers.FirstOrDefault(rec => rec.Id == model.Id);
                if (manager is null)
                {
                    throw new Exception("Тип операции не найден");
                }
                manager.Name = model.Name;
                context.SaveChanges();
            }
        }

        public void Delete(ManagerBindingModel model)
        {
            using (var context = new FurnitureFactoryDatabase())
            {
                var manager = context.Managers.FirstOrDefault(rec => rec.Id == model.Id);
                if (manager is null)
                {
                    throw new Exception("Тип операции не найден");
                }
                else
                {
                    context.Managers.Remove(manager);
                    context.SaveChanges();
                }
            }
        }
    }
}

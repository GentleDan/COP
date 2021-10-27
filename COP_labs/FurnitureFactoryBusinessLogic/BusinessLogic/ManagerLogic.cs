using System;
using System.Collections.Generic;
using System.Text;
using FurnitureFactoryBusinessLogic.BindingModels;
using FurnitureFactoryBusinessLogic.ViewModels;
using FurnitureFactoryBusinessLogic.Interfaces;

namespace FurnitureFactoryBusinessLogic.BusinessLogic
{
    public class ManagerLogic
    {
        private readonly IManagerStorage _managerStorage;

        public ManagerLogic(IManagerStorage managerStorage)
        {
            _managerStorage = managerStorage;
        }

        public List<ManagerViewModel> Read(ManagerBindingModel model)
        {
            if (model is null)
            {
                return _managerStorage.GetFullList();
            }
            return new List<ManagerViewModel> { _managerStorage.GetElement(model) };
        }

        public void CreateOrUpdate(ManagerBindingModel model)
        {
            var manager = _managerStorage.GetElement(new ManagerBindingModel
            {
                Name = model.Name
            });
            if (!(manager is null) && !manager.Id.Equals(model.Id))
            {
                throw new Exception("Уже есть такой менеджер");
            }
            if (model.Id.HasValue)
            {
                _managerStorage.Update(model);
            }
            else
            {
                _managerStorage.Insert(model);
            }
        }
        public void Delete(ManagerBindingModel model)
        {
            var organizationType = _managerStorage.GetElement(new ManagerBindingModel
            {
                Id = model.Id
            });
            if (organizationType is null)
            {
                throw new Exception("Менеджер не найден");
            }
            _managerStorage.Delete(model);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using FurnitureFactoryBusinessLogic.BindingModels;
using FurnitureFactoryBusinessLogic.ViewModels;

namespace FurnitureFactoryBusinessLogic.Interfaces
{
    public interface IManagerStorage
    {
        List<ManagerViewModel> GetFullList();
        ManagerViewModel GetElement(ManagerBindingModel model);
        void Insert(ManagerBindingModel model);
        void Update(ManagerBindingModel model);
        void Delete(ManagerBindingModel model);
    }
}

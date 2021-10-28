using ComponentLibrary.models;
using FurnitureFactoryBusinessLogic.BindingModels;
using FurnitureFactoryBusinessLogic.HelperModels;
using FurnitureFactoryBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FurnitureFactoryBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly ISupplierStorage _supplierStorage;
        private readonly IManagerStorage _managerStorage;

        public ReportLogic(ISupplierStorage supplierStorage, IManagerStorage managerStorage)
        {
            _supplierStorage = supplierStorage;
            _managerStorage = managerStorage;
        }
    }
}

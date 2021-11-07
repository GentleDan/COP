using ClassLibraryComponentsFilippov.HelperModels;
using FurnitureFactoryBusinessLogic.Interfaces;
using FurnitureFactoryBusinessLogic.ViewModels;
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

        public List<string[,]> GetArraySuppliersDeliveryDates()
        {
            var list = _supplierStorage.GetFullList();
            var buffer = new List<string[,]>();
            foreach (var item in list)
            {
                var array = new string[1, 5];
                for (var i = 0; i < item.DeliveryDate.Count; i++)
                {
                    array[0, i] = item.Name + " : " + item.DeliveryDate[i].ToString();
                }
                buffer.Add(array);
            }
            return buffer;
        }

        public List<Series> GetManagersFrequency()
        {
            var listManagers = _managerStorage.GetFullList();
            var listSupp = _supplierStorage.GetFullList();          
            var result = new List<Series>();
            foreach (var man in listManagers)
            {
                var values = new List<double>();
                var series = new Series
                {
                    Name = man.Name
                };

                foreach (var supp in listSupp)
                {
                    if (supp.ManagerFullName.Equals(man.Name))
                    {
                        values.Add(supp.DeliveryFrequency);
                    }
                    else
                    {
                        values.Add(0);
                    }
                }
                series.YAxisValues = values.ToArray();
                result.Add(series);
            }
            return result;
        }

        public string[] GetCount()
        {
            //var result = new List<string>();
            var listSupp = _supplierStorage.GetFullList().Select(x => x.Name).ToArray();
            return listSupp;
        }

        public List<SupplierViewModel> GetSuppliers()
        {
            return _supplierStorage.GetFullList();
        }

    }
}

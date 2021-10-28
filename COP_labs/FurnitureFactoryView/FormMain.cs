using ClassLibraryComponentsFilippov.HelperModels;
using FurnitureFactoryBusinessLogic.BindingModels;
using FurnitureFactoryBusinessLogic.BusinessLogic;
using FurnitureFactoryBusinessLogic.ViewModels;
using FurnitureFactoryBusinessLogic.HelperModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using ClassLibraryControlsFilippov;
using System.Linq;

namespace FurnitureFactoryView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly SupplierLogic _supplierLogic;
        private readonly ReportLogic _reportLogic;
        private ControlOutputListBoxLayout layout = new ControlOutputListBoxLayout
        {
            EndSign = '}',
            StartSign = '{',
            Layout = "Название - {Name}, Идентификатор - {Id}, Дата поставки - {DeliveryDate}, ФИО менеджера - {ManagerFullName}, Частота поставок - {DeliveryFrequency}"
        };

        public FormMain(SupplierLogic supplierLogic, ReportLogic reportLogic)
        {
            InitializeComponent();
            _supplierLogic = supplierLogic;
            _reportLogic = reportLogic;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            this.Controls.Remove(controlOutputlListBox);
            controlOutputlListBox = new ControlOutputlListBox
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(controlOutputlListBox);
            controlOutputlListBox.SetLayout(layout);
            try
            {
                var list = _supplierLogic.Read(null);
                int placePozition = 0;
                foreach (var supplier in list)
                {
                    if (placePozition < list.Count())
                    {
                        controlOutputlListBox.Insert(supplier, placePozition, "Name");
                        controlOutputlListBox.Insert(supplier, placePozition, "Id");
                        controlOutputlListBox.Insert(supplier, placePozition, "DeliveryDate");
                        controlOutputlListBox.Insert(supplier, placePozition, "ManagerFullName");
                        controlOutputlListBox.Insert(supplier, placePozition, "DeliveryFrequency");
                        placePozition++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void AddSupplier(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSupplier>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
        private void UpdateSupplier(object sender, EventArgs e)
        {
            var selectedItem = controlOutputlListBox.GetSelectedItem<SupplierStringModel>();
            if (selectedItem is null || string.IsNullOrEmpty(selectedItem.Name) || selectedItem.Id is null) return;
            var form = Container.Resolve<FormSupplier>();
            form.SupplierStringModel = selectedItem;
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
        private void DeleteSupplier(object sender, EventArgs e)
        {
            var selectedItem = controlOutputlListBox.GetSelectedItem<SupplierStringModel>();
            if (selectedItem is null || string.IsNullOrEmpty(selectedItem.Name) || selectedItem.Id is null) return;

            if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(controlOutputlListBox.GetSelectedItem<SupplierStringModel>()?.Id);
                try
                {
                    _supplierLogic.Delete(new SupplierBindingModel() { Id = id });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadData();
            }
        }
        private void OpenManagersForm(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormManagers>();
            form.ShowDialog();
        }
    }
}

using FurnitureFactoryBusinessLogic.BindingModels;
using FurnitureFactoryBusinessLogic.BusinessLogic;
using FurnitureFactoryBusinessLogic.HelperModels;
using System;
using System.Linq;
using System.Windows.Forms;
using Unity;

namespace FurnitureFactoryView
{
    public partial class FormSupplier : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public SupplierStringModel SupplierStringModel { set => _view = value; }
        private readonly SupplierLogic _logic;
        private readonly ManagerLogic _managerLogic;
        private SupplierStringModel _view;
        private bool Save { get; set; } = false;

        public FormSupplier(SupplierLogic logic, ManagerLogic managerLogic)
        {
            this._logic = logic;
            _managerLogic = managerLogic;
            InitializeComponent();
        }

        private void FormSupplier_Load(object sender, EventArgs e)
        {
            var list = _managerLogic.Read(null);
            var listString = list.Select(x => x.Name);
            userControlListManagerName.Items.AddRange(listString.ToArray());
            inputUserControlFrequency.Value = 1;
            if (!(_view is null))
            {
                try
                {
                    var id = Convert.ToInt32(_view.Id);
                    var item = _logic.Read(new SupplierBindingModel { Id = id })?[0];
                    if (item is null) return;
                    textBoxName.Text = item.Name;
                    dateTimePickerDelivery.Text = item.DeliveryDate;
                    userControlListManagerName.SelectedItem = item.ManagerFullName;
                    inputUserControlFrequency.Value = item.DeliveryFrequency;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            var name = textBoxName.Text;
            var managerName = userControlListManagerName.SelectedItem;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(managerName))
            {
                MessageBox.Show("Выберите менеджера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int deliveryFrequency;
            try
            {
                deliveryFrequency = (int)inputUserControlFrequency.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            DateTime deliveryDate;
            try
            {
                deliveryDate = dateTimePickerDelivery.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            try
            {
                int? id = null;
                if (!(_view is null))
                {
                    id = Convert.ToInt32(_view.Id);
                }
                _logic.CreateOrUpdate(new SupplierBindingModel
                {
                    Id = id,
                    Name = name,
                    DeliveryDate = deliveryDate,
                    ManagerFullName = managerName,
                    DeliveryFrequency = deliveryFrequency
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Save = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private bool CloseWindow()
        {
            bool result = true;
            if (Save) return result;
            var name = textBoxName.Text;
            var deliveryDate = dateTimePickerDelivery.Text;
            var managerName = userControlListManagerName.SelectedItem;
            int deliveryFrequency;
            try
            {
                deliveryFrequency = (int) inputUserControlFrequency.Value;
            }
            catch (Exception)
            { }
            if (MessageBox.Show("Данные не сохранены", "Выйти?", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    result = false;
                }
            return result;
        }


        private void FormSupplier_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CloseWindow())
            {
                e.Cancel = true;
                DialogResult = DialogResult.Cancel;
                return;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

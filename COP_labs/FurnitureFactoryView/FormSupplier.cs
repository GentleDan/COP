using FurnitureFactoryBusinessLogic.BindingModels;
using FurnitureFactoryBusinessLogic.BusinessLogic;
using FurnitureFactoryBusinessLogic.HelperModels;
using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public string ManagerFullName { get; set; }
        public int DeliveryFrequency { get; set; }
        public DateTime? DeliveryDate { get; set; }
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
                    string[] bufferArray = new string[item.DeliveryDate.Count];
                    for(int i = 0; i < item.DeliveryDate.Count; i++)
                    {
                        bufferArray[i] = item.DeliveryDate[i].ToString();
                    }
                    textBoxName.Text = item.Name;
                    userControlListManagerName.SelectedItem = item.ManagerFullName;
                    inputUserControlFrequency.Value = item.DeliveryFrequency;
                    listBoxDates.Items.AddRange(bufferArray);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
            Name = textBoxName.Text;
            ManagerFullName = userControlListManagerName.SelectedItem;
            DeliveryFrequency = (int) inputUserControlFrequency.Value;
            DeliveryDate = dateTimePickerDelivery.Value;
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
            int deliveryFrequency = 1;
            try
            {
                deliveryFrequency = (int)inputUserControlFrequency.Value;
            }
            catch (Exception)
            {
                MessageBox.Show("Введите целое число от 1 до 12", "Ошибка", MessageBoxButtons.OK,
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
                List<DateTime> bufferList = new List<DateTime>();
                foreach(var item in listBoxDates.Items)
                {
                    bufferList.Add(DateTime.Parse(item.ToString()));
                }
                _logic.CreateOrUpdate(new SupplierBindingModel
                {
                    Id = id,
                    Name = name,
                    ManagerFullName = managerName,
                    DeliveryDate = bufferList,
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
            var deliveryDate = dateTimePickerDelivery.Value;
            var managerName = userControlListManagerName.SelectedItem;
            int deliveryFrequency = 1;
            try
            {
                deliveryFrequency = (int) inputUserControlFrequency.Value;
            }
            catch (Exception)
            { }
            if (!CheckData(name, managerName, deliveryFrequency, deliveryDate))
            {
                if (MessageBox.Show("Данные не сохранены", "Выйти?", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    result = false;
                }
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

        private void buttonAddDate_Click(object sender, EventArgs e)
        {
            listBoxDates.Items.Add(dateTimePickerDelivery.Value.ToString());
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBoxDates.Items.Clear();
        }
        public bool CheckData(string name, string managerFullName, int deliveryFrequency, DateTime? deliveryDate)
        {
            return name.Equals(Name)
                && managerFullName.Equals(ManagerFullName)
                && deliveryFrequency.Equals(DeliveryFrequency)
                && DeliveryDate.Equals(deliveryDate);
        }
    }
}

using ClassLibraryComponentsFilippov.HelperModels;
using ClassLibraryControlsFilippov;
using ComponentLibrary;
using ComponentLibrary.models;
using FurnitureFactoryBusinessLogic.BindingModels;
using FurnitureFactoryBusinessLogic.BusinessLogic;
using FurnitureFactoryBusinessLogic.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Unity;
using ViberMessangerPlugin;

namespace FurnitureFactoryView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly SupplierLogic _supplierLogic;
        private readonly ReportLogic _reportLogic;
        private ViberPlugin vp;
        private readonly ControlOutputListBoxLayout layout = new ControlOutputListBoxLayout
        {
            EndSign = '}',
            StartSign = '{',
            Layout = "Название - {Name}; Идентификатор - {Id}; ФИО менеджера - {ManagerFullName}; Частота поставок - {DeliveryFrequency}"
        };

        public FormMain(SupplierLogic supplierLogic, ReportLogic reportLogic)
        {
            InitializeComponent();
            _supplierLogic = supplierLogic;
            _reportLogic = reportLogic;
            vp = new ViberPlugin();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
            vp.Init();
            var jop = vp.GetAccountInfoAsync();
            Console.WriteLine(jop.ToString());
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
            if (selectedItem is null || string.IsNullOrEmpty(selectedItem.Name) || selectedItem.Id is null)
            {
                return;
            }

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
            if (selectedItem is null || string.IsNullOrEmpty(selectedItem.Name) || selectedItem.Id is null)
            {
                return;
            }

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

        private void OpenExcelreportForm(object sender, EventArgs e)
        {
           /* var form = new ExcelPluginReport.FormReport();
            form.ShowDialog();*/
        }

        private void CreateSimpleDocument(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "xlsx file | *.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(sfd.FileName))
                {
                    MessageBox.Show("Путь не указан", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (componentExcelTables.CreateDoc(new WindowsFormsComponentLibrary.Models.ExcelInfo
                { FileName = sfd.FileName, Data = _reportLogic.GetArraySuppliersDeliveryDates(), Title = "Отчет по поставщикам с датами" }))
                {
                    MessageBox.Show("Файл создан успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Произошла непредвиденная ошибка", "Не успех", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CreateDocumentTable(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "doc file | *.doc";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(sfd.FileName))
                {
                    MessageBox.Show("Путь не указан", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                DocWithTable doc = new DocWithTable();
                var headers = new List<TableHeaderRowInfo>
            {
                new TableHeaderRowInfo("Идентификатор", 500, "Id"),
                new TableHeaderRowInfo("Название", 1000, "Name"),
                new TableHeaderRowInfo("ФИО менеджера", 1000, "ManagerFullName"),
                new TableHeaderRowInfo("Частота поставок в году", 500, "DeliveryFrequency")
            };

                var groups = new List<GroupInfo>
            {
                new GroupInfo("Сводка", 2, 3)
            };

                var items = _reportLogic.GetSuppliers().Select(x => new TableViewModel { Id = x.Id.ToString(), Name = x.Name, DeliveryFrequency = x.DeliveryFrequency.ToString(), ManagerFullName = x.ManagerFullName }).ToList();

                var tableInfo = new TableInfo<TableViewModel>
                {
                    FilePath = sfd.FileName,
                    Header = "Отчет по поставщикам",
                    HeaderInfoList = headers,
                    GroupInfoList = groups,
                    Items = items
                };
                doc.GenerateDoc(tableInfo);
                MessageBox.Show("Файл создан успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CreateDocumentChart(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "pdf file | *.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(sfd.FileName))
                {
                    MessageBox.Show("Путь не указан", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (componentDiagramPdf.CreateDocument(new DiagramPdfParameters
                { Series = _reportLogic.GetManagersFrequency(), ChartAreaLegend = ClassLibraryComponentsFilippov.Enums.ChartAreaLegend.Right, DiagramName = "Частота поставок", Path = sfd.FileName, Title = "Частота поставок по менеджерам", XAxisValues = _reportLogic.GetCount() }))
                {
                    MessageBox.Show("Файл создан успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Произошла непредвиденная ошибка", "Не успех", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}


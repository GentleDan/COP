using FurnitureFactoryBusinessLogic.BindingModels;
using FurnitureFactoryBusinessLogic.BusinessLogic;
using System;
using System.Windows.Forms;
using Unity;

namespace FurnitureFactoryView
{
    public partial class FormManagers : Form
    {
        [Dependency] 
        public new IUnityContainer Container { get; set; }
        private readonly ManagerLogic _logic;

        public FormManagers(ManagerLogic logic)
        {
            _logic = logic;
            InitializeComponent();
        }

        private void FormManagers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _logic.Read(null);
                if (list == null) return;
                dataGridViewManagers.DataSource = list;
                dataGridViewManagers.Columns[0].Visible = false;
                dataGridViewManagers.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var typeName = dataGridViewManagers[e.ColumnIndex, e.RowIndex].Value as string;
            if (!string.IsNullOrEmpty(typeName))
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    try
                    {
                        var id = (int)dataGridViewManagers[0, e.RowIndex].Value;
                        _logic.CreateOrUpdate(new ManagerBindingModel { Id = id, Name = typeName });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    LoadData();
                }));
            }
            else
            {
                MessageBox.Show("Введена пустая строка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
        }

        private void dataGridViewManagers_KeyDown(object sender, KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    {
                        int i = 0;
                        string name = "Новый менеджер";
                        try
                        {
                            while (!(_logic.Read(new ManagerBindingModel { Name = name })[0] is null))
                            {
                                i++;
                                name = "Новый менеджер " + i;
                            }

                            _logic.CreateOrUpdate(new ManagerBindingModel { Name = name });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        LoadData();
                        break;
                    }
                case Keys.Delete:
                    {
                        if (dataGridViewManagers.SelectedRows.Count == 1)
                        {
                            if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                int id = Convert.ToInt32(dataGridViewManagers.SelectedRows[0].Cells[0].Value);
                                try
                                {
                                    _logic.Delete(new ManagerBindingModel { Id = id });
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                LoadData();
                            }
                        }

                        break;
                    }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using FurnitureFactoryBusinessLogic.PluginsLogic.Managers;
using FurnitureFactoryBusinessLogic.PluginsLogic.HelperModels;
using FurnitureFactoryBusinessLogic.PluginsLogic.Interfaces;

namespace FurnitureFactoryView
{
    public partial class FormMessenger : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private IMessengerPlugin _messenger;
        private PluginMessengerManager _manager;

        public FormMessenger(PluginMessengerManager manager)
        {
            _manager = manager;
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            _messenger = _manager.plugins[comboBoxPlugin.Text];
            _messenger.Connect(new SenderConfigurationModel { AuthToken = "4e63c2204067d53d-e4fd7c979ddc0f3a-49441fdce80c1d02" });
        }

        private void FormReportPlugin_Load(object sender, EventArgs e)
        {
            if (_manager.Headers is null || _manager.Headers.Count.Equals(0)) return;
            comboBoxPlugin.Items.AddRange(_manager.Headers.ToArray());
            comboBoxPlugin.Text = comboBoxPlugin.Items[0].ToString();
        }

        private void buttonSendMessage_Click(object sender, EventArgs e)
        {
            _messenger = _manager.plugins[comboBoxPlugin.Text];
            _messenger.SendMessage(new SendMessageModel { UserId = "gMCfMkwEiq1WeXXexUYdkQ==", Text = "Привет, красавчик!" });
        }
    }
}

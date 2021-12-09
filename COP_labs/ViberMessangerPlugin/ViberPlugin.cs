using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureFactoryBusinessLogic.PluginsLogic.Interfaces;
using FurnitureFactoryBusinessLogic.PluginsLogic.HelperModels;
using System.Drawing;
using System.Windows.Forms;

namespace ViberMessangerPlugin
{
    [Export(typeof(IMessengerPlugin))]
    public class ViberPlugin : IMessengerPlugin
    {   
        public string PluginType => "ViberMessenger";

        private List<(string, string)> some_errors = new List<(string, string)>();

        public IEnumerable<(string Title, string Message)> Errors => some_errors;


        public IEnumerable<(string Title, string Message)> Connect(SenderConfigurationModel config)
        {
            try
            {
                var form = new FormInfo(config);
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                {
                    MessageBox.Show("Данные получены!", "Получеие данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return null;
            }
            catch (Exception e)
            {
                some_errors.Add(("Ошибка", e.Message));

                return null;
            }
        }

        public void SendMessage(SendMessageModel message)
        {
            try
            {
                var form = new FormSendMessege(message);
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                {
                    MessageBox.Show("Сообщение было успешно отправлено!", "Отправка сообщения", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Console.WriteLine(message.Text);
            }
            catch (Exception e)
            {
                some_errors.Add(("Ошибка", e.Message));
            }
        }
    }
}

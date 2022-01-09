using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FurnitureFactoryBusinessLogic.PluginsLogic.HelperModels;
using Microsoft.Extensions.Configuration;
using Viber.Bot;

namespace ViberMessangerPlugin
{
    public partial class FormSendMessege : Form
    {
        private ViberBotClient _viberBotClient;
        private string SenderName { get; set; }
        public FormSendMessege(SendMessageModel message)
        {
            InitializeComponent();
            textBoxReciever.Text = message.UserId;
            textBoxMessege.Text = message.Text;
            _viberBotClient = new ViberBotClient(message.AuthToken);
            SenderName = message.BotName;
        }

        public async Task SendTextMessageAsyncTest()
        {
            var result = await _viberBotClient.SendTextMessageAsync(new TextMessage
            {
                Receiver = textBoxReciever.Text,
                Sender = new UserBase
                {
                    Name = SenderName
                },
                Text = textBoxMessege.Text
            });
            return;
        }
        private void buttonSendMessege_Click(object sender, EventArgs e)
        {
           var result = SendTextMessageAsyncTest();
            if(result != null)
            {
               DialogResult = DialogResult.OK;
            }
        }
    }
}

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
        string authToken = "4e63c2204067d53d-e4fd7c979ddc0f3a-49441fdce80c1d02";
        public FormSendMessege(SendMessageModel message)
        {
            InitializeComponent();
            textBoxReciever.Text = message.UserId;
            textBoxMessege.Text = message.Text;
            _viberBotClient = new ViberBotClient(authToken);
        }

        public async Task SendTextMessageAsyncTest()
        {
            var result = await _viberBotClient.SendTextMessageAsync(new TextMessage
            {
                Receiver = textBoxReciever.Text,
                Sender = new UserBase
                {
                    Name = "Frost1kBot"
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

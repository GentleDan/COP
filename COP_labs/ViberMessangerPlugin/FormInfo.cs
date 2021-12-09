using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FurnitureFactoryBusinessLogic.PluginsLogic.HelperModels;
using Viber.Bot;

namespace ViberMessangerPlugin
{
    public partial class FormInfo : Form
    {
        private string authToken;
        public FormInfo(SenderConfigurationModel config)
        {
            InitializeComponent();
            authToken = config.AuthToken;
        }

        private void buttonGetInfo_Click(object sender, EventArgs e)
        {
            var _viberBotClient = new ViberBotClient(authToken);
            _ = GetAccountInfoAsyncTest(_viberBotClient);
        }

        public async Task GetAccountInfoAsyncTest(ViberBotClient viberBotClient)
        {
            var result = await viberBotClient.GetAccountInfoAsync();
            labelName.Text = result.Name;
            labelToken.Text = authToken;
            labelOwner.Text = result.Members.FirstOrDefault().Name;
            labelSubs.Text = result.SubscribersCount.ToString();
            labelWebhook.Text = result.Webhook;
            return;
        }

    }
}

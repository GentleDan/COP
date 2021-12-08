using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureFactoryBusinessLogic.PluginsLogic.HelperModels;
using FurnitureFactoryBusinessLogic.Interfaces;
using Viber.Bot;

namespace ViberMessangerPlugin
{
    public class ViberPlugin
    {
        private IViberBotClient viberBot;

        private string authToken = "4e560020cfa7e1d1-4df7add43a4a5937-3ec7386734e452b4";
        private string webhook = "aboba";
        private string admionId = "ovbQi9yxJ+Jvb9yGw260dg==";

        public void Init()
        {
            viberBot = new ViberBotClient(authToken);
        }

        public async Task<IAccountInfo> GetAccountInfoAsync()
        {
            var result = await viberBot.GetAccountInfoAsync();

            return result;

        }
    }
}

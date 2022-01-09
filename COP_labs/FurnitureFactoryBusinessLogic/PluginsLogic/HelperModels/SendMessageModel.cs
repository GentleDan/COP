using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureFactoryBusinessLogic.PluginsLogic.HelperModels
{
    public class SendMessageModel
    {
        public string UserId { get; set; }
        public string AuthToken { get; set; }
        public string Text { get; set; }
        public string BotName { get; set; }
    }
}

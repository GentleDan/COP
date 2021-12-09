using System;
using System.Collections.Generic;
using System.Text;
using FurnitureFactoryBusinessLogic.PluginsLogic.HelperModels;

namespace FurnitureFactoryBusinessLogic.PluginsLogic.Interfaces
{
    public interface IMessengerPlugin
    {
        string PluginType { get; }
        IEnumerable<(string Title, string Message)> Errors { get; }

        IEnumerable<(string Title, string Message)> Connect(SenderConfigurationModel config);

        void SendMessage(SendMessageModel message);
    }
}

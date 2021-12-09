using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Text;
using FurnitureFactoryBusinessLogic.PluginsLogic.Interfaces;

namespace FurnitureFactoryBusinessLogic.PluginsLogic.Managers
{
    public class PluginMessengerManager
    {
        [ImportMany(typeof(IMessengerPlugin))]
        private List<IMessengerPlugin> Plugins { get; set; }

        public readonly Dictionary<string, IMessengerPlugin> plugins = new Dictionary<string, IMessengerPlugin>();
        public List<string> Headers { get; set; }
        public PluginMessengerManager()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            var pa = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
            if (!Directory.Exists(pa)) Directory.CreateDirectory(pa);
            catalog.Catalogs.Add(new DirectoryCatalog(pa));
            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            Headers = new List<string>();
            Plugins.ForEach(x =>
            {
                if (!plugins.ContainsKey(x.PluginType))
                    plugins.Add(x.PluginType, x);
            });
            Headers.AddRange(plugins.Keys.ToList());
        }
    }
}

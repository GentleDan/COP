using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureFactoryBusinessLogic.PluginsLogic.HelperModels
{
    public class ChartConfigModel
    {
        public struct DiagramSeries
        {
            public string Name { get; set; }
            public double[] Values { get; set; }
        }

        public string Title { get; set; }

        public List<DiagramSeries> Data { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureFactoryBusinessLogic.PluginsLogic.HelperModels
{
    public class ParagraphConfigModel
    {
        public bool Bold { get; set; }
        public string Font { get; set; }
        public string Text { get; set; }
        public int[] Cells { get; set; }
    }
}

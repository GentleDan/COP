using System;
using System.Collections.Generic;
using System.Text;
using FurnitureFactoryBusinessLogic.PluginsLogic.HelperModels;

namespace FurnitureFactoryBusinessLogic.PluginsLogic.Interfaces
{
    public interface IReportPlugin
    {
        string PluginType { get; }
        void OpenFile();
        void SaveDocument(string filepath);
        void AddParagraph(ParagraphConfigModel config);
        void AddImage(ImageConfigModel config);
        void AddTable(TableConfigModel config);
        void AddChart(ChartConfigModel config);
    }
}

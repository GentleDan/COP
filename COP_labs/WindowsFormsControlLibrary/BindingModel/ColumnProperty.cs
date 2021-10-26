namespace WindowsFormsControlLibrary.BindingModel
{
    public class ColumnProperty
    {
        public string Header { get; set; }
        public string PropertyName { get; set; }
        public bool Visible { get; set; }
        public int Width { get; set; }

        public ColumnProperty(string header, string propertyName, bool visible, int width)
        {
            Header = header;
            PropertyName = propertyName;
            Visible = visible;
            Width = width;
        }
    }
}

namespace CoreApp.Models
{
    public class TextResultModel
    {
        public string ResultText { get; set; }
        public string PluginName { get; set; }

        // Constructor to initialize the properties
        public TextResultModel(string resultText, string pluginName)
        {
            ResultText = resultText;
            PluginName = pluginName;
        }
    }
}

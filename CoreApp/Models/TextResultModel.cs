namespace CoreApp.Models
{
    public class TextResultModel
    {
        public byte[] OriginalImage { get; set; }
        public string ResultText { get; set; }
        public string PluginName { get; set; }

        // Constructor to initialize the properties
        public TextResultModel(byte[] originalImage, string resultText, string pluginName)
        {
            OriginalImage = originalImage;
            ResultText = resultText;
            PluginName = pluginName;
        }
    }
}

namespace CoreApp.Models
{
    public class ImageResultModel
    {
        public byte[] OriginalImage { get; set; }
        public byte[] ProcessedImage { get; set; }
        public string PluginName { get; set; }
        public ImageResultModel(byte[] originalImage, byte[] processedImage, string pluginName)
        {
            OriginalImage = originalImage;
            ProcessedImage = processedImage;
            PluginName = pluginName;
        }
    }
}

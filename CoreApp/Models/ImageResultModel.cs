namespace CoreApp.Models
{
    public class ImageResultModel
    {
        public byte[] OriginalImage { get; set; }
        public byte[] ProcessedImage { get; set; }
        public string PluginName { get; set; }
    }
}

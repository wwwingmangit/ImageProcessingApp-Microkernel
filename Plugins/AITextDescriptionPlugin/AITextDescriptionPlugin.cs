using PluginInterfaces;

namespace AITextDescriptionPlugin
{
    public class AITextDescriptionPlugin : ITextPlugin
    {
        public string Name => "AI Text Description Plugin";

        public string ProcessImage(byte[] imageData)
        {
            return "Simulated text analysis result.";
        }
    }
}

using System.IO;
using PluginInterfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace GrayscalePlugin
{
    public class GrayscaleFilter : IImagePlugin
    {
        public string Name => "Grayscale Filter";

        public byte[] ProcessImage(byte[] imageData)
        {
            using (var image = Image.Load(imageData))
            {
                image.Mutate(x => x.Grayscale());
                using (var ms = new MemoryStream())
                {
                    image.SaveAsJpeg(ms);
                    return ms.ToArray();
                }
            }
        }
    }
}

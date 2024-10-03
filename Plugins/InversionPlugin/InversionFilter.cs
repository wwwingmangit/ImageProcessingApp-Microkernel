using System.IO;
using PluginInterfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace InversionPlugin
{
    public class InversionFilter : IImagePlugin
    {
        public string Name => "Horizontal Inversion";

        public byte[] ProcessImage(byte[] imageData)
        {
            using (var image = Image.Load(imageData))
            {
                image.Mutate(x => x.Flip(FlipMode.Horizontal));
                using (var ms = new MemoryStream())
                {
                    image.SaveAsJpeg(ms);
                    return ms.ToArray();
                }
            }
        }
    }
}

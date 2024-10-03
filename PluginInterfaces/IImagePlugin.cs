namespace PluginInterfaces;
public interface IImagePlugin
{
    string Name { get; }
    byte[] ProcessImage(byte[] imageData);
}

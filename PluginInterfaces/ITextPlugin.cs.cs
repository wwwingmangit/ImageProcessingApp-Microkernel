namespace PluginInterfaces;
public interface ITextPlugin
{
    string Name { get; }
    string ProcessImage(byte[] imageData);
}


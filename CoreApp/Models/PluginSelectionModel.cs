using System.Collections.Generic;
using PluginInterfaces;

namespace CoreApp.Models
{
    public class PluginSelectionModel
    {
        public List<IImagePlugin> ImagePlugins { get; set; }
        public List<ITextPlugin> TextPlugins { get; set; }
        public PluginSelectionModel()
        {
            ImagePlugins = new List<IImagePlugin>();
            TextPlugins = new List<ITextPlugin>();
        }
    }
}

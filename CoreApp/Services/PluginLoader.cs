using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using PluginInterfaces;

namespace CoreApp.Services
{
    public class PluginLoader
    {
        public List<IImagePlugin> ImagePlugins { get; private set; } = new List<IImagePlugin>();
        public List<ITextPlugin> TextPlugins { get; private set; } = new List<ITextPlugin>();

        public PluginLoader()
        {
            Console.WriteLine("PluginLoader instantiated");
            LoadPlugins();
        }

        private void LoadPlugins()
        {
            Console.WriteLine("Loading plugins...");

            string pluginsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
            Console.WriteLine($"Plugins path: {pluginsPath}");

            if (!Directory.Exists(pluginsPath))
            {
                Console.WriteLine("Plugins directory does not exist. Creating...");
                Directory.CreateDirectory(pluginsPath);
            }

            var pluginFiles = Directory.GetFiles(pluginsPath, "*.dll");
            Console.WriteLine($"Found {pluginFiles.Length} plugin files.");

            foreach (var pluginPath in pluginFiles)
            {
                Console.WriteLine($"Attempting to load plugin: {pluginPath}");
                try
                {
                    var assembly = Assembly.LoadFrom(pluginPath);
                    var types = assembly.GetTypes();

                    foreach (var type in types)
                    {
                        if (typeof(IImagePlugin).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                        {
                            var pluginInstance = (IImagePlugin)Activator.CreateInstance(type);
                            ImagePlugins.Add(pluginInstance);
                            Console.WriteLine($"Loaded image plugin: {pluginInstance.Name}");
                        }
                        else if (typeof(ITextPlugin).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                        {
                            var pluginInstance = (ITextPlugin)Activator.CreateInstance(type);
                            TextPlugins.Add(pluginInstance);
                            Console.WriteLine($"Loaded text plugin: {pluginInstance.Name}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading plugin from {pluginPath}: {ex.Message}");
                }
            }
        }
    }
}

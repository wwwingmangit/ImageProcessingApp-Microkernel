using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoreApp.Models;
using CoreApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly PluginLoader _pluginLoader;

        public HomeController(PluginLoader pluginLoader)
        {
            _pluginLoader = pluginLoader;
        }

        public IActionResult Index()
        {
            var model = new PluginSelectionModel
            {
                ImagePlugins = _pluginLoader.ImagePlugins,
                TextPlugins = _pluginLoader.TextPlugins
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ProcessImage(IFormFile file, string pluginName)
        {
            if (file != null && file.Length > 0)
            {
                byte[] imageData;
                using (var ms = new MemoryStream())
                {
                    await file.CopyToAsync(ms);
                    imageData = ms.ToArray();
                }

                var imagePlugin = _pluginLoader.ImagePlugins.FirstOrDefault(p => p.Name == pluginName);
                if (imagePlugin != null)
                {
                    var processedImage = imagePlugin.ProcessImage(imageData);
                    var model = new ImageResultModel
                    {
                        OriginalImage = imageData,
                        ProcessedImage = processedImage,
                        PluginName = imagePlugin.Name
                    };
                    return View("ImageResult", model);
                }

                var textPlugin = _pluginLoader.TextPlugins.FirstOrDefault(p => p.Name == pluginName);
                if (textPlugin != null)
                {
                    var resultText = textPlugin.ProcessImage(imageData);
                    var model = new TextResultModel
                    {
                        ResultText = resultText,
                        PluginName = textPlugin.Name
                    };
                    return View("TextResult", model);
                }

                // Plugin not found
                return RedirectToAction("Index");
            }

            // File not selected
            return RedirectToAction("Index");
        }
    }
}

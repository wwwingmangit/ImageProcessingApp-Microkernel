/*using PluginInterfaces;
using System.Text;

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
}*/

using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PluginInterfaces;

namespace AITextDescriptionPlugin
{
    public class AITextDescriptionPlugin : ITextPlugin
    {
        public string Name => "AI Text Description Plugin";

        public string ProcessImage(byte[] imageData)
        {
            // Convert image byte[] to Base64 string
            string base64Image = Convert.ToBase64String(imageData);

            // Load the model first
            bool modelLoaded = LoadModel().Result;
            if (!modelLoaded)
            {
                return "Error: Failed to load the model.";
            }

            // Then call the OLLAMA API to get the description
            string description = SendToOllamaAsync(base64Image, "What is in this picture?").Result;

            return description;
        }

        private async Task<bool> LoadModel()
        {
            using (HttpClient client = new HttpClient())
            {
                var requestContent = new StringContent(
                    $"{{\"model\": \"llava\"}}",
                    Encoding.UTF8,
                    "application/json"
                );

                HttpResponseMessage response = await client.PostAsync("http://localhost:11434/api/generate", requestContent);

                return response.IsSuccessStatusCode;
            }
        }

        private async Task<string> SendToOllamaAsync(string base64Image, string prompt)
        {
            using (HttpClient client = new HttpClient())
            {
                // Update the JSON request with "images" (array)
                var requestContent = new StringContent(
                    $"{{\"model\": \"llava\", \"images\": [\"{base64Image}\"], \"prompt\": \"{prompt}\", \"stream\": false}}",
                    Encoding.UTF8,
                    "application/json"
                );

                HttpResponseMessage response = await client.PostAsync("http://localhost:11434/api/generate", requestContent);
                response.EnsureSuccessStatusCode();

                // Read the full response as a string
                string responseContent = await response.Content.ReadAsStringAsync();

                // Parse and return the "response" field from the JSON
                dynamic jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent);
                return jsonResponse.response.ToString();
            }
        }
    }
}

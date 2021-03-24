using Newtonsoft.Json;
using Svg;
using System;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TwitchAgent.Services
{
    public static class ColourService
    {
        public static async Task<string>  GetColourFromHex(string hexCode)
        {
            var colour = String.Empty;

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetStringAsync($" http://thecolorapi.com/id?hex={hexCode}");

                    var colourJson = JsonConvert.DeserializeObject<ColourResponse>(response);

                    colour = colourJson.Name.Value;

                    //using(var webClient = new WebClient())
                    //{
                    //    webClient.DownloadFileAsync(colourJson.Image.Bare, "D:/colour.png");
                    //    var svgDoc = SvgDocument.Open("D:/colour.svg");
                    //    bitMap = svgDoc.Draw();
                    //}
                     
          
                } catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching colour: {ex.Message}");
                }
            };

            return colour;
        }
    }
}

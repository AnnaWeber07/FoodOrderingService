using FoodOrderingService.RD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FoodOrderingService
{
    public class Requester
    {
        public async Task<PostOrderV2Response> PostOrderAsync(List<PostOrderV2> orders)
        {
            //v2 post order
            try
            {
                using HttpClient client = new HttpClient();
                var content = JsonSerializer.Serialize(orders);
                string mediaType = "application/json";
                var postResponse = await client.PostAsJsonAsync("http://localhost:8085/" + "ready",
                new StringContent(content, Encoding.UTF8, mediaType));
                //по этому порту 8085 отправляется ответ в ресторан

                //get restaurant response with registered order

                postResponse.EnsureSuccessStatusCode();

                var json = await postResponse.Content.ReadFromJsonAsync<PostOrderV2Response>();

                return json;
            }

            catch (Exception ex)
            {
                LogWriter.Log($"Something bad with food ordering happened, " + ex);
            }

            return null;
        }
    }
}

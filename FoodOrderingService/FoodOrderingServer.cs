using FoodOrderingService.RD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FoodOrderingService.RD;
using System.Xml;


namespace FoodOrderingService
{
    public class FoodOrderingServer
    {
        private static HttpListener listener;
        private static string receiveUrl = "http://localhost:8085/";
        private static string sendUrl = "http://localhost:8084/";


        private FoodOrdering foodOrdering;
        private OrdersManager ordersManager;

        /*
         Receive:
    • register POST (RestaurantService)
    • menu GET (ClientService)
    • order POST (ClientService)
         */

        public async Task HandleIncomingRestaurantConnections()
        {
            bool isRunning = true;

            while (isRunning)
            {
                HttpListenerContext context = await listener.GetContextAsync();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                //register restaurant data and menu DONE FULL
                if (request.HttpMethod == "POST" && request.Url.AbsolutePath == "/register")
                {
                    using StreamReader streamReader = new(request.InputStream, request.ContentEncoding);
                    // RestaurantData data = JsonSerializer.Deserialize<RestaurantData>(streamReader.ReadToEnd());


                    var text = streamReader.ReadToEnd();
                    if (string.IsNullOrEmpty(text))
                    {
                        Console.WriteLine("null");
                    }


                    //DataRegistration dataRegistration = JsonSerializer.Deserialize<DataRegistration>(streamReader.ReadToEndAsync());
                    DataRegistration dataRegistration = JsonSerializer.Deserialize<DataRegistration>(text);

                    foodOrdering.RegisterData(dataRegistration);
                }

                else if (request.HttpMethod == "GET" && request.Url.AbsolutePath == "/menu")
                {

                    //string text = streamreader.ReadToEnd();

                    var sendObject = foodOrdering.GetClientMenu;

                    var json = JsonSerializer.Serialize(sendObject);

                    //serialize and send menu over to client as a response

                    // Get a response stream and write the response to it.

                    byte[] buffer = new byte[] { };

                    response.ContentType = "application/json";

                    buffer = Encoding.ASCII.GetBytes(json);
                    response.ContentLength64 = buffer.Length;

                    System.IO.Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);

                    output.Close();

                }

                else if (request.HttpMethod == "POST" && request.Url.AbsolutePath == "/order")
                {
                    using StreamReader streamReader = new(request.InputStream, request.ContentEncoding);
                    ClientPostOrder clientPostOrder = JsonSerializer.Deserialize<ClientPostOrder>(streamReader.ReadToEnd());
                    ordersManager.ClientPostOrders.Add(clientPostOrder);

                    //check all necessary stuff for this order and retransmit it to the restaurant
                }

                else if ((request.HttpMethod == "POST" || request.HttpMethod == "GET") && request.Url.AbsolutePath == "/shutdown")
                {
                    Console.WriteLine("Shutdown of server");
                    isRunning = false;
                }

                response.StatusCode = 200;
                response.Close();
            }
        }


        public void SendMenu(List<Menu> menus)
        {
            using var client = new HttpClient();

            var message = JsonSerializer.Serialize(menus);
            string mediaType = "application/json";

            var response = client.PostAsync(sendUrl + "menu", new StringContent(message, Encoding.UTF8, mediaType))
                                 .GetAwaiter()
                                 .GetResult();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                LogWriter.Log($"List of menus were sent.");
            }
        }

        public async void Start(FoodOrdering foodOrdering)
        {
            this.foodOrdering = foodOrdering;

            listener = new HttpListener();
            listener.Prefixes.Add(receiveUrl);
            listener.Start();

            await HandleIncomingRestaurantConnections();

            listener.Close();
        }
    }
}

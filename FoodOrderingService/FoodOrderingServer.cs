﻿using FoodOrderingService.RD;
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
        private static string receiveCSUrl = "http://localhost:8085/";
        private static string sendCSUrl = "http://localhost:8084/";

        private static string restaurant1receiveUrl = "http://localhost:8086/"; //first restaurant receiver
        private static string restaurant2receiveUrl = "http://localhost:8087/"; //second restaurant receiver
        private static string restaurant3receiveUrl = "http://localhost:8088/"; //third restaurant receiver

        private static string restaurant1sendUrl = "http://localhost:8089/"; //first restaurant sender
        private static string restaurant2sendUrl = "http://localhost:8090/"; //second restaurant sender
        private static string restaurant3sendUrl = "http://localhost:8091/"; //third restaurant sender

        private FoodOrdering foodOrdering;

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
                    RestaurantData data = JsonSerializer.Deserialize<RestaurantData>(streamReader.ReadToEnd());
                    foodOrdering.RegisterData(data);
                }

                else if (request.HttpMethod == "GET" && request.Url.AbsolutePath == "/menu")
                {
                    using StreamReader streamreader = new(request.InputStream, request.ContentEncoding);
                    SendMenu();
                }

                else if (request.HttpMethod == "POST" && request.Url.AbsolutePath == "/order")
                {

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

            var response = client.PostAsync(sendCSUrl + "menu", new StringContent(message, Encoding.UTF8, mediaType))
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
            listener.Prefixes.Add(receiveCSUrl);
            listener.Start();

            await HandleIncomingRestaurantConnections();

            listener.Close();
        }
    }
}

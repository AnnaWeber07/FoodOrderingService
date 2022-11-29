using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodOrderingService.RestaurantData;


namespace FoodOrderingService
{
    class LogWriter
    {
        public static void Log(string log)
        {
            Console.WriteLine($"{GetThreadId()}: {log}");
        }

        private static string GetThreadId()
        {
            var idx = Thread.CurrentThread.ManagedThreadId;
            return $"{DateTime.Now:HH:mm:ss:ffff} (Thread {idx})";
        }
    }
}

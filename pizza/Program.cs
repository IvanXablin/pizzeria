using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace pizza
{
    class Program
    {       
        private static string path;
        private static string json;

        public static List<Baker> bakerList = new List<Baker>();
        public static List<Courier> courierList = new List<Courier>();
        public static Json pizzaData = new Json();


        static void Main(string[] args)
        {      
            StartPizzaria();        
        }

        static void StartPizzaria()
        {
            Random random = new Random();

            path = Path.Combine(Environment.CurrentDirectory, "../../pizza_data.json");
            json = File.ReadAllText(path);

            pizzaData = Newtonsoft.Json.JsonConvert.DeserializeObject<Json>(json);

            TimerCallback tm = new TimerCallback(GenerateOrder);
            Timer timer = new Timer(tm, random.Next(1, 4), 0, random.Next(2500, 5000));

            for (int i = 1; i <= pizzaData.BakerCount; i++)
            {
                bakerList.Add(new Baker(i));
            }

            for (int i = 1; i <= pizzaData.CourierCount; i++)
            {
                courierList.Add(new Courier());
            }

            foreach (Courier courier in courierList)
            {
                courier.StartJob();
            }

            foreach (Baker baker in bakerList)
            {
                baker.StartJob();
            }
        }

        private static void GenerateOrder(object obj)
        {
            Random random = new Random();

            int countOrders = Convert.ToInt32(obj);

            for (int i = 0; i < countOrders; i++)
            {
                Order.orders.Add(random.Next(500, 3000));
            }    
        }
    }
}

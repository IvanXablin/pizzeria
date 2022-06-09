using System;
using System.Collections.Generic;
using System.Threading;

namespace pizza
{
    class Program
    {
        
        private static int countBaker = 2;
        private static int countCourier = 2;
        private static int countOrders = 2;

        public static List<Baker> bakerList = new List<Baker>();
        public static List<Courier> courierList = new List<Courier>();

        static void Main(string[] args)
        {
            StartPizzaria();
        }

        static void StartPizzaria()
        {
            Random random = new Random();

            Console.Write("Кол-во пекарей: ");
            countBaker = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Кол-во курьеров: ");
            countCourier = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Кол-во заказов: ");
            countOrders = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            for (int i = 1; i <= countBaker; i++)
            {
                bakerList.Add(new Baker(i));
            }

            for (int i = 1; i <= countCourier; i++)
            {
                courierList.Add(new Courier());
            }

            for (int i = 1; i <= countOrders; i++)
            {
                Order.orders.Add(random.Next(1, 1000));
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

    }
}

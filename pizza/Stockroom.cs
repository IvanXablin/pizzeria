using System;
using System.Collections.Generic;

namespace pizza
{
    public class Stockroom {

        public static List<int> storageOrders = new List<int>();

        private static object lockGet = new object();

        private static object lockFill = new object();
        public static int freePlaceCount { get; set; } = 5;
        public static int maxSize { get; set; } = 5;

        private static bool isFull = true;

        public static int GetFromStockroom()
        {
            lock (lockGet)
            {
                while (freePlaceCount == maxSize) {}

                int order = storageOrders[0];
                storageOrders.RemoveAt(0);
                freePlaceCount++;
                return order;
            } 
        }
        public static void FillStockroom(int order)
        {
            lock (lockFill)
            {
                while (freePlaceCount == 0)
                {
                    if (isFull)
                    {
                        Console.WriteLine($"Заказ номер [{order}] ожидает место на складе!");
                        isFull = false;
                    }
                }

                storageOrders.Add(order);
                freePlaceCount--;
                Console.WriteLine($"Заказ номер [{order}] поступил на склад!");               
            }
        }
    }
}

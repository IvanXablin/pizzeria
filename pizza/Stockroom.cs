using System;
using System.Collections.Generic;

namespace pizza
{
    public class Stockroom {

        public static List<int> storageOrders = new List<int>();

        private static object lockGet = new object();

        private static object lockFill = new object();
        public static int freePlace { get; set; } = 5;
        public static int maxSize { get; set; } = 5;

        public static int GetFromStockroom()
        {
            lock (lockGet)
            {
                while (freePlace == maxSize) { }

                int order = storageOrders[0];
                storageOrders.RemoveAt(0);
                freePlace++;
                return order;
            } 
        }
        public static void FillStockroom(int order)
        {
            lock (lockFill)
            {
                int flag = 0;

                while (freePlace == 0)
                {
                    if (flag == 0)
                    {
                        Console.WriteLine($"Заказ номер [{order}] ожидает место на складе!");
                        flag = 1;
                    }
                }

                storageOrders.Add(order);
                Console.WriteLine($"Заказ номер [{order}] поступил на склад!");
                freePlace--;
            }
        }
    }
}

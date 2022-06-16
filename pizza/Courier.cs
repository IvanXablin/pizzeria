using System;
using System.Threading;

namespace pizza
{
    public class Courier
    {
        private Thread thread;
        private int order;
        public Courier()
        {
            thread = new Thread(DeliverDmirtyBargrov);
        }
        public void StartJob()
        {
            thread.Start();
        }
        public void GetOrder()
        {
            order = Stockroom.GetFromStockroom();
        }
        public void DeliverDmirtyBargrov()
        {
            while (Order.orders.Count != 0 || Stockroom.freePlaceCount != Stockroom.maxSize)
            {
                GetOrder();
                if (order < 0)
                {
                    return;
                }
                Console.WriteLine($"Заказ номер [{order}] принят курьером!");
                Thread.Sleep(200);
                Console.WriteLine($"Заказ номер [{order}] был доставлен!");
            }     
        }

    }
}

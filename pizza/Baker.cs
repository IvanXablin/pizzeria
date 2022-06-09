using System;
using System.Threading;

namespace pizza
{    
    public class Baker
    {
        private Thread thread;
        private Random random;
        private int order;
        private int ID;
        public Baker (int ID)
        {
            thread = new Thread(Cooking);
            random = new Random();
            this.ID = ID;
        }

        public void StartJob()
        {
            thread.Start();
        }

        public void Cooking()
        {
            while (Order.orders.Count != 0)
            {
                TakeOrder();
                if (order < 0)
                {
                    return;
                }
                Thread.Sleep(random.Next(500, 5000));
                Console.WriteLine($"Заказ номер [{order}] готов! Выполнил [{ID}]");
                Stockroom.FillStockroom(order);
            }
        }

        public void TakeOrder()
        {
            order = Order.GetOrder();       
        }

    }
}

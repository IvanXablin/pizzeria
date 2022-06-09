using System.Collections.Generic;
using System.Threading;

namespace pizza
{
    public class Order
    {
        public static List<int> orders { get; set; } = new List<int>();
        private static Mutex mutexObj = new Mutex();

        public static int GetOrder()
        {
            mutexObj.WaitOne();

            if (orders.Count != 0)
            {
                int order = orders[0];
                orders.RemoveAt(0);
                mutexObj.ReleaseMutex();
                return order;           
            }

            mutexObj.ReleaseMutex();

            return -1;
        }
    }
}

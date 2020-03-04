using System.Threading;
using Microsoft.SPOT;

namespace Penny_Board
{
    public static class Program
    {
        public static void Main()
        {
            var counter = 0;
            while (true)
            {
                Debug.Print("Counter Value: " + counter);
                ++counter;
                Thread.Sleep(100);
            }
        }
    }
}

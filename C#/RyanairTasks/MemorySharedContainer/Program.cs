using System;
using System.Collections.Generic;
using System.Linq;

namespace MemorySharedContainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SharedMemory container = new SharedMemory();
            List<string> testList = new();

            for(int i = 1; i<10; i++)
            {
                testList.Add(i.ToString());
            }

            container.Add(testList);
            IEnumerable<string> receivedList = container.Get();
            Console.WriteLine(receivedList);
        }
    }
}

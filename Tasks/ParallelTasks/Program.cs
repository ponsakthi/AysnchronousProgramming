using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            new TaskComplettionSource().Execute();
            Console.ReadLine();
        }
    }
}

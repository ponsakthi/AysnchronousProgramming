using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTasks
{
    public class ThreadClass
    {
        public void Execute()
        {
            Console.WriteLine("Going to work");
            double average = 0;
            double sum = 0;
            var averageTask = Task.Factory.StartNew(() =>
            {
                average = NumbersClass.GetData().Average();
            });
            var sumTask = Task.Factory.StartNew(() =>
            {
                sum = NumbersClass.GetData().Take(10000).Sum();
            });
            averageTask.Wait();
            Console.WriteLine("Average is " + average);

            sumTask.Wait();
            Console.WriteLine("Sum is " + sum);
            
        }
    }
}
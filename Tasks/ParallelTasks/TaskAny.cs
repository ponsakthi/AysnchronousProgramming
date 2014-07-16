using System;
using System.Linq;
using System.Threading.Tasks;

namespace ParallelTasks
{
    public class TaskAny
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


            Task.WaitAny(new[] { averageTask, sumTask });
            Console.WriteLine("Average is " + average);
            Console.WriteLine("Sum is " + sum);

        }
    }

    
}
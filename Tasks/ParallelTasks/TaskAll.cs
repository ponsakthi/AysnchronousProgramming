using System;
using System.Linq;
using System.Threading.Tasks;

namespace ParallelTasks
{
    public class TaskAll
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
                sum = NumbersClass.GetData().Take(1000).Sum();
            });


            Task.WaitAll(new[] {averageTask,sumTask});
            Console.WriteLine("Average is " + average);
            Console.WriteLine("Sum is " + sum);

        }
    }
}
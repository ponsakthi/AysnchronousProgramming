using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTasks
{
    class TaskComplettionSource
    {
        public void Execute()
        {
            var tcs = new TaskCompletionSource<Work>();
            string result= string.Empty;
            //var longTask = new Task(() =>
            //{
            //    result = new LongWorker().DoWork();
            //});
            //longTask.Start();
            //longTask.Wait();

            Task<string> taskLong = new LongWorkerTask().DoWork();
            //taskLong.Start(); this will throw exception as the above line would have invoked start
            taskLong.Wait();
            Console.WriteLine(taskLong.Result);  // 42 
        }
    }


    public class LongWorker
    {
        public string DoWork()
        {
            Thread.Sleep(3000);
            return "Long worker returned";
        }
    }

    public class LongWorkerTask
    {
        public Task<string> DoWork()
        {
            var tcs = new TaskCompletionSource<string>();
            Thread.Sleep(3000);
            tcs.TrySetResult("Long worker task returned");
            return tcs.Task;
        }
    }
    internal class Work
    {
        public string data;
    }
}

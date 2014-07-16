using System.Collections.Generic;
using System.Linq;

namespace ParallelTasks
{
    public class NumbersClass
    {

        public static List<int> GetData()
        {
            return Enumerable.Range(1, 100000000).ToList();

        }
    }
}
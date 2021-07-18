using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace LINQ
{
    class Program
    {
        public static  void Main()
        {
            int[] nums = new int[] { 3, 4, 5, 67, 8, 234 };
            //IEnumerable<int> result = nums.Where(a => a > 10);
            IEnumerable<int> result = MyWhere1(nums,a => a > 10);
            foreach (var n in result)
            {
                Console.WriteLine(n);
            }
        }
        static IEnumerable<int> MyWhere1(IEnumerable<int> nums, Func<int, bool> f)
        {
            List<int> al = new List<int>();
            foreach(int n in nums)
            {
                if (f(n)) al.Add(n);
            }
            return al;
        }
        static IEnumerable<int> MyWhere2(IEnumerable<int> nums, Func<int, bool> f)
        {
            foreach (int n in nums)
            {
                if (f(n)) yield return n;
            }
        }

    }
    
}

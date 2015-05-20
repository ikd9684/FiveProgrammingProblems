using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jp._9684.FiveProgrammingProblems
{
    /// <summary>
    /// 問題1
    /// forループ、whileループ、および再帰を使用して、リスト内の数字の合計を計算する3つの関数を記述せよ。
    /// </summary>
    class Problem1
    {
        static int SumTotalByForLoop(List<int> numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }

        static int SumTotalByWhileLoop(List<int> numbers)
        {
            int sum = 0;
            int i = 0;
            while (i < numbers.Count)
            {
                sum += numbers[i++];
            }
            return sum;
        }

        static int SumTotalByRecursion(List<int> numbers)
        {
            if (numbers.Count == 0)
            {
                return 0;
            }
            else
            {
                int n = numbers[0];
                numbers.RemoveAt(0);

                return n + SumTotalByRecursion(numbers);
            }
        }

        static void Main(string[] args)
        {
            List<int> testNumbers = new List<int>(new int[] { 1, 4, 23, 54, 164, 421, });

            StringBuilder sb = new StringBuilder();
            foreach (int n in testNumbers)
            {
                sb.Append(n + ", ");
            }
            Console.WriteLine("[{0}]", sb.ToString().Substring(0, sb.Length - 2));

            try
            {
                int ans1 = SumTotalByForLoop(testNumbers);
                Console.WriteLine("SumTotalByForLoop = {0}", ans1);

                int ans2 = SumTotalByWhileLoop(testNumbers);
                Console.WriteLine("SumTotalByWhileLoop = {0}", ans2);

                int ans3 = SumTotalByRecursion(testNumbers);
                Console.WriteLine("SumTotalByRecursion = {0}", ans3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("-----");
                Console.WriteLine("Please press any key.");
                Console.ReadKey(true);
            }
        }
    }
}

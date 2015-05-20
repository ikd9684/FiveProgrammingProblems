using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jp._9684.FiveProgrammingProblems
{
    /// <summary>
    /// 正の整数のリストを与えられたとき、数を並び替えて可能な最大数を返す関数を記述せよ。
    /// 例えば、[50, 2, 1, 9]が与えられた時、95021が答えとなる。
    /// </summary>
    class Problem4
    {
        static decimal GetMaximumOfSequence(List<int> numbers)
        {
            List<int> sortedNumbers = new List<int>(numbers);
            sortedNumbers.Sort((a, b) =>
            {
                string strAB = string.Format("{0}{1}", a, b);
                string strBA = string.Format("{0}{1}", b, a);

                if (decimal.Parse(strAB) < decimal.Parse(strBA))
                {
                    return 1;
                }
                if (decimal.Parse(strBA) < decimal.Parse(strAB))
                {
                    return -1;
                }
                return 0;
            });
#if DEBUG
            WriteLine("sorted ", sortedNumbers);
#endif

            StringBuilder sb = new StringBuilder();
            foreach (int n in sortedNumbers)
            {
                sb.Append(n);
            }
            return decimal.Parse(sb.ToString());
        }

        static void Main(string[] args)
        {
            try
            {
                List<int> testNumbers = new List<int>(new int[] { 1, 4, 23, 54, 164, 421, });
                WriteLine("numbers", testNumbers);

                decimal ans = GetMaximumOfSequence(testNumbers);
                Console.WriteLine("... {0}", ans);
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

        static void WriteLine(string name, List<int> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var o in list)
            {
                sb.Append(o + ", ");
            }
            Console.WriteLine("{0}: [{1}]", name, sb.ToString().Substring(0, sb.Length - 2));
        }
    }
}

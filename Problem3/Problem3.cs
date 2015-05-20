using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jp._9684.FiveProgrammingProblems
{
    /// <summary>
    /// 問題3
    /// 最初の100個のフィボナッチ数のリストを計算する関数を記述せよ。
    /// 定義では、フィボナッチ数列の最初の2つの数字は0と1で、次の数は前の2つの合計となる。
    /// 例えば最初の10個のフィボナッチ数列は、0, 1, 1, 2, 3, 5, 8, 13, 21, 34となる。
    /// </summary>
    class Problem3
    {
        static List<decimal> GetFibonacciSeriesList(int count)
        {
            List<decimal> fibonacci = new List<decimal>();

            fibonacci.Add(0);
            fibonacci.Add(1);
            for (int i = 2; i < count; i++)
            {
                fibonacci.Add(fibonacci[i - 1] + fibonacci[i - 2]);
            }

            return fibonacci;
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Fibonacci Series:");

                List<decimal> fibonacci = GetFibonacciSeriesList(100);

                for (int i = 0; i < fibonacci.Count; i++)
                {
                    Console.WriteLine("{0:D3}: {1}", i + 1, fibonacci[i]);
                }
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

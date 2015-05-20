using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jp._9684.FiveProgrammingProblems
{
    /// <summary>
    /// 問題2
    /// 交互に要素を取ることで、2つのリストを結合する関数を記述せよ。
    /// 例えば [a, b, c]と[1, 2, 3]という2つのリストを与えると、関数は [a, 1, b, 2, c, 3]を返す。
    /// </summary>
    class Problem2
    {
        static List<object> MergeTwoList(List<object> listA, List<object> listB)
        {
            List<object> mergedList = new List<object>();

            int maxLength = listA.Count < listB.Count ? listB.Count : listA.Count;

            for (int i = 0; i < maxLength; i++)
            {
                if (i < listA.Count)
                {
                    mergedList.Add(listA[i]);
                }
                if (i < listB.Count)
                {
                    mergedList.Add(listB[i]);
                }
            }

            return mergedList;
        }

        static void Main(string[] args)
        {
            try
            {
                List<object> listA = new List<object>(new string[] { "abc", "de", "f", "gh", });
                WriteLine("listA", listA);

                List<object> listB = new List<object>(new string[] { "1", "4", "23", "54", "164", "421", });
                WriteLine("listB", listB);

                List<object> merge = MergeTwoList(listA, listB);
                WriteLine("merge", merge);
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

        static void WriteLine(string name, List<object> list)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Jp._9684.FiveProgrammingProblems
{
    /// <summary>
    /// 1,2,…,9の数をこの順序で、”+”、”-“、またはななにもせず結果が100となるあらゆる組合せを出力するプログラムを記述せよ。
    /// 例えば、1 + 2 + 34 – 5 + 67 – 8 + 9 = 100となる
    /// </summary>
    class Probrem5
    {
        /// <summary>
        /// 与えられた string 配列と string を順に分割し、組み合わせ、
        /// 問題5を解くためのすべての組み合わせパターンをリストに入れて返します。
        /// </summary>
        /// <param name="combinationList">組み合わせリスト</param>
        /// <param name="stringArray">組み合わせのひとつのパターン</param>
        static void SplitAndConcat(ref List<string[]> combinationList, params string[] stringArray)
        {
            if (combinationList.Exists((x) => { return x.SequenceEqual(stringArray); })) 
            {
                // 組み合わせリストに既に存在する組み合わせの場合は無視
                return;
            }

            // 組み合わせリストに追加
            combinationList.Add(stringArray);

            for (int arrayIndex = 0; arrayIndex < stringArray.Length; arrayIndex++)
            {
                // 配列内の指定インデックスにある文字列を取得
                string targetString = stringArray[arrayIndex];

                for (int splitIndex = 1; splitIndex < targetString.Length; splitIndex++)
                {
                    // 文字列の分割を左から順に試行

                    // 分割して再結合した結果の組み合わせＡ
                    List<string> concat = new List<string>(stringArray);
                    // Ａの指定位置の文字列を一旦除去
                    concat.RemoveAt(arrayIndex);
                    // 文字列を指定位置で二分割した結果の配列をそのまま指定位置へ挿入
                    string[] split = Split(targetString, splitIndex);
                    concat.InsertRange(arrayIndex, split);

                    // 再帰呼び出し
                    SplitAndConcat(ref combinationList, concat.ToArray());

                    // □□□□□    → combinationList
                    // □□ □□□   → combinationList
                    // □ □ □□□  → combinationList
                    // □□ □ □□  → combinationList
                    // □□ □ □ □ → combinationList
                }
            }
        }

        /// <summary>
        /// 与えられた文字列を指定された位置で分割し、配列に格納して返します。
        /// </summary>
        /// <param name="text">分割する文字列</param>
        /// <param name="splitIndex">分割位置</param>
        /// <returns>文字列を分割した結果の配列</returns>
        static string[] Split(string text, int splitIndex)
        {
            if (0 < splitIndex && splitIndex < text.Length)
            {
                return new string[] {
                    text.Substring(0, splitIndex),
                    text.Substring(splitIndex),
                };
            }
            else
            {
                return new string[] { text };
            }
        }

        private const string PLUS = "+";
        private const string MINUS = "-";
        private static readonly Regex NUMBER = new Regex("^[0-9]+$");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="formulaList"></param>
        /// <param name="combi"></param>
        static void ConcatOperator(ref List<List<string>> formulaList, ref List<string> combi, int index)
        {
            if (index < combi.Count
                && NUMBER.IsMatch(combi[index])
                && ++index < combi.Count
                && NUMBER.IsMatch(combi[index]))
            {
                // 数字の次の要素が数字だった場合、
                // ふたとおり（+/-）の演算子を挿入して次の要素をチェック

                List<string> p = new List<string>(combi);
                p.Insert(index, PLUS);
                ConcatOperator(ref formulaList, ref p, index + 1);

                List<string> m = new List<string>(combi);
                m.Insert(index, MINUS);
                ConcatOperator(ref formulaList, ref m, index + 1);

                return;
            }

            formulaList.Add(combi);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numbers">分割して計算する対象となる数字</param>
        /// <param name="answer">計算結果に一致して欲しい答え</param>
        /// <returns></returns>
        static List<List<string>> GetCorrectFormulaList(string numbers, int answer)
        {
            // 与えられた文字列を分割して考えられるすべての組み合わせで結合
            List<string[]> combi = new List<string[]>();
            SplitAndConcat(ref combi, new string[] { numbers });

            // すべての組み合わせの数字の間にすべてのパターンで演算子（+/-）を挿入
            List<List<string>> formulaList = new List<List<string>>();
            foreach (string[] arr in combi)
            {
                List<string> c = new List<string>(arr);
                ConcatOperator(ref formulaList, ref c, 0);
            }

            // すべての“式”を実際に計算してみて、指定された答えと一致する“式”のみ回答リストに追加
            List<List<string>> CorrectFormulaList = new List<List<string>>();
            foreach (List<string> formula in formulaList)
            {
                int sum = 0;
                bool plus = true;
                foreach (string s in formula)
                {
                    if (NUMBER.IsMatch(s))
                    {
                        int n = int.Parse(s);
                        sum = plus ? sum + n : sum - n;
                    }
                    else
                    {
                        plus = (s == PLUS);
                    }
                }
                if (sum == answer)
                {
                    CorrectFormulaList.Add(formula);
                }
            }
            return CorrectFormulaList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                List<List<string>> CorrectFormulaList = GetCorrectFormulaList("123456789", 100);

                foreach (List<string> l in CorrectFormulaList)
                {
                    foreach (string s in l)
                    {
                        Console.Write("{0} ", s);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

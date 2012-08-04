using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BingoMaker.Web
{
    public static class RandomExtensions
    {
        private static Random random = new Random(Environment.TickCount);

        public static IEnumerable<T> TakeRandom<T>(this IList<T> list, int needed)
        {
            int remaining = list.Count;

            while (needed > 0 && remaining > 0)
            {
                if (random.NextDouble() < (needed * 1.0 / remaining))
                {
                    needed--;
                    yield return list[remaining - 1];
                }
                remaining--;
            }
        }

        /// <summary>
        /// Shuffles the specified list (Extension Method for any IList<T>).
        /// </summary>
        /// <remarks>
        /// Algorithm described at: http://en.wikipedia.org/wiki/Fisher-Yates_shuffle
        /// </remarks>
        /// <example>list.Shuffle();</example>
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
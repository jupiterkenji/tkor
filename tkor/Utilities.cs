using System;
using System.Collections.Generic;
using System.Linq;

namespace tkor
{
    public class Utilities
    {
        public static string GetHelloWorld()
        {
            return "Hello World ...";
        }

        public static int NumGroups(List<string> greatBarrierReef) {
            var results = new List<List<int>>();

            foreach (var interactionAsString in greatBarrierReef)
            {
                var interactionAsList = GetInteraction(interactionAsString);

                var found = false;
                foreach (var result in results)
                {
                    if (interactionAsList.Intersect(result).Any())
                    {
                        var newFishes = interactionAsList.Except(result);
                        if (newFishes.Any())
                        {
                            result.AddRange(newFishes);
                        }
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    results.Add(interactionAsList);
                }
            }

            return results.Count();
        }

        static List<int> GetInteraction(string interaction)
        {
            var result = new List<int>();
            var interactionAsArray = interaction.ToArray();

            for (var i=0;i < interaction.Length; i++)
            {
                if (interactionAsArray[i] == '1')
                {
                    result.Add(i);
                }
            }

            return result;
        }

        public static int NumberOfPayment(List<int> roktCoupons, long k) {
            if (k < 0)
            {
                return 0;
            }
            var result = new HashSet<int>();

            var roktCouponsAsArray = roktCoupons.Distinct().ToArray();

            for (var i=0; i < roktCouponsAsArray.Length; i++) {
                for (var j=i+1; j < roktCouponsAsArray.Length; j++) {

                    var item1 = roktCouponsAsArray[i];
                    var item2 = roktCouponsAsArray[j];

                    if (item1 < 0 || item2 < 0)
                    {
                        return 0;
                    }

                    if (item1 + item2 == k)
                    {
                        if (!result.Any(r => r == item1 || r == k-item1))
                        {
                            result.Add(item1);
                        }
                    }
                }
            }

            return result.Count();
        }

        public static List<string> Correctness(List<string> roktx) {
            var result = new List<string>();

            foreach (var sentence in roktx) {
                result.Add(CorrectnessCore(sentence));
            }

            return result;
        }

        static string CorrectnessCore(string sentence) {
            var stack = new Stack<char>();

            foreach (var letter in sentence.ToCharArray())
            {
                if (stack.Count == 0)
                {
                    if (IsOpening(letter)) {
                        stack.Push(letter);
                    }
                    else
                    {
                        return "NO";
                    }
                }
                else
                {
                    if (IsOpening(letter)) {
                        stack.Push(letter);
                    }
                    else if (IsClosing(letter)) {
                        var matching = stack.Pop();
                        if (dictionary[matching] != letter)
                        {
                            return "NO";
                        }
                    }
                    else
                    {
                        return "NO";
                    }
                }

            }

            return stack.Count == 0
                ? "YES"
                : "NO";
        }

        static bool IsOpening(char letter) {
            var openingChars = dictionary.Keys.ToArray();
            return openingChars.Contains(letter);
        }

        static bool IsClosing(char letter) {
            var closingChars = dictionary.Values.ToArray();
            return closingChars.Contains(letter);
        }

        static Dictionary<char, char> dictionary = new Dictionary<char, char>
        {
            { '[', ']' },
            { '{', '}' },
            { '(', ')' },
        };
    }
}
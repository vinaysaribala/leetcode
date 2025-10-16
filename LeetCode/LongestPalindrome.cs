namespace LeetCode
{
    public static class LongestPalindrome
    {
        public static void TestImplementation()
        {
            var testData = new List<Model>
            {
                new() { HasValidResult = true, Input = "bababab", Expected = "bababab" },
                new() { HasValidResult = true, Input = "hellolevelup", Expected = "level" },
                new() { HasValidResult = true, Input = "startnoonend", Expected = "noon" },
                new() { HasValidResult = true, Input = "abcdefgfedcba", Expected = "abcdefgfedcba" },
                new() { HasValidResult = true, Input = "xxxyabadabaxxx", Expected = "yabadaba" },
                new() { HasValidResult = true, Input = "finddeifiedhere", Expected = "deified" },
                new() { HasValidResult = true, Input = "civic", Expected = "civic" }
            };

            foreach (var item in testData)
            {
                item.Actual = Solution(item.Input);
                item.HasValidResult = item.Expected == item.Actual;
                Console.WriteLine($"The plaindrome of {item.Input} is {item.Actual} and answer is {item.HasValidResult}.");
            }

            var finalResult = testData.Any(i => !i.HasValidResult) ? "Wrong" : "Correct";
            Console.WriteLine($"Your implmentation is {finalResult}.");
        }

        public static string Solution(string input)
        {
            string transformedInput = "^#" + string.Join("#", input.ToCharArray()) + "#$";
            int stringLength = transformedInput.Length;
            int[] palindromeArray = new int[stringLength];
            int center = 0, right = 0;

            for (int i = 1; i < stringLength - 1; i++)
            {
                palindromeArray[i] = (right > i) ? Math.Min(right - i, palindromeArray[(2 * center) - i]) : 0;
                while (transformedInput[i + 1 + palindromeArray[i]] == transformedInput[i - 1 - palindromeArray[i]])
                {
                    palindromeArray[i]++;
                }

                if (i + palindromeArray[i] > right)
                {
                    center = i;
                    right = i + palindromeArray[i];
                }
            }

            int max_len = palindromeArray.Max();
            int center_index = Array.IndexOf(palindromeArray, max_len);
            return input.Substring((center_index - max_len) / 2, max_len);
        }

        public class Model
        {
            public string Input { get; set; } = string.Empty;
            public string Expected { get; set; } = string.Empty;
            public string Actual { get; set; } = string.Empty;
            public bool HasValidResult { get; set; } 
        }
    }
}

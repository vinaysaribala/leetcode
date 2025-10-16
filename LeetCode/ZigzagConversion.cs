namespace LeetCode
{
    public static class ZigzagConversion
    {
        public static void TestImplementation()
        {
            var testData = new List<Model>
            {
                new() { HasValidResult = true, Input = "PAYPALISHIRING", Expected = "PAHNAPLSIIGYIR", NumberOfRows = 3 },
                new() { HasValidResult = true, Input = "PAYPALISHIRING", Expected = "PINALSIGYAHRPI", NumberOfRows = 4 },
                new() { HasValidResult = true, Input = "AB", Expected = "AB", NumberOfRows = 1 },
                new() { HasValidResult = true, Input = "ABC", Expected = "ACB", NumberOfRows = 2 },
                new() { HasValidResult = true, Input = "ABCDEFGHIJKLMN", Expected = "AGMBFHLNCEIKDJ", NumberOfRows = 4 },
                new() { HasValidResult = true, Input = "A", Expected = "A", NumberOfRows = 1 },
                new() { HasValidResult = true, Input = "ABCD", Expected = "ACBD", NumberOfRows = 2 },
            };

            foreach (var item in testData)
            {
                item.Actual = Convert(item.Input, item.NumberOfRows);
                item.HasValidResult = item.Expected == item.Actual;
                Console.WriteLine($"The zigzag of {item.Input} is {item.Actual} and answer is {item.HasValidResult}.");
            }

            var finalResult = testData.Any(i => !i.HasValidResult) ? "Wrong" : "Correct";
            Console.WriteLine($"Your implmentation is {finalResult}.");
        }

        public static string Solution(string input, int numberOfRows)
        {
            if (input == null || numberOfRows == 0)
            {
                return string.Empty;
            }

            if (numberOfRows == 1)
            {
                return input;
            }

            var output = new string[numberOfRows];
            var chars = input.ToCharArray();
            var n = 0;
            var max = numberOfRows - 1;
            var isAscending = true;
            for (int i = 0; i < chars.Length; i++)
            {
                output[n] += chars[i];
                if (n == max && isAscending)
                {
                    isAscending = false;
                }

                if (n == 0 && !isAscending)
                {
                    isAscending = true;
                }

                if (isAscending)
                {
                    n++;
                }
                else
                {
                    n--;
                }

            }

            return string.Join(string.Empty, output);
        }


        public static string Convert(string s, int numRows)
        {
            if (numRows == 1)
            {
                return s;
            }

            Span<char> result = stackalloc char[s.Length];

            var resultIndex = 0;
            var period = numRows * 2 - 2;

            for (int row = 0; row < numRows; row++)
            {
                var increment = 2 * row;

                for (int i = row; i < s.Length; i += increment)
                {
                    result[resultIndex++] = s[i];

                    if (increment != period)
                    {
                        increment = period - increment;
                    }
                }
            }

            return result.ToString();
        }

        public class Model
        {
            public string Input { get; set; } = string.Empty;
            public int NumberOfRows { get; set; } = 1;
            public string Expected { get; set; } = string.Empty;
            public string Actual { get; set; } = string.Empty;
            public bool HasValidResult { get; set; }
        }
    }
}

namespace LeetCode
{
    public static class FindMedianSortedArray
    {
        public static void TestImplementation()
        {
            var testData = GetTestData();
            foreach (var item in testData)
            {
                item.CalMedian = Solution(item.FirstArray, item.SecondArray);
                item.CalResult = item.CalMedian == item.Median;
                Console.WriteLine($"The median of [{string.Join(",", item.FirstArray)}], [{string.Join(",", item.SecondArray)}] is {item.Median} and answer is {item.CalResult}.");
            }

            var finalResult = testData.Any(i => !i.CalResult) ? "Wrong" : "Correct";
            Console.WriteLine($"Your implmentation is {finalResult}.");
        }

        public static double Solution(int[] nums1, int[] nums2)
        {
            var m = nums1.Length;
            var n = nums2.Length;
            var isEven = (m + n) % 2 == 0;
            var endIndex = (m + n) / 2;
            int[] merged = new int[endIndex + 1];
            var i = 0;
            var j = 0;

            while (i < m && j < n && (i + j) <= endIndex)
            {
                if (nums1[i] < nums2[j])
                {
                    merged[i + j] = nums1[i];
                    i++;
                }
                else
                {
                    merged[i + j] = nums2[j];
                    j++;
                }
            }

            while (i < m && (i + j) <= endIndex)
            {
                merged[i + j] = nums1[i];
                i++;
            }

            while (j < n && (i + j) <= endIndex)
            {
                merged[i + j] = nums2[j];
                j++;
            }


            return isEven ? (double)(merged[endIndex] + merged[endIndex - 1]) / 2 : merged[endIndex];
        }

        public static IList<Model> GetTestData()
        {
            return
            [
                new Model
            {
                FirstArray = [1, 3, 8, 12],
                SecondArray = [2, 7, 10, 15, 18],
                Median = 8
            },
            new Model
            {
                FirstArray = [5, 9, 12],
                SecondArray = [2, 4, 6, 10],
                Median = 6
            },
            new Model
            {
                FirstArray = [1, 2],
                SecondArray = [3, 4],
                Median = 2.5
            },
            new Model
            {
                FirstArray = [10, 20, 30, 40, 50],
                SecondArray = [5, 15, 25],
                Median = 22.5
            },
            new Model
            {
                FirstArray = [],
                SecondArray = [1, 2, 3, 4, 5],
                Median = 3
            }
            ];
        }
    }

    public class Model
    {
        public int[] FirstArray { get; set; } = [];
        public int[] SecondArray { get; set; } = [];
        public double Median { get; set; } = 0;
        public double CalMedian { get; set; } = 0;
        public bool CalResult { get; set; }
    }
}

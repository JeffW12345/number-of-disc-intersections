// Solution to the challenge at https://app.codility.com/programmers/lessons/6-sorting/number_of_disc_intersections/

namespace CodilityChallenges
{
    using System;
    using System.Collections.Generic;

    class Solution
    {
        public static int solution(int[] A)
        {
            Dictionary<long, List<int>> xAxisToCirclesDict = new Dictionary<long, List<int>>();
            for (int index = 0; index < A.Length; index++)
            {
                // Find the first and last values included in this element's circle. 
                long minVal = index - A[index];
                long maxVal = index + A[index];
                // Populate a dictionary with the numbers covered by the circles as keys and the relevant indexes as values
                for (long covered = minVal; covered < maxVal + 1; covered++)
                {
                    if (xAxisToCirclesDict.ContainsKey(covered))
                    {
                        xAxisToCirclesDict[covered].Add(index);
                    }
                    else
                    {
                        xAxisToCirclesDict.Add(covered, new List<int> { index });
                    }
                }
            }

            // Populates a set of strings with high index-low index'
            HashSet<string> set = new HashSet<string>();
            foreach (var entry in xAxisToCirclesDict)
            {
                if (entry.Value.Count > 1)
                {
                    for (int i = 0; i < entry.Value.Count; i++)
                    {
                        for (int j = 0; j < entry.Value.Count; j++)
                        {
                            if (entry.Value[i] < entry.Value[j])
                            {
                                set.Add(entry.Value[i] + "-" + entry.Value[j]);
                            }
                        }
                    }
                }
            }
            return set.Count <= 10000000 ? set.Count : -1;
        }

        public static void Main(string[] args)
        {
            int[] A = { 1, 5, 2, 1, 4, 0 }; // Expected value 11
            Console.WriteLine(solution(A));
        }
    }
}

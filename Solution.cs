// Solution to the challenge at https://app.codility.com/programmers/lessons/6-sorting/number_of_disc_intersections/

namespace CodilityChallenges
{
    using System;
    using System.Collections.Generic;

    class Solution
    {
        public static int solution(int[] A)
        {
            Dictionary<long, List<int>> xAxisToIndexNumsOccupyingThatIndexDict = new Dictionary<long, List<int>>();
            for (int index = 0; index < A.Length; index++)
            {
                // Find the first and last values included in this element's circle. 
                long minValThisIndexNum = index - (long)A[index];
                long maxValThisIndexNum = index + (long)A[index];
                // Populate a dictionary with the numbers covered by the circles as keys and the relevant indexes as values
                for (long covered = minValThisIndexNum; covered < maxValThisIndexNum + 1; covered++)
                {
                    Console.WriteLine(covered);
                    if (xAxisToIndexNumsOccupyingThatIndexDict.ContainsKey(covered))
                    {
                        xAxisToIndexNumsOccupyingThatIndexDict[covered].Add(index);
                    }
                    else
                    {
                        xAxisToIndexNumsOccupyingThatIndexDict.Add(covered, new List<int> { index });
                    }
                }
            }
            // Populate a set with Lists of <low, high> pairings where 'low' and 'high' refer to indexes in the array.
            HashSet<List<int>> set = new HashSet<List<int>>();
            foreach (var entry in xAxisToIndexNumsOccupyingThatIndexDict)
            {
                if(entry.Value.Count > 1)
                {
                    for(int i = 0; i < entry.Value.Count; i++)
                    {
                        for (int j = 0; j < entry.Value.Count; j++)
                        {
                            if(entry.Value[i] < entry.Value[j] && !IsAlreadyPresent(entry.Value[i], entry.Value[j], set))
                            {
                                set.Add(new List<int> { entry.Value[i], entry.Value[j] });
                            }
                        }
                    }
                }
            }
            return set.Count <= 10000000 ? set.Count : -1;
        }



        private static bool IsAlreadyPresent(int v1, int v2, HashSet<List<int>> set)
        {
            foreach(var entry in set)
            {
                if(entry[0] == v1 && entry [1] == v2)
                {
                    return true;
                }
            }
            return false;
        }

        public static void Main(string[] args)
        {
            int[] A = { 1, 5, 2, 1, 4, 0}; // Expected value 11
            Console.WriteLine(solution(A));
        }
    }
}

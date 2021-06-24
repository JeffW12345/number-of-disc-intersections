// Solution to the challenge at https://app.codility.com/programmers/lessons/6-sorting/number_of_disc_intersections/

namespace CodilityChallenges
{
    using System;
    using System.Collections.Generic;

    class Solution
    {
        public static int solution(int[] A)
        {
            HashSet<string> intersectingCirclesSet = new HashSet<string>();
            for (int index = 0; index < A.Length; index++)
            {
                for (int indexToCompare = 0; indexToCompare < A.Length; indexToCompare++)
                {
                    if (index >= indexToCompare)
                    {
                        continue;
                    }
                    long distanceBetweenIndexes = Math.Abs(index - indexToCompare);
                    long indexCircleRadius = A[index];
                    long indexToCompareCircleRadius = A[indexToCompare];
                    if (distanceBetweenIndexes <= (indexCircleRadius + indexToCompareCircleRadius))
                    {
                        intersectingCirclesSet.Add(index + "-" + indexToCompare);
                    }
                }
            }
            return intersectingCirclesSet.Count <= 10000000 ? intersectingCirclesSet.Count : -1;
        }

        public static void Main(string[] args)
        {
            int[] A = { 1, 1, 1 }; // Expected value 3
            Console.WriteLine(solution(A));
        }
    }
}


// Solution to the challenge at https://app.codility.com/programmers/lessons/6-sorting/number_of_disc_intersections/

namespace CodilityChallenges
{
    using System;

    class Solution
    {
        
        public static int solution(int[] A)
        {
            int count = 0;
            // Compares the elements of 'A' against each other, without duplicate counting.
            for (long index = 0; index < A.Length; index++)
            {
                for (long indexToCompare = index + 1; indexToCompare < A.Length; indexToCompare++)
                {
                    long radiusesCombined = (long) A[index] + (long) A[indexToCompare];
                    if ((indexToCompare - index) <= radiusesCombined)
                    {
                        count++;
                    }
                }
            }
            return count <= 10000000 ? count : -1;
        }

        public static void Main(string[] args)
        {
            int[] A = { 1, 1, 1 }; // Expected value 3
            Console.WriteLine(solution(A));
        }
    }
}


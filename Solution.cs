// Solution to the challenge at https://app.codility.com/programmers/lessons/6-sorting/number_of_disc_intersections/

namespace CodilityChallenges
{
    using System;

    class Solution
    {
        
        public static int solution(int[] A)
        {
            int count = 0;
            for (int index = 0; index < A.Length; index++)
            {
                for (int indexToCompare = 0; indexToCompare < A.Length; indexToCompare++)
                {
                    if (index < indexToCompare)
                    {
                        if (Math.Abs(index - indexToCompare) <= (long)(A[index] + A[indexToCompare]))
                        {
                            count++;
                        }
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneTest
{
    class Program
    {
        private const int PHONE_NUMBER_LENGTH = 7;
        private static readonly Dictionary<int, int[]> m_KnightValidMovements = new Dictionary<int, int[]>()
        {
            { 0, new int[] {6, 4} }, 
            { 1, new int[] {6, 8} },
            { 2, new int[] {9, 7} },
            { 3, new int[] {8, 4} },
            { 4, new int[] {9, 0, 3} },
            { 6, new int[] {1, 7, 0} },
            { 7, new int[] {6, 2} },
            { 8, new int[] {3, 1} },
            { 9, new int[] {2, 4} }
        };

        private static readonly Dictionary<int, int[]> m_KingValidMovements = new Dictionary<int, int[]>()
        {
            { 0, new int[] {7, 8, 9} }, 
            { 1, new int[] {2, 6, 4} },
            { 2, new int[] {1, 3, 4, 5, 6} },
            { 3, new int[] {2, 5, 6} },
            { 4, new int[] {1, 2, 5, 8, 7} },
            { 5, new int[] {1, 2, 3, 4, 6, 7, 8, 9} },
            { 6, new int[] {9, 8, 5, 2, 3} },
            { 7, new int[] {4, 5, 8} },
            { 8, new int[] {7, 4, 5, 6, 9, 0} },
            { 9, new int[] {6, 5, 8, 0} }
        };

        private static readonly int[] m_validStartNumbers = new int[] { 2, 3, 4, 5, 6, 7, 8, 9 };

        static void Main(string[] args)
        {
            int knightNumbers = 0;
            int kingNumbers = 0;

            foreach (int startNumber in m_validStartNumbers)
            {
                knightNumbers += CalculateNumberOfPossibleCombinations(m_KnightValidMovements, startNumber, PHONE_NUMBER_LENGTH - 1);
                kingNumbers += CalculateNumberOfPossibleCombinations(m_KingValidMovements, startNumber, PHONE_NUMBER_LENGTH - 1);
            }

            Console.WriteLine("KNIGHT: {0}", knightNumbers);
            Console.WriteLine("KING: {0}", kingNumbers);

            Console.ReadLine();
        }   

        private static int CalculateNumberOfPossibleCombinations(Dictionary<int, int[]> validMovements, int startNumber, int numbersLeft)
        {
            if (numbersLeft == 0)
            {
                return 1;
            }
            else if (!validMovements.ContainsKey(startNumber))
            {
                return 0;
            }
            else
            {
                int combinationCount = 0;

                foreach (int movementNumber in validMovements[startNumber])
                {
                    combinationCount += CalculateNumberOfPossibleCombinations(validMovements, movementNumber, numbersLeft - 1);
                }

                return combinationCount;
            }
        }
    }
}

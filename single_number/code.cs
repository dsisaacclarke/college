using System;
using System.Collections.Generic;

public class FindSingleNumbers_Novice
{
    public static int[] FindTheSingleNumbers(int[] numbers)
    {
        List<int> uniqueNumbers = new List<int>();

        for (int i = 0; i < numbers.Length; i++)
        {
            int currentNumber = numbers[i];

            int count = 0;
            for (int j = 0; j < numbers.Length; j++)
            {
                if (numbers[j] == currentNumber)
                {
                    count++;
                }
            }

            if (count == 1)
            {
                uniqueNumbers.Add(currentNumber);
            }
        }

        int[] result = new int[2];

        result[0] = uniqueNumbers[0];
        result[1] = uniqueNumbers[1];

        return result;
    }

    public static void Main(string[] args)
    {
        int[] numbers = { 1, 2, 1, 3, 2, 5 };
        int[] singleNumbers = FindTheSingleNumbers(numbers);

        Console.WriteLine(singleNumbers[0] + ", " + singleNumbers[1]);
    }
}


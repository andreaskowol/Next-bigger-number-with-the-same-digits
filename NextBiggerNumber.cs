using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Linq; 
     
     /*Strategy
     * Starting from the end of the number
     * Find first digit "gd" that is smaller than previous digit
     * Next find the smallest "sn" digit on right side od [i-1] digit thst is greater than number [i-1]
     * Swap "gd" and "sn"
     * Sort asc after the index [i-1] to the end of the list
     */
    public static long NextBiggerNumber(long n)
    {
        long[] number = n.ToString().Select(o => (long)Convert.ToInt32(o) - 48).ToArray();
        long nextSmallest = 10;
        long nextSmallestCount = -1;
        int index = number.Length-1;

        var seqence = number.OrderByDescending(x => x).ToArray();

        if (number.Length == 1 || Enumerable.SequenceEqual(number, seqence))
            return -1;

        for (int i = number.Length-1; i > 0; i--)
        {
            if (number[i - 1] < number[i]) { index = i - 1; break; }
            else { index--; }
        }

        for (int i = index +1; i < number.Length; i++)
        {
            if (number[i] > number[index] && number[i] < nextSmallest) { nextSmallest = number[i]; nextSmallestCount = i; }
        }

        (number[index], number[nextSmallestCount]) = (number[nextSmallestCount], number[index]);

        var numbers2 = number.ToList().GetRange(index+1, number.Length - 1 - index).ToArray();
        numbers2 = numbers2.OrderBy(x => x).ToArray();
         
        for (int i = 0; i < numbers2.Length; i++)
        {
            number[i+index+1] = numbers2[i];
        }

        var result = string.Join("", number);
        var resultValidated =  result[0] != '0' ? long.Parse(result) : -1;

        return resultValidated > n ? resultValidated : -1;
    }

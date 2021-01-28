using System;
using System.Collections.Generic;
using System.Text;

namespace NeoCircuitDiagram.Services
{
    class NextPermutation
    {
        /// <summary>
        /// <paramref name="values"/>
        /// Return the permutation of the given sequence, one result each time.
        /// </summary>
        public static bool next_permutation(char[] values)
        {
            if (values.Length == 0)
                throw new ArgumentException("Cannot permutate an empty collection.");

            //Find all terms at the end that are in reverse order.
            int tail = values.Length - 1;
            while (tail > 0 && values[tail - 1] >= values[tail])
                tail--;

            if (tail > 0)
            {
                //Find the last item from the tail greater than that from the head, swap.
                int index = values.Length - 1;
                while (index > tail && values[index] <= values[tail - 1])
                    index--;

                Swap(ref values[tail - 1], ref values[index]);
            }

            //Reverse the tail's order.
            int limit = (values.Length - tail) / 2;
            for (int index = 0; index < limit; index++)
                Swap(ref values[tail + index], ref values[values.Length - 1 - index]);

            //If the entire list was in reverse order, tail will be zero.
            return (tail != 0);
        }

        private static void Swap<T>(ref T left, ref T right)
        {
            T temp = left;
            left = right;
            right = temp;
        }
    }
}

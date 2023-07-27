/* Given two strings S and T, return if they are equal when both are typed out. Any # in the string count as a backspace
 * 
 */


using System.Linq;

namespace StringManipulation
{
    public class Program
    {
        /// <summary>
        /// Brute-force solution that uses a stack to hold each character in the string. As we iterate through it, letters are added to the stack and they are also removed when encountering a #
        /// </summary>
        /// <param name="input"></param>
        /// <returns>The resulting string after applying a backspace every time a # is entered</returns>
        static string trim_string_bf(string input)
        {
            // Initialize variables needed
            string result;
            var stack = new Stack<char>();
            // If the string given is not empty
            if (input.Length > 0)
            {
                // Iterate through it adding each letter to a stack and popping letters whenever a # is found
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] != '#')
                        stack.Push(input[i]);
                    else
                        stack.Pop();
                }
                // Transform the stack into a string
                result = String.Join("", stack.ToArray());
            }
            else
                result = "";
            return result;
        }


        /// <summary>
        /// Auxiliary method used to compare strings
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns> True or false depending on the strings being equal or not </returns>
        static bool compare(string s, string t)
        {
            bool identical = false;

            if(s == t)
                identical = true;

            return identical;
        }

        /// <summary>
        /// Optimal solution that uses pointers initialized at the end of both strings in order to find if they are equal
        /// </summary>
        /// <param name="args"></param>
        /// <returns> True or false depending on the strings being equal or not </returns>
        static bool check_strings(string s, string t)
        {
            // Assume that the strings are equal
            bool equal = true;
            //Pointers initialized at the end of the string
            int p1 = s.Length - 1;
            int p2 = t.Length - 1;

            //While loop ensures that we traverse the entire string and stop at index = 0
            while (p1 >= 0 || p2 >= 0)
            {
                // If # is found at position p1, ignore the current value as well as the next value.
                if (s[p1]== '#')
                {
                    // Count = 2 to skip the # character and the following char as well
                    int count = 2;
                    // Then we check if the characters to be skipped happen to be #
                    while (count > 0)
                    {
                        p1 -= 1;
                        count -=1;
                        //  If the current value at index p1 happens to be another #, then reset the count to 2.
                        //  This repeats as long as we keep finding # in the string
                        if (s[p1] == '#')
                            count = 2;
                    }
                }
                // Repeat steps for string 2
                if(t[p2] == '#')
                {
                    int count = 2;
                    while (count > 0)
                    {
                        p2 -= 1;
                        count -=1;

                        if (t[p2] == '#')
                            count = 2;
                    }
                }
                // If the current value of the strings is not #, then evaluate them to see if they are equal
                else
                {
                    if (s[p1] == t[p2])
                    {
                        p1-=1;
                        p2-=1;
                    }
                    else
                        equal = false;
                }
            }
            return equal;
        }

        static void Main(string[] args)
        {
            string s = "ab#z";
            string t = "az#z";

            // Use new string variables to be able to reuse s and t
            string s2 = trim_string_bf(s);
            string t2 = trim_string_bf(t);
            // Print results
            Console.WriteLine(compare(s2, t2));
            Console.WriteLine(check_strings(s, t));
        }
    }
}
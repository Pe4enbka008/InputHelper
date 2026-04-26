using System;


namespace smth
{
    /// <summary>
    /// Checker class itself. It has multiple inner classes like: InputChecker, LengthChecker
    /// </summary>
    public class Checker
    {
        /// <summary>
        /// Class checks for correct input (Console.ReadLine()) and return an input in chosen type, or prints error message inputted in the program.
        /// Cookie >:]
        /// </summary>
        public class InputChecker
        {
            private const string ERROR_input = "ERROR IN INPUT";

            /// <summary>
            /// Checks for correct input type string.
            /// </summary>
            /// <param name="message">Message for input</param>
            /// <param name="empty_line">Allow \n, default is false</param>
            /// <returns>Valid input of type string</returns>
            public static string StringChecker(string message, bool empty_line = false)
            {
                Console.Write(message);
                string str = Console.ReadLine();

                while (str == string.Empty && !empty_line)
                {
                    Console.Write($"{ERROR_input}! {message}");
                    str = Console.ReadLine();
                } // while

                return str;
            } // StringChecker


            /// <summary>
            /// Checks for correct input type (int, double, or float).
            /// </summary>
            /// <typeparam name="T">The numeric type (int, double, float)</typeparam>
            /// <param name="message">Message for input</param>
            /// <param name="negativeNumbers">Allow negative numbers</param>
            /// <param name="zero">Allow zero, default is true</param>
            /// <returns>Valid input of type T</returns>
            public static T NumberChecker<T>(string message, bool negativeNumbers, bool zero = true) where T : struct, IComparable
            {
                T num;
                if (typeof(T) != typeof(float) && typeof(T) != typeof(double) && typeof(T) != typeof(int)) return (T)(object)0;

                while (true)
                {
                    string input = StringChecker(message);
                    if (typeof(T) == typeof(int) && int.TryParse(input, out int intResult))
                        num = (T)(object)intResult;     // casting, 'cause type T is not convertible
                    else if (typeof(T) == typeof(double) && double.TryParse(input, out double doubleResult))
                        num = (T)(object)doubleResult;  // casting, 'cause type T is not convertible
                    else if (typeof(T) == typeof(float) && float.TryParse(input, out float floatResult))
                        num = (T)(object)floatResult;   // casting, 'cause type T is not convertible
                    else
                    {
                        Console.Write($"{ERROR_input}! ");
                        continue;
                    } // else

                    if ((!negativeNumbers && Comparer<T>.Default.Compare(num, default(T)) < 0) || (!zero && EqualityComparer<T>.Default.Equals(num, default(T))))
                    {
                        Console.Write($"{ERROR_input}! ");
                        continue;
                    } // if

                    return num;
                } // while
            } // NumberChecker


            /// <summary>
            /// Checks for correct input type char.
            /// </summary>
            /// <param name="message">Message for input</param>
            /// <returns>Valid input of type char</returns>
            public static char CharChecker(string message)
            {
                char ch;
                Console.Write(message);
                while (!char.TryParse(Console.ReadLine(), out ch))
                    Console.Write($"{ERROR_input}! {message}");
                return ch;
            } // CharChecker


            /// <summary>
            /// Checks for correct input type bool.
            /// </summary>
            /// <param name="message">Message for input</param>
            /// <param name="y_n">Allow only yes / no answers --- default is true</param>
            /// <param name="y_anything">Allow anything, where yes is true --- default is false</param>
            /// <param name="true_false">Allow values for bool.Parse() (IDK what are the value for this...) --- default is false</param>
            /// <returns>True or false</returns>
            public static bool BoolChecker(string message, bool y_n = true, bool y_anything = false, bool true_false = false)
            {
                if (true_false)
                {
                    Console.Write(message);
                    bool bl;
                    while (!bool.TryParse(Console.ReadLine(), out bl))
                        Console.Write($"{ERROR_input}! {message}");
                    return bl;
                } // if
                if (y_n)
                {
                    string smth = Checker.InputChecker.StringChecker(message);
                    while (smth[0] != 'n' && smth[0] != 'y')
                    { Console.Write($"{ERROR_input}! "); smth = Checker.InputChecker.StringChecker(message); }
                    return smth[0] == 'y';
                } // if
                string msg = Checker.InputChecker.StringChecker(message);
                return msg[0] == 'y';
            } // BoolChecker

        } // class InputChecker

        /// <summary>
        /// Class checks if the given cords are in range of the Array.
        /// Cookie >:]
        /// </summary>
        public class LengthChecker
        {
            /// <summary>
            /// Checks if the index is within the bounds of a 1D array.
            /// </summary>
            /// <typeparam name="T">Type of the array elements.</typeparam>
            /// <param name="arr">1D array.</param>
            /// <param name="n">Index.</param>
            /// <returns>True if the index is within bounds, otherwise false.</returns>
            public static bool IsInArrayRange<T>(T[] arr, int n)
            { return n >= 0 && n < arr.Length; }

            /// <summary>
            /// Checks if the row and column indices are within the bounds of a 2D array.
            /// </summary>
            /// <typeparam name="T">Type of the array elements.</typeparam>
            /// <param name="arr">2D array.</param>
            /// <param name="row">Row index.</param>
            /// <param name="col">Column index.</param>
            /// <returns>True if the indices are within bounds, otherwise false.</returns>
            public static bool IsInArrayRange<T>(T[,] arr, int row, int col)
            { return row >= 0 && col >= 0 && row < arr.GetLength(0) && col < arr.GetLength(1); }

            /// <summary>
            /// Checks if the x, y, and z indices are within the bounds of a 3D array.
            /// </summary>
            /// <typeparam name="T">Type of the array elements.</typeparam>
            /// <param name="arr">3D array.</param>
            /// <param name="x">X index.</param>
            /// <param name="y">Y index.</param>
            /// <param name="z">Z index.</param>
            /// <returns>True if the indices are within bounds, otherwise false.</returns>
            public static bool IsInArrayRange<T>(T[,,] arr, int x, int y, int z)
            { return x >= 0 && y >= 0 && z >= 0 && x < arr.GetLength(0) && y < arr.GetLength(1) && z < arr.GetLength(2); }
        } // class LengthChecker

        /// <summary>
        /// Class checks for correct input (Console.ReadLine()), however in type of a list, and return an input in chosen type as an Array, or prints error message inputted in the program.
        /// Cookie >:]
        /// </summary>
        public class SmthChecker
        {
            private const string ERROR_input = "ERROR IN INPUT";
            public static bool IsDoubleEven(double number)
            {
                if (!double.IsInteger(number))
                    return false;
                long integerValue = (long)number;
                return integerValue % 2 == 0;
            } // IsDoubleEven



        } // class LongInputChecker


    } // Checker
} // namespace smth


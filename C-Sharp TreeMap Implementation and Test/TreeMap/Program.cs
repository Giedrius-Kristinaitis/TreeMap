using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TreeMap {

    /// <summary>
    /// Main program class that tests the TreeMap implementation
    /// </summary>
    public class Program {

        /// <summary>
        /// Entry point of the program
        /// </summary>
        /// <param name="args">arguments for the program</param>
        public static void Main(string[] args) {
            new Program();

            Console.ReadLine();
        }

        // all available characters for random string generation
        private char[] AvailableCharacters = new char[] {
            'a', 'b', 'c', 'd', 'e', 'f', 'f', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'r', 's', 't', 'u', 'v', 'z'
        };

        // test quantities
        private int[] TestSizes = new int[] {
            10000, 20000, 40000, 80000, 160000
        };

        private Random Rand = new Random(2018);
        private TreeMap<string, string> Map = new TreeMap<string, string>();
        private Stopwatch timer = new Stopwatch();

        /// <summary>
        /// Default class constructor
        /// </summary>
        private Program() {
            for (int n = 0; n < TestSizes.Length; n++) {
                Map.Clear();

                Console.WriteLine("********** TEST #{0}: {1} Elements **********", n + 1, TestSizes[n]);

                List<string> keys = GenerateStrings(TestSizes[n]);
                List<string> values = GenerateStrings(TestSizes[n]);

                // ****** TEST PUT METHOD
                timer.Start();

                for (int i = 0; i < TestSizes[n]; i++) {
                    Map.Put(keys[i], values[i]);
                }

                timer.Stop();
                long time = timer.ElapsedMilliseconds;
                timer.Reset();

                Console.WriteLine("Put() took: {0} milliseconds", time);

                // ****** TEST GET METHOD
                timer.Start();

                for (int i = 0; i < TestSizes[n]; i++) {
                    Map.Get(keys[i]);
                }

                timer.Stop();
                time = timer.ElapsedMilliseconds;
                timer.Reset();

                Console.WriteLine("Get() took: {0} milliseconds", time);

                // ****** TEST REMOVE METHOD
                timer.Start();

                for (int i = 0; i < TestSizes[n]; i++) {
                    Map.Remove(keys[i]);
                }

                timer.Stop();
                time = timer.ElapsedMilliseconds;
                timer.Reset();

                Console.WriteLine("Remove() took: {0} milliseconds", time);

                Console.WriteLine();
            }
        }
        
        /// <summary>
        /// Generates many random strings
        /// </summary>
        /// <param name="ammount">ammount of strings to generate</param>
        /// <returns>list of strings</returns>
        private List<string> GenerateStrings(int ammount) {
            List<string> strings = new List<string>();

            for (int n = 0; n < ammount; n++) {
                strings.Add(RandomString(AvailableCharacters.Length));
            }

            return strings;
        }

        /// <summary>
        /// Generates a random string from the available characters
        /// </summary>
        /// <param name="length">length of the string</param>
        /// <returns>string</returns>
        private string RandomString(int length) {
            string s = "";
            
            for (int n = 0; n < length; n++) {
                s += AvailableCharacters[Rand.Next(AvailableCharacters.Length)];
            }

            return s;
        }
    }
}

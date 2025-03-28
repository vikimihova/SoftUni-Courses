using System.Threading.Tasks.Dataflow;

namespace _11_ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string command = Console.ReadLine();            

            while (command != "end")
            {
                string[] commandArray = command.Split();

                if (commandArray[0] == "exchange")
                {                    
                    integers = ExchangeIndex(commandArray, integers);
                }
                else if (commandArray[0] == "max")
                {
                    MaxEvenOdd(commandArray, integers);
                }
                else if (commandArray[0] == "min")
                {
                    MinEvenOdd(commandArray, integers);
                }
                else if (commandArray[0] == "first")
                {
                    FirstEvenOdd(commandArray, integers);
                }
                else if (commandArray[0] == "last")
                {
                    LastEvenOdd(commandArray, integers);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("[" + string.Join(", ", integers) + "]");
        }

        static int[] ExchangeIndex(string[] commandArray, int[] initialArray)
        {
            int[] newArray = new int[initialArray.Length];            

            int index = int.Parse(commandArray[1]);

            if (index >= initialArray.Length || index < 0)
            {
                Console.WriteLine("Invalid index");
                newArray = initialArray;
            }
            else if (index == initialArray.Length - 1)
            {
                newArray = initialArray;
            }
            else
            {
                int[] newFirstHalf = new int[initialArray.Length - index - 1];
                int[] newSecondHalf = new int[index + 1];

                for (int i = 0;(index + 1 + i) < initialArray.Length; i++)
                {
                    newFirstHalf[i] = initialArray[index + 1 + i];
                }

                for (int i = 0; i < index + 1; i++)
                {
                    newSecondHalf[i] = initialArray[i];
                }


                for (int i = 0; i < newFirstHalf.Length; i++)
                {
                    newArray[i] = newFirstHalf[i];
                }

                for (int i = newFirstHalf.Length; i < initialArray.Length; i++)
                {
                    newArray[i] = newSecondHalf[i - newFirstHalf.Length];
                }
            }

            return newArray;    
        }

        static void MaxEvenOdd(string[] commandArray, int[] integers)
        {
            int maxValue = int.MinValue;
            int maxValueIndex = 0;
            bool isEven = false;
            bool isOdd = false;

            if (commandArray[1] == "even")
            {            
                for (int i = 0; i < integers.Length; i++)
                {
                    if (integers[i] % 2 == 0 && integers[i] >= maxValue)
                    {
                        maxValue = integers[i];
                        maxValueIndex = i;
                        isEven = true;
                    }
                }
            }
            else if (commandArray[1] == "odd")
            {
                for (int i = 0; i < integers.Length; i++)
                {
                    if (integers[i] % 2 != 0 && integers[i] >= maxValue)
                    {
                        maxValue = integers[i];
                        maxValueIndex = i;
                        isOdd = true;
                    }
                }
            }

            if (!isEven && !isOdd)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(maxValueIndex);
            }            
        }

        static void MinEvenOdd(string[] commandArray, int[] integers)
        {
            int minValue = int.MaxValue;
            int minValueIndex = 0;
            bool isEven = false;
            bool isOdd = false;

            if (commandArray[1] == "even")
            {
                for (int i = 0; i < integers.Length; i++)
                {
                    if (integers[i] % 2 == 0 && integers[i] <= minValue)
                    {
                        minValue = integers[i];
                        minValueIndex = i;
                        isEven = true;
                    }
                }
            }
            else if (commandArray[1] == "odd")
            {
                for (int i = 0; i < integers.Length; i++)
                {
                    if (integers[i] % 2 != 0 && integers[i] <= minValue)
                    {
                        minValue = integers[i];
                        minValueIndex = i;
                        isOdd = true;
                    }
                }
            }

            if (!isEven && !isOdd)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(minValueIndex);
            }
        }

        static void FirstEvenOdd(string[] commandArray, int[] integers)
        {
            int count = int.Parse(commandArray[1]);
            int countTemp = 0;

            if (count > integers.Length)
            {
                Console.WriteLine("Invalid count"); 
                return;
            }

            int[] firstEvenOdd = new int[count];

            if (commandArray[2] == "even")
            {
                for (int i = 0; i < integers.Length && countTemp < count; i++)
                {
                    if (integers[i] % 2 == 0)
                    {
                        countTemp++;
                        firstEvenOdd[countTemp - 1] = integers[i];                        
                    }
                }
            }
            else if (commandArray[2] == "odd")
            {
                for (int i = 0; i < integers.Length && countTemp < count; i++)
                {
                    if (integers[i] % 2 != 0)
                    {
                        countTemp++;
                        firstEvenOdd[countTemp - 1] = integers[i];                        
                    }
                }
            }

            if (countTemp == 0)
            {
                Console.WriteLine("[]");
            }
            else if (countTemp < count)
            {
                int[] firstEvenOddShort = new int[countTemp];
                for (int i = 0; i < countTemp; i++)
                {
                    firstEvenOddShort[i] = firstEvenOdd[i];
                    Console.WriteLine("[" + string.Join(", ", firstEvenOddShort) + "]");
                }
            }
            else
            {
                Console.WriteLine("[" + string.Join(", ", firstEvenOdd) + "]");
            }            
        }

        static void LastEvenOdd(string[] commandArray, int[] integers)
        {
            int count = int.Parse(commandArray[1]);
            int countTemp = 0;

            if (count > integers.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            int[] lastEvenOdd = new int[count];

            if (commandArray[2] == "even")
            {
                for (int i = integers.Length - 1; i >= 0 && countTemp < count; i--)
                {
                    if (integers[i] % 2 == 0)
                    {
                        countTemp++;
                        lastEvenOdd[countTemp - 1] = integers[i];
                    }
                }
            }
            else if (commandArray[2] == "odd")
            {
                for (int i = integers.Length - 1; i >= 0 && countTemp < count; i--)
                {
                    if (integers[i] % 2 != 0)
                    {
                        countTemp++;
                        lastEvenOdd[countTemp - 1] = integers[i];
                    }
                }
            }

            if (countTemp == 0)
            {
                Console.WriteLine("[]");
            }
            else if (countTemp < count)
            {
                int[] lastEvenOddShort = new int[countTemp];
                for (int i = 0; i < countTemp; i++)
                {
                    lastEvenOddShort[i] = lastEvenOdd[i];
                    
                }
                lastEvenOddShort = lastEvenOddShort.Reverse().ToArray();
                Console.WriteLine("[" + string.Join(", ", lastEvenOddShort) + "]");
            }
            else
            {
                lastEvenOdd = lastEvenOdd.Reverse().ToArray();
                Console.WriteLine("[" + string.Join(", ", lastEvenOdd) + "]");
            }
        }
    }
}
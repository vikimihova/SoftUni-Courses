namespace _03_ZigZagArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputLines = int.Parse(Console.ReadLine());

            int[] arr1 = new int[numberOfInputLines];
            int[] arr2 = new int[numberOfInputLines];

            for (int i = 0; i < numberOfInputLines; i++)
            {
                int[] arrTemp = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < arrTemp.Length; j++)
                {
                    if (i % 2 == 0 || i == 0)
                    {
                        if (j % 2 == 0 || j == 0)
                        {
                            arr1[i] = arrTemp[j];
                        }
                        else
                        {
                            arr2[i] = arrTemp[j];
                        }
                    }
                    else
                    {
                        if (j % 2 == 0 || j == 0)
                        {
                            arr2[i] = arrTemp[j];
                        }
                        else
                        {
                            arr1[i] = arrTemp[j];
                        }
                    }
                    
                }
            }

            Console.WriteLine(string.Join(" ", arr1));
            Console.WriteLine(string.Join(" ", arr2));
        }
    }
}
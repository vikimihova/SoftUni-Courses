namespace _02_CommonElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split();
            string[] arr2 = Console.ReadLine().Split();

            foreach (string currentValue2 in arr2)
            {
                foreach (string currentValue1 in arr1)
                {
                    if (currentValue2 == currentValue1)
                    {
                        Console.Write(currentValue2 + " ");
                    }                    
                }
            }                
        }
    }
}
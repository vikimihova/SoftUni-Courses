namespace _04_ArrayRotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            int numberOfRotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfRotations; i++)
            {
                string firstValue = array[0];

                for (int j = 0; j < array.Length - 1; j++)
                {
                    array[j] = array[j + 1];
                }

                array[array.Length - 1] = firstValue;
            }

            Console.WriteLine(string.Join(" ", array));
        }
    }
}
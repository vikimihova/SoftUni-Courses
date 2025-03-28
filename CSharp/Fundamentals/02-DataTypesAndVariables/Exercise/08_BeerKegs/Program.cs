namespace _08_BeerKegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfKegs = int.Parse(Console.ReadLine());

            string biggestKegModelName = string.Empty;
            double biggestKegVolume = 0;


            for (int i = 0; i < numberOfKegs; i++)
            {
                string kegModelName = Console.ReadLine();
                float kegRadius = float.Parse(Console.ReadLine());
                int kegHeight = int.Parse(Console.ReadLine());

                double kegVolume = Math.PI * Math.Pow(kegRadius, 2) * kegHeight;

                if (kegVolume > biggestKegVolume)
                {
                    biggestKegModelName = kegModelName;
                    biggestKegVolume = kegVolume;
                }                
            }

            Console.WriteLine(biggestKegModelName);
        }
    }
}
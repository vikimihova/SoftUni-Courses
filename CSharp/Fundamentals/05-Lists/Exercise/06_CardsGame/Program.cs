namespace _06_CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerHand = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> secondPlayerHand = Console.ReadLine().Split(' ').Select(int.Parse).ToList();


            while (firstPlayerHand.Count > 0 && secondPlayerHand.Count > 0)
            {
                if (firstPlayerHand[0] == secondPlayerHand[0])
                {
                    firstPlayerHand.RemoveAt(0);
                    secondPlayerHand.RemoveAt(0);
                }
                else if (firstPlayerHand[0] > secondPlayerHand[0])
                {
                    int winningCard = firstPlayerHand[0];
                    int losingCard = secondPlayerHand[0];

                    secondPlayerHand.RemoveAt(0);
                    firstPlayerHand.RemoveAt(0);

                    firstPlayerHand.Add(winningCard);
                    firstPlayerHand.Add(losingCard);
                }
                else
                {
                    int winningCard = secondPlayerHand[0];
                    int losingCard = firstPlayerHand[0];

                    secondPlayerHand.RemoveAt(0);
                    firstPlayerHand.RemoveAt(0);

                    secondPlayerHand.Add(winningCard);
                    secondPlayerHand.Add(losingCard);
                }
            }

            int sum = 0;

            if (firstPlayerHand.Count == 0)
            {
                foreach (var card in secondPlayerHand)
                {
                    sum += card;
                }

                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
            else
            {
                foreach (var card in firstPlayerHand)
                {
                    sum += card;
                }

                Console.WriteLine($"First player wins! Sum: {sum}");
            }
        }
    }
}
namespace _03_Articles2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Article> listOfArticles = new List<Article>();

            int numberOfArticles = int.Parse(Console.ReadLine());  

            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] inputData = Console.ReadLine().Split(", ").ToArray();

                string title = inputData[0];
                string content = inputData[1];
                string author = inputData[2];

                listOfArticles.Add(new Article(title, content, author));
            }            

            foreach (Article article in listOfArticles)
            {
                Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
            }            
        }

        public class Article
        {
            public Article(string title, string content, string author)
            {
                Title = title;
                Content = content;
                Author = author;
            }

            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }
        }
    }
}
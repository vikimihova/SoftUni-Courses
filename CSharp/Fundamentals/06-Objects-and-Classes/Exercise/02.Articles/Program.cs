namespace _02_Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputData = Console.ReadLine().Split(", ").ToArray();
            string title = inputData[0];
            string content = inputData[1];
            string author = inputData[2];

            Article article = new Article(title, content, author);

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split(": ").ToArray();

                if (command[0] == "Edit")
                {
                    article.Edit(command[1]);
                }
                else if (command[0] == "ChangeAuthor")
                {
                    article.ChangeAuthor(command[1]);
                }
                else if (command[0] == "Rename")
                {
                    article.Rename(command[1]);
                }
            }

            Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
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

            public void Edit(string newContent)
            {
                Content = newContent;
            }

            public void ChangeAuthor(string newAuthor)
            {
                Author = newAuthor;
            }

            public void Rename(string newTitle)
            {
                Title = newTitle;
            }
        }
    }
}
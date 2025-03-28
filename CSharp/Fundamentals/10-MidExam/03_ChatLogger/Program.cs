namespace _03_ChatLogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> chatLog = new List<string>();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandContent = command.Split().ToArray();

                if (commandContent[0] == "Chat")
                {
                    chatLog.Add(commandContent[1]);
                }
                else if (commandContent[0] == "Delete")
                {
                    chatLog.Remove(commandContent[1]);
                }
                else if (commandContent[0] == "Edit")
                {
                    string message = commandContent[1];
                    string replacement = commandContent[2];
                    int index = 0;

                    if (chatLog.Contains(message))
                    {
                        index = chatLog.IndexOf(message);
                    }

                    chatLog.Remove(message);
                    chatLog.Insert(index, replacement);
                }
                else if (commandContent[0] == "Pin")
                {
                    string messageToPin = commandContent[1];

                    if (chatLog.Contains(messageToPin))
                    {
                        chatLog.Remove(messageToPin);
                        chatLog.Add(messageToPin);
                    }
                }
                else if (commandContent[0] == "Spam")
                {
                    for (int i = 1; i < commandContent.Length; i++)
                    {
                        chatLog.Add(commandContent[i]);
                    }
                }

                command = Console.ReadLine();
            }

            foreach (string message in chatLog)
            {
                Console.WriteLine(message);
            }            
        }
    }
}
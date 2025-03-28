namespace Hogwarts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string spell = Console.ReadLine();
            

            string command = Console.ReadLine();

            while (command != "Abracadabra")
            {
                string[] currentCommand = command.Split(" ").ToArray();

                if (currentCommand[0] == "Abjuration")
                {
                    spell = spell.ToUpper();
                    Console.WriteLine(spell);
                }
                else if (currentCommand[0] == "Necromancy")
                {
                    spell = spell.ToLower();
                    Console.WriteLine(spell);
                }
                else if (currentCommand[0] == "Illusion")
                {
                    int index = int.Parse(currentCommand[1]);
                    char letter = char.Parse(currentCommand[2]);

                    char[] spellArray = spell.ToCharArray();

                    if (index >= 0 && index < spellArray.Length)
                    {
                        spellArray[index] = letter;

                        spell = string.Join("", spellArray);

                        Console.WriteLine("Done!");
                    }
                    else
                    {
                        Console.WriteLine("The spell was too weak.");
                    }                    
                }
                else if (currentCommand[0] == "Divination")
                {
                    string firstSubstring = currentCommand[1];
                    string secondSubstring = currentCommand[2];

                    if (spell.Contains(firstSubstring))
                    {
                        spell = spell.Replace(firstSubstring, secondSubstring);

                        Console.WriteLine(spell);
                    }
                }
                else if (currentCommand[0] == "Alteration")
                {
                    string firstSubstring = currentCommand[1];                    

                    if (spell.Contains(firstSubstring))
                    {
                        int index = spell.IndexOf(firstSubstring);

                        spell = spell.Remove(index, firstSubstring.Length);

                        Console.WriteLine(spell);
                    }
                }
                else
                {
                    Console.WriteLine("The spell did not work!");
                }

                command = Console.ReadLine();
            }
        }
    }
}
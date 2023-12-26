using _07.MilitaryElite.Contracts;
using _07.MilitaryElite.Models;

namespace _07.MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;

            List<IPrivate> allPrivates = new List<IPrivate>();
            

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    if (tokens[0] == "Private")
                    {
                        IPrivate soldier = new Private(tokens[1], tokens[2], tokens[3], decimal.Parse(tokens[4]));
                        allPrivates.Add(soldier);

                        Console.WriteLine(soldier.ToString());
                    }
                    else if (tokens[0] == "LieutenantGeneral")
                    {
                        ILieutenantGeneral general = new LieutenantGeneral(tokens[1], tokens[2], tokens[3], decimal.Parse(tokens[4]));

                        foreach (var token in tokens.Skip(5))
                        {
                            IPrivate soldier = allPrivates.FirstOrDefault(x => x.Id == token);
                            general.Privates.Add(soldier);
                        }

                        Console.WriteLine(general.ToString());
                    }
                    else if (tokens[0] == "Engineer")
                    {
                        IEngineer engineer = new Engineer(tokens[1], tokens[2], tokens[3], decimal.Parse(tokens[4]), tokens[5]);

                        for (int i = 6; i < tokens.Length; i += 2)
                        {
                            Repair repair = new Repair(tokens[i], int.Parse(tokens[i + 1]));
                            engineer.Repairs.Add(repair);
                        }

                        Console.WriteLine(engineer.ToString());
                    }
                    else if (tokens[0] == "Commando")
                    {

                        ICommando commando = new Commando(tokens[1], tokens[2], tokens[3], decimal.Parse(tokens[4]), tokens[5]);

                        for (int i = 6; i < tokens.Length; i += 2)
                        {
                            try
                            {
                                Mission mission = new Mission(tokens[i], tokens[i + 1]);
                                commando.Missions.Add(mission);
                            }
                            catch (ArgumentException ex) { }
                        }

                        Console.WriteLine(commando.ToString());
                    }
                    else if (tokens[0] == "Spy")
                    {
                        ISpy spy = new Spy(tokens[1], tokens[2], tokens[3], int.Parse(tokens[4]));

                        Console.WriteLine(spy.ToString());
                    }
                }
                catch (ArgumentException ex) { }                
            }
        }
    }
}

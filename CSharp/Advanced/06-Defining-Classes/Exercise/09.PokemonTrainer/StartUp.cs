using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace _09.PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new();
            HashSet<string> trainerNames = new();

            string command;

            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] commandTokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = commandTokens[0];
                string pokemonName = commandTokens[1];
                string pokemonElement = commandTokens[2];
                int pokemonHealth = int.Parse(commandTokens[3]);

                Trainer trainer = new Trainer(trainerName);

                if (!trainerNames.Contains(trainerName))
                {
                    trainers.Add(trainer);
                }

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                trainer.Pokemons.Add(pokemon);
            }

            while ((command = Console.ReadLine()) != "End")
            {
                foreach (Trainer trainer in trainers)
                {
                    if (trainer.Pokemons.Any(x => x.Element == command))
                    {
                        trainer.BadgesCount++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            trainer.Pokemons[i].Health -= 10;

                            if (trainer.Pokemons[i].Health <= 0)
                            {
                                trainer.Pokemons.Remove(trainer.Pokemons[i]);
                                i--;
                            }
                        }
                    }
                }
            }

            foreach (Trainer trainer in trainers.OrderByDescending(x => x.BadgesCount))
            {
                Console.WriteLine($"{trainer.Name} {trainer.BadgesCount} {trainer.Pokemons.Count}");
            }
        }
    }
}
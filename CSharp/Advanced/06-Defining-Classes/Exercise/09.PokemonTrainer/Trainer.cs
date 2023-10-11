using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            BadgesCount = 0;
			Pokemons = new List<Pokemon>();
        }

        private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private int badgesCount;

		public int BadgesCount
		{
			get { return badgesCount; }
			set { badgesCount = value; }
		}

		private List<Pokemon> pokemons;

		public List<Pokemon> Pokemons
		{
			get { return pokemons; }
			set { pokemons = value; }
		}
	}
}

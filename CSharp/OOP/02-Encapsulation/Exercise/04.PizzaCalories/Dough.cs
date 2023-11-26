using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private const double BaseCaloriesPerGram = 2;
        private const string ArgumentExceptionMessageDoughType = "Invalid type of dough.";
        private const string ArgumentExceptionMessageWeight = "Dough weight should be in the range [1..200].";

        private string flourType;
        private string bakingTechnique;
        private double weightInGrams;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            WeightInGrams = grams;
        }

        private string FlourType
        {
            get 
            { 
                return flourType; 
            }
            set 
            {
                if (value.ToLower() != "white" && 
                    value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException(ArgumentExceptionMessageDoughType);
                }

                flourType = value.ToLower(); 
            }
        }
        private string BakingTechnique
        {
            get 
            { 
                return bakingTechnique; 
            }
            set 
            {
                if (value.ToLower() != "crispy" && 
                    value.ToLower() != "chewy" && 
                    value.ToLower() != "homemade")
                {
                    throw new ArgumentException(ArgumentExceptionMessageDoughType);
                }

                bakingTechnique = value.ToLower(); 
            }
        }
        private double WeightInGrams
        {
            get 
            { 
                return weightInGrams; 
            }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(ArgumentExceptionMessageWeight);
                }

                weightInGrams = value;
            }
        }
        public double Calories
        {
            get
            {
                return GetCalories(FlourType, BakingTechnique);
            }
        }

        private double GetCalories(string flourType, string bakingTechnique)
        {
            double modifierByFlourType = 1;
            double modifierByBakingTechnique = 1;

            switch (flourType)
            {
                case "white":
                    modifierByFlourType = 1.5;
                    break;
                case "wholegrain":
                    modifierByFlourType = 1.0;
                    break;
                default:
                    break;
            }

            switch (bakingTechnique)
            {
                case "crispy":
                    modifierByBakingTechnique = 0.9;
                    break;
                case "chewy":
                    modifierByBakingTechnique = 1.1;
                    break;
                case "homemade":
                    modifierByBakingTechnique = 1.0;
                    break;
                default:
                    break;
            }

            return WeightInGrams * BaseCaloriesPerGram * modifierByFlourType * modifierByBakingTechnique;
        }

    }
}

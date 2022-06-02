using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Model
{
    [Serializable]
    public class EatingList
    {

        public Eating Eating { get; }

        public Food Food { get; }

        public double countGramm { get; set; }
        public EatingList(Eating eating, Food food, double count)
        {
            Eating = eating;
            Food = food;
            countGramm = count;
        }
    }
}

using System;

namespace Fitness.BL.Model
{
    [Serializable]
    public class EatingList
    {
        public int Id { get; set; }

        public int EatingId { get; set; }
        public Eating Eating { get; set; }

        public int FoodId { get; set; }
        public Food Food { get; set; }

        public double countGramm { get; set; }
        public EatingList(Eating eating, Food food, double count)
        {
            Eating = eating;
            Food = food;
            countGramm = count;
        }
    }
}

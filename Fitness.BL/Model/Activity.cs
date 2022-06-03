using System;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public double Calories { get; set; }

        public Activity(string name, double calories)
        {
            Name = name;
            Calories = calories;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

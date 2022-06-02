using System;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Еда.
    /// </summary>
    [Serializable]
    public class Food
    {
        #region Свойства
        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydrtes { get; }
        /// <summary>
        /// Калорийность.
        /// </summary>
        public double Calories { get; }

        #endregion

        public Food(string name): this(name,0,0,0,0){}

        public Food(string name, double proteins, double fats, double carbohydrtes, double calories)
        {
            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrtes = carbohydrtes / 100.0;
            Calories = calories / 100.0;
        }

        public override string ToString()
        {
            return $"{Name} (Ж-{Proteins:f2},Б-{Fats:f2},У-{Carbohydrtes:f2},Кал-{Calories:f2})";
        }
    }
}

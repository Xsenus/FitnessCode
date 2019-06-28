using System;

namespace FitnessCode.BL.Model
{
    /// <summary>
    /// Еда
    /// </summary>
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Имя продукта.
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
        public double Carbohydrates { get; }

        /// <summary>
        /// Калории за 100 грамм продукта.
        /// </summary>
        public double Calories { get; }

        /// <summary>
        /// Калории за 1 грамм продукта.
        /// </summary>
        private double CaloriesOneGram { get { return Calories / 100.0; } }
        /// <summary>
        /// Белков в 1 грамме продукта.
        /// </summary>
        private double ProteinsOneGram { get { return Proteins / 100.0; } }
        /// <summary>
        /// Жиры в 1 грамме продукта.
        /// </summary>
        private double FatsOneGram { get { return Fats / 100.0; } }
        /// <summary>
        /// Углеводы в 1 грамме продукта.
        /// </summary>
        private double CarbohydratesOneGram { get { return Carbohydrates / 100.0; } }

        public Food(string name) : this(name, 0, 0, 0, 0) { }

        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            // TODO: проверка

            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

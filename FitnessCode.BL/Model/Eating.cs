using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessCode.BL.Model
{
    /// <summary>
    /// Прием пищи.
    /// </summary>
    [Serializable]
    public class Eating
    {
        public int Id { get; set; }

        /// <summary>
        /// Момент приема пищи.
        /// </summary>
        public DateTime Moment { get; set; }

        public Dictionary<Food, double> Foods { get; set; }

        public int UserId { get; set; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public virtual User User { get; set; }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.",nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        public Eating() { }

        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }

    }
}

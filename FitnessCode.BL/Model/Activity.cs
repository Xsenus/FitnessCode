using System;

namespace FitnessCode.BL.Model
{
    [Serializable]
    public class Activity
    {
        public string Name { get; }

        public double CaloriesPerMinute { get; }
        public object Key { get; set; }

        public Activity(string name, double caloriesPerMinute)
        {
            // TODO: проверка

            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }


        public override string ToString()
        {
            return Name;
        }
    }
}

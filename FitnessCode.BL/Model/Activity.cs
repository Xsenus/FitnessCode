﻿using System;
using System.Collections.Generic;

namespace FitnessCode.BL.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }

        public double CaloriesPerMinute { get; set; }

        public object Key { get; set; }

        public Activity() { }

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

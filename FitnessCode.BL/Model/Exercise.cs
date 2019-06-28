﻿using System;

namespace FitnessCode.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public DateTime Start { get; }
        public DateTime Finish { get; }
        public Activity Activity { get; }
        public User User { get; }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            // TODO: Проверка

            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
    }
}

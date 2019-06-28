using FitnessCode.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessCode.BL.Controller
{
    [Serializable]
    public class ExerciseController : BaseController
    {
        private User user;

        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }

        private const string EXERCISE_FILE_NAME = "exercise.dat";
        private const string ACTIVITIES_FILE_NAME = "activities.dat";

        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));

            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        }

        public void Add(Activity activity, DateTime start, DateTime finish)
        {
            var act = Activities.SingleOrDefault(s => s.Name == activity.Name);

            if (act == null)
            {
                Activities.Add(activity);

                var exercise = new Exercise(start, finish, activity, user);
                Exercises.Add(exercise);                
            }
            else
            {
                var exercise = new Exercise(start, finish, act, user);
                Exercises.Add(exercise);
            }
            Save();
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<List<Exercise>>(EXERCISE_FILE_NAME) ?? new List<Exercise>();
        }

        private void Save()
        {
            Save(EXERCISE_FILE_NAME, Exercises);
            Save(ACTIVITIES_FILE_NAME, Activities);
        }
    }
}

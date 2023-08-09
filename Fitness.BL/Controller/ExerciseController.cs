using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    public class ExerciseController : ControllerBase
    {
        const string EXERCISES_FILE_NAME = "exercises.dat";
        const string ACTIVITIES_FILE_NAME = "activities.dat";
        private readonly User user;
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }
        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        }

        private List<Exercise>? GetAllExercises()
        {
            return Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }

        public void Add(Activity activity, DateTime start, DateTime finish)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
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

        private void Save()
        {
            Save(EXERCISES_FILE_NAME, Exercises);
            Save(ACTIVITIES_FILE_NAME, Activities);
        }
    }
}

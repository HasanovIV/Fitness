using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    public class ExerciseController: ControllerBase
    {
        private const string ACTIVITIES_FILE_NAME = "activities.dat";
        private const string EXERCISES_FILE_NAME = "exercises.dat";
        private const string EXERCISESLIST_FILE_NAME = "exercisesList.dat";
        public User User { get; set; }

        public List<Activity> Activities { get; set; }
        public List<Exercise> Exercises { get; set; }
        public List<ExerciseList> ExerciseLists { get; set; }

        public List<Exercise> ExercisesUser { get; set; }
        public List<ExerciseList> ExerciseListsUser { get; set; }

        public ExerciseController(User user)
        {
            this.User = user ?? throw new ArgumentNullException($"Пользователь не может быть пустым {nameof(user)}");

            Activities = GetActivities();
            Exercises = GetExercise();
            ExerciseLists = GetExerciseList();

            ExercisesUser = new List<Exercise>();
            ExerciseListsUser = new List<ExerciseList>();

            var _exercisesUser = Exercises.Where(ex => ex.User.Login == User.Login).ToList<Exercise>();
            if (_exercisesUser != null)
            {
                ExercisesUser = _exercisesUser;
            }

            // TODO
            // Не кооректно отрабатывает отбор linq изза ссылочных данных по сериализации
            foreach (var itemList in ExerciseLists)
            {
                foreach (var itemUser in ExercisesUser)
                {
                    if (itemUser.User.Login == itemList.Exercise.User.Login && itemUser.Moment == itemList.Exercise.Moment)
                    {
                        ExerciseListsUser.Add(itemList);
                        break;
                    }
                }
            }
        }
        public void Save()
        {
            Save(ACTIVITIES_FILE_NAME, Activities);
            Save(EXERCISES_FILE_NAME, Exercises);
        }

        public List<Activity> GetActivities()
        {
            return Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        }

        public List<Exercise> GetExercise()
        {
            return Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }

        public List<ExerciseList> GetExerciseList()
        {
            return Load<List<ExerciseList>>(EXERCISESLIST_FILE_NAME) ?? new List<ExerciseList>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Fitness.BL.Model;
using Fitness.BL.Controller;

namespace Fitness.CMD
{
    public static class Commands
    {
        public static void AddNewEatingUser(EatingContoller eatingContoller)
        {
            var dateEating = ControllerBase.ParseDateTime();

            Console.WriteLine("Введите наименование пищи:");
            var nameFood = Console.ReadLine();

            Food findFood = eatingContoller.foods.SingleOrDefault(f => f.Name == nameFood);
            if (findFood == null)
            {
                Console.WriteLine("Введите информаци о пище.");

                var proteins = ControllerBase.ParseDouble("количество белков");
                var fats = ControllerBase.ParseDouble("количество жиров");
                var carbohydrtes = ControllerBase.ParseDouble("количество углеводов");
                var calories = ControllerBase.ParseDouble("количество калорий");

                findFood = new Food(nameFood, proteins, fats, carbohydrtes, calories);

                eatingContoller.foods.Add(findFood);

            }

            var count = ControllerBase.ParseDouble("количесво для приема");

            Eating newEat = (Eating)eatingContoller.eatings.SingleOrDefault(e => e.Moment == dateEating && e.User.Login == eatingContoller.user.Login);
            if (newEat == null)
            {
                newEat = new Eating(eatingContoller.user, dateEating);

                eatingContoller.eatings.Add(newEat);
                eatingContoller.eatingsUser.Add(newEat);
            }

            var newEatList = new EatingList(newEat, findFood, count);

            eatingContoller.eatingLists.Add(newEatList);
            eatingContoller.eatingListsUser.Add(newEatList);

            eatingContoller.Save();

            Console.WriteLine("Прием пищи сохранен.");

        }

        public static void DisplayListEatingUser(EatingContoller eatingContoller)
        {
            foreach (var item in eatingContoller.eatingsUser)
            {
                Console.WriteLine(new string('-', 50));
                Console.WriteLine($"Дата приема {item.Moment}");
                Console.WriteLine();

                foreach (var itemList in eatingContoller.eatingListsUser.Where(list => list.Eating.User.Login == item.User.Login && list.Eating.Moment == item.Moment))
                {
                    Console.WriteLine($"Еда {itemList.Food.ToString()} в количестве {itemList.countGramm:f2}");
                }
            }
        }

        public static void DisplayListExerciseUser(ExerciseController exerciseController)
        {
            foreach (var item in exerciseController.ExercisesUser)
            {
                Console.WriteLine(new string('-', 50));
                Console.WriteLine($"Дата тренировки {item.Moment}");
                Console.WriteLine();

                foreach (var itemList in exerciseController.ExerciseListsUser.Where(list => list.Exercise.User.Login == item.User.Login && list.Exercise.Moment == item.Moment))
                {
                    Console.WriteLine($"Упражнение {itemList.Activity.ToString()} каллорий {itemList.Activity.Calories:f2}");
                }
            }
        }

        public static void AddNewExerciseUser(ExerciseController exerciseController)
        {
            var dateExercise = ControllerBase.ParseDateTime();

            Console.WriteLine("Введите наименование упражнения:");
            var nameAct = Console.ReadLine();

            Activity findAct = exerciseController.Activities.SingleOrDefault(f => f.Name == nameAct);
            if (findAct == null)
            {
                Console.WriteLine("Введите информаци об упражнении.");

                var calories = ControllerBase.ParseDouble("количество калорий");

                findAct = new Activity(nameAct, calories);

                exerciseController.Activities.Add(findAct);

            }

            Exercise newExercise = (Exercise)exerciseController.Exercises.SingleOrDefault
                (e => e.Moment == dateExercise && e.User.Login == exerciseController.User.Login);

            if (newExercise == null)
            {
                newExercise = new Exercise(exerciseController.User, dateExercise);

                exerciseController.Exercises.Add(newExercise);
                exerciseController.ExercisesUser.Add(newExercise);
            }

            var newExerciseList = new ExerciseList(newExercise, findAct);

            exerciseController.ExerciseLists.Add(newExerciseList);
            exerciseController.ExerciseListsUser.Add(newExerciseList);

            exerciseController.Save();

            Console.WriteLine("Тренировка сохранена.");

        }


    }
}

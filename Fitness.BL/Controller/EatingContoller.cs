using System;
using System.Linq;
using System.Collections.Generic;
using Fitness.BL.Model;

namespace Fitness.BL.Controller
{
    public class EatingContoller: ControllerBase
    {
        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";
        private const string EATINGLIST_FILE_NAME = "eatinglist.dat";

        private readonly User user;
        public List<Food> foods;
        public List<Eating> eatings;
        public List<EatingList> eatingLists;

        public List<Eating> eatingsUser;
        public List<EatingList> eatingListsUser;

        public EatingContoller(User user)
        {
            this.user = user ?? throw new ArgumentNullException($"Пользователь не может быть пустым {nameof(user)}");
            
            foods = GetAllFoods();
            eatings = GetEatings();
            eatingLists = GetEatingLists();

            eatingsUser = new List<Eating>();
            eatingListsUser = new List<EatingList>();
            
            var _eatingsUser = eatings.Where(eat => eat.User.Equals(this.user)).ToList<Eating>();
            if (_eatingsUser != null)
            {
                eatingsUser = _eatingsUser;
            }

            // Не кооректно отрабатывает отбор linq изза ссылочных данных
            //var _eatingListsUser = eatingLists.Where(list => eatingsUser.Contains(list.Eating)).ToList<EatingList>();
            //if (_eatingListsUser != null)
            //{
            //    eatingListsUser = _eatingListsUser;
            //}

            foreach (var itemList in eatingLists)
            {
                foreach (var itemUser in eatingsUser)
                {
                    if (itemUser.User.Login == itemList.Eating.User.Login && itemUser.Moment == itemList.Eating.Moment)
                    {
                        eatingListsUser.Add(itemList);
                        break;
                    }
                }
            }          
        }

        public void Save()
        {
            Save(FOODS_FILE_NAME, foods);
            Save(EATINGS_FILE_NAME, eatings);
            Save(EATINGLIST_FILE_NAME, eatingLists);
        }

        public List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
        }

        public List<Eating> GetEatings()
        {
            return Load<List<Eating>>(EATINGS_FILE_NAME) ?? new List<Eating>();
        }

        public List<EatingList> GetEatingLists()
        {
            return Load<List<EatingList>>(EATINGLIST_FILE_NAME) ?? new List<EatingList>();
        }

        public static void AddNewEatingUser(EatingContoller eatingContoller)
        {
            var dateEating = ParseDateTime();

            Console.WriteLine("Введите наименование пищи:");
            var nameFood = Console.ReadLine();

            Food findFood = eatingContoller.foods.SingleOrDefault(f => f.Name == nameFood);
            if (findFood == null)
            {
                Console.WriteLine("Введите информаци о пище.");

                var proteins = ParseDouble("количество белков");
                var fats = ParseDouble("количество жиров");
                var carbohydrtes = ParseDouble("количество углеводов");
                var calories = ParseDouble("количество калорий");

                findFood = new Food(nameFood, proteins, fats, carbohydrtes, calories);
                
                eatingContoller.foods.Add(findFood);

            }

            var count = ParseDouble("количесво для приема");

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
    }

}

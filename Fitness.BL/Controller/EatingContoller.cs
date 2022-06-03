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

        public readonly User user;
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

            // TODO
            // Не кооректно отрабатывает отбор linq изза ссылочных данных по сериализации
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

    }

}

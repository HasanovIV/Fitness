using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Eating
    {
        public DateTime Moment { get; }

        public User User { get; }

        public List<EatingList> eatingLists { get; set; }

        public Eating(User user, DateTime dateTime)
        {
            if (user is null)
            {
                throw new ArgumentNullException($"Пользователь не может быть пустым {nameof(user)}");
            }

            User = user;
            Moment = dateTime;
        }

        public void Add(Food food, double count)
        {
            var eating = eatingLists.SingleOrDefault(f => f.Food == food);
            if (eating == null)
            {
                eatingLists.Add(new EatingList(this, food, count));
            }
            else
            {
                eating.countGramm += count;
            }
        }
    }
}

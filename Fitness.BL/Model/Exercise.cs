using System;
using System.Collections.Generic;

namespace Fitness.BL.Model
{
    public class Exercise
    {
        public int Id { get; set; }

        public DateTime Moment { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public virtual List<Activity> Activities { get; set; }

        public Exercise(User user, DateTime dateTime)
        {
            if (user is null)
            {
                throw new ArgumentNullException($"Пользователь не может быть пустым {nameof(user)}");
            }

            User = user;
            Moment = dateTime;
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Fitness.BL.Model;

namespace Fitness.BL.Controller
{
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User CurrentUser { get; }

        /// <summary>
        /// Список пользователей
        /// </summary>
        public List<User> Users { get; }

        public bool IsNewUser { get; }

        public UserController()
        {
            Users = GetUsersData();
            IsNewUser = false;
        }

        public UserController(string userName) : this()
        {
            CurrentUser = Users.SingleOrDefault(u => u.Login == userName);
            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                CurrentUser.Gender = new Gender("unkhow");
                Users.Add(CurrentUser);

                IsNewUser = true;
            }
        }

        /// <summary>
        /// Заполнить нового пользователя.
        /// </summary>
        /// <param name="genderName">Пол.</param>
        /// <param name="birthDate">Дата рождения.</param>
        /// <param name="weight">Вес.</param>
        /// <param name="height">Рост.</param>
        public void SetNewUserData(string genderName, DateTime birthDate, int weight, int height)
        {
            if (CurrentUser != null)
            {
                CurrentUser.Gender = new Gender(genderName);
                CurrentUser.BirthDate = birthDate;
                CurrentUser.Weight = weight;
                CurrentUser.Height = height;

            }
        }

        /// <summary>
        /// Получить список сохраненных пользователей.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
        }

        /// <summary>
        /// Сохранить пользователей.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }
    
        public static DateTime ParseDateTime()
        {
            DateTime result;
            while(true)
            {
                Console.WriteLine("Введите дату рождения (dd.mm.yyyy)");
                
                if (DateTime.TryParse(Console.ReadLine(), out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты!");
                }
            }
        }

        public static int ParseInt(string name)
        {
            int result;
            while (true)
            {
                Console.WriteLine($"Введите {name}");

                if (Int32.TryParse(Console.ReadLine(), out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {name}!");
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(UserController))
            {
                UserController controller = (UserController)obj;

                bool result =
                    (this.CurrentUser.Login == controller.CurrentUser.Login) &&
                    (this.CurrentUser.Gender.Name == controller.CurrentUser.Gender.Name) &&
                    (this.CurrentUser.Age == controller.CurrentUser.Age) &&
                    (this.CurrentUser.BirthDate == controller.CurrentUser.BirthDate) &&
                    (this.CurrentUser.Height == controller.CurrentUser.Height) &&
                    (this.CurrentUser.Weight == controller.CurrentUser.Weight);

                return result;
            }
            else
            {
                return base.Equals(obj);
            }
        }

    }
}

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Fitness.BL.Model;

namespace Fitness.BL.Controller
{
    public class UserController
    {

        public User User { get; }

        public UserController(string userName, string genderName, DateTime birthDate,
            int weight, int height)
        {
            var gender = new Gender(genderName);
            var user = new User(userName, gender, birthDate, weight, height);

            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым");
        }

        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }

        }
    }
}

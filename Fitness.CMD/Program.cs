using System;
using Fitness.BL.Controller;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Введите имя пользователя");
                var name = Console.ReadLine();

                var userController = new UserController(name);

                if (userController.IsNewUser)
                {
                    Console.WriteLine("Пользователь не найден. Создание нового пользователя.");
                    Console.WriteLine("Введите пол");
                    var nameGender = Console.ReadLine();

                    var dateBirth = UserController.ParseDateTime();
                    var weight = UserController.ParseInt("вес");
                    var height = UserController.ParseInt("рост");

                    userController.SetNewUserData(nameGender, dateBirth, weight, height);

                    userController.Save();

                    Console.WriteLine("Пользователь сохранен.");
                    Console.ReadLine();

                }
                else
                {
                    Console.WriteLine(userController.CurrentUser.ToString());
                    Console.ReadLine();
                }

            }

        }
    }
}

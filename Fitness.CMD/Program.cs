﻿using System;
using System.Linq;
using Fitness.BL.Controller;
using Fitness.BL.Model;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            var userController = new UserController(name);

            if (userController.IsNewUser)
            {
                Console.WriteLine("Пользователь не найден. Создание нового пользователя.");
                Console.WriteLine("Введите пол");
                var nameGender = Console.ReadLine();

                var dateBirth = ControllerBase.ParseDateTime();
                var weight = ControllerBase.ParseInt("вес");
                var height = ControllerBase.ParseInt("рост");

                userController.SetNewUserData(nameGender, dateBirth, weight, height);

                userController.Save();

                Console.WriteLine("Пользователь сохранен.");
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine($"Вход выполнен пользователем {userController.CurrentUser.ToString()}");
                Console.ReadLine();
            }

            EatingContoller eatingContoller = new EatingContoller(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine(new string('-', 50));
                Console.WriteLine("Введите комаду (1 - спиисок приема пиши, 2-записать новый прием пищи):");
                
                var keyRead = Console.ReadKey().Key;
                Console.WriteLine();

                switch (keyRead)
                {
                    case ConsoleKey.D1:
                        EatingContoller.DisplayListEatingUser(eatingContoller);
                        break;
                    case ConsoleKey.D2:
                        EatingContoller.AddNewEatingUser(eatingContoller);
                        break;
                    default:
                        break;
                }
            }           

        }
    }
}

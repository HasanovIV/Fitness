using System;
using Fitness.BL.Controller;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            Console.WriteLine("Введите пол");
            var nameGender = Console.ReadLine();

            Console.WriteLine("Введите дату рождения");
            var dateBirth = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Введите вес");
            var weight = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Введите рост");
            var height = Int32.Parse(Console.ReadLine());

            var userControll = new UserController(name, nameGender, dateBirth, weight, height);

            userControll.Save();

        }
    }
}

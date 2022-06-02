using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    public abstract class ControllerBase
    {
        protected void Save(string fileName, object item)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }

        protected T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T items)
                {
                    return items;
                }
                else
                {
                    return default(T);
                }
            }

        }

        public static DateTime ParseDateTime()
        {
            DateTime result;
            while (true)
            {
                Console.WriteLine("Введите дату (dd.mm.yyyy)");

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

        public static double ParseDouble(string name)
        {
            double result;
            while (true)
            {
                Console.WriteLine($"Введите {name}");

                if (Double.TryParse(Console.ReadLine(), out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {name}!");
                }
            }
        }
    }
}

using FitnessCode.BL.Controller;
using FitnessCode.BL.Model;
using System;

namespace FitnessCode.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложения FitnessCode.");

            Console.WriteLine("Введите имя пользователя:");
            var name = Console.ReadLine();

            Console.WriteLine("Введите пол пользователя:");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите дату рождения пользователя:");
            var birthdate = DateTime.Parse(Console.ReadLine()); // TODO: переписать

            Console.WriteLine("Введите вес пользователя:");
            var weight = Double.Parse(Console.ReadLine());

            Console.WriteLine("Введите рост пользователя:");
            var height = Double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthdate, weight, height);

            userController.Save();

        }
    }
}

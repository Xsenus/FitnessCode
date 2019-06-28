using FitnessCode.BL.Controller;
using FitnessCode.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace FitnessCode.CMD
{
    class Program
    {
        static void Main(string[] args)
        {            
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceManager = new ResourceManager("FitnessCode.CMD.Language.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));

            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");

                var gender = Console.ReadLine();
                var birthDate = ParseDateTime("дата рождения");
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("E - ввести прием пиши.");
                Console.WriteLine("А - ввести упражнение.");
                Console.WriteLine("Q - выход.");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t {item.Key} - {item.Value}");
                        }
                        Console.WriteLine();
                        break;

                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.Activity, exe.Start, exe.Finish);

                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"{item.Activity} с {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                        Console.WriteLine();
                        break;

                    case ConsoleKey.Q:

                        Environment.Exit(0);
                        break;
                }
            }            
        }

        private static (DateTime Start, DateTime Finish, Activity Activity) EnterExercise()
        {
            Console.WriteLine();
            Console.Write("Введите название упражнения: ");
            var name = Console.ReadLine();
            var energy = ParseDouble("расход энергии в минуту");
            var start = ParseDateTime("начало упражнения");
            var finish = ParseDateTime("конец упражнения");
            var activity = new Activity(name, energy);

            return (start, finish, activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine();
            Console.Write("Введите имя продукта: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("калорийность");
            var proteins = ParseDouble("протеины");
            var fats = ParseDouble("жиры");
            var carbohydrates = ParseDouble("углеводы");

            var weight = ParseDouble("вес порции");

            return (new Food(food, calories, proteins, fats, carbohydrates), weight);
        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Введите {value} (dd.MM.yyyy): ");

                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}.");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");

                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}.");
                }
            }
        }
    }
}

using Fitness.BL.Controller;
using Fitness.BL.Model;
using Fitness.CMD.Languages;
using System.Globalization;
using System.Resources;

namespace Fitness.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var culture = CultureInfo.CreateSpecificCulture("en-us");//указываем язык, который уже есть, поменяв на ru-ru будем получать русский текст
            var resourceManager = new ResourceManager("Fitness.CMD.Languages.Messages", typeof(Program).Assembly);
            //Первым аргументом идёт корневое имя файла ресурсов без разрешения
            //Вторым принимает саму сборку. Другими словами получаем главный класс нашего приложения



            Console.WriteLine(resourceManager.GetString("Hello",culture));

            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            string name = Console.ReadLine();

            UserController userController = new UserController(name);
            EatingController eatingController = new EatingController(userController.CurrentUser);
            ExerciseController exerciseController = new ExerciseController(userController.CurrentUser);


            if (userController.IsNewUser) //если новый пользователь true(свойство в нашем C), то
            {
                Console.WriteLine(resourceManager.GetString("EnterGender", culture)); //запрашивается пол
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime("дата рождения"); //Др
                double weight = ParseDouble("вес"); //Вес
                double height = ParseDouble("рост"); //Рост

                userController.SetNewUserData(gender, birthDate, weight, height); 
            }

            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("E - ввести приём пищи");
                Console.WriteLine("A - ввести упражнение");
                Console.WriteLine("Q - выход");
                var key = Console.ReadKey(); //создание вызова действий из консоли по ключу
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);
                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);
                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} c {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }

                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

            }

        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.WriteLine("Введите название упражнения");
            var name = Console.ReadLine();

            var energy = ParseDouble("расход энергии в минуту");

            var begin = ParseDateTime("начало упражнения");
            var end = ParseDateTime("окончание упражнения");

            var activity = new Activity(name, energy);
            return (begin, end, activity);
        }



        private static (Food Food, double Weight) EnterEating() //privat static - по умолчанию
        {
            Console.WriteLine("Введите название продукта");
            var food = Console.ReadLine();

            var calories = ParseDouble("калорийность");
            var proteins = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbohydrates = ParseDouble("углеводы");

            var weight = ParseDouble("вес порции");
            var product = new Food(food, calories, proteins, fats, carbohydrates);

            return (Food: product, Weight: weight); //кортеж возращает Tuple<Food, double>(product, weight)
        }


        static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value)) //Если удалось преобразовать в double, значит всё норм, возвращаем это значение
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат гендера: {name}");
                }
            }
        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;

            while (true)
            {
                Console.Write($"Введите {value} (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate)) //Если удалось преобразовать в DateTime, значит всё норм, возвращаем это значение
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}");
                }
            }

            return birthDate;
        }
    }
}
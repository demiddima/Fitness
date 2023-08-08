using Fitness.BL.Controller;
using Fitness.BL.Model;

namespace Fitness.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение Fitness.");

            Console.WriteLine("Введите имя пользователя: ");
            string name = Console.ReadLine();

            UserController userController = new UserController(name);
            EatingController eatingController = new EatingController(userController.CurrentUser);


            if (userController.IsNewUser) //если новый пользователь true(свойство в нашем C), то
            {
                Console.WriteLine("Введите пол:"); //запрашивается пол
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime(); //Др
                double weight = ParseDouble("вес"); //Вес
                double height = ParseDouble("рост"); //Рост

                userController.SetNewUserData(gender, birthDate, weight, height); 
            }

            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine();


            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("E - ввести приём пищи");
            var key = Console.ReadKey(); //создание вызова действий из консоли по ключу
            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating(); //вызов кортежа
                eatingController.Add(foods.Food, foods.Weight); //С помощью кортежа добавляем в наш приём пищи продукт и его вес

                foreach (var item in eatingController.Eating.Foods) //Поскольку это у нас словарик, то его можно перебрать таким образовм
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");//И отобразить нужные данные
                }
            }

            (Food Food, double Weight) EnterEating() //privat static - по умолчанию
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

        static DateTime ParseDateTime()
        {
            DateTime birthDate;

            while (true)
            {
                Console.Write("Введите дату рождения(dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate)) //Если удалось преобразовать в DateTime, значит всё норм, возвращаем это значение
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат даты рождения");
                }
            }

            return birthDate;
        }
    }
}
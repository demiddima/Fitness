using Fitness.BL.Controller;

namespace Fitness.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение Fitness.");

            Console.WriteLine("Введите имя пользователя: ");
            string name = Console.ReadLine();

            Console.WriteLine("Введите пол");
            string gender = Console.ReadLine();

            Console.WriteLine("Введите дату рождения");
            DateTime birthDate = DateTime.Parse(Console.ReadLine()); //TODO: TryParse

            Console.WriteLine("Введите вес");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите рост");
            double height = double.Parse(Console.ReadLine());

            UserController userController = new UserController(name, gender, birthDate, weight, height);
            userController.Save();
        }
    }
}
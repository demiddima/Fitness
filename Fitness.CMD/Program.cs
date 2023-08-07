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

            UserController userController = new UserController(name);


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
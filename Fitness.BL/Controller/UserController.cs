using Fitness.BL.Model;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Controller user.
    /// </summary>
    public class UserController : ControllerBase
    {
        private const string USERS_FILE_NAME = "users.dat";

        /// <summary>
        /// User application.
        /// </summary>
        public List<User> Users { get; }
        /// <summary>
        /// Current user.
        /// </summary>
        public User CurrentUser { get; }
        /// <summary>
        /// Check new user.
        /// </summary>
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Create new user controller.
        /// </summary>
        /// <param name="userName"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }
        /// <summary>
        /// Set all data for the new user.
        /// </summary>
        /// <param name="genderName">Gender user</param>
        /// <param name="birthdate">Birth date user</param>
        /// <param name="weight">Weight user</param>
        /// <param name="height">Height user</param>
        public void SetNewUserData(string genderName, DateTime birthdate, double weight = 1, double height = 1) //метод, который устанавливаем данные нашего нового пользователя
        {
            // Проверка данных
            //Берётся наш текущий пользователь(после проверки на его существование в списке)
            CurrentUser.Gender = new Gender(genderName); //создаётся гендер, по ранее введённым данным
            CurrentUser.BirthDate = birthdate; // ДР
            CurrentUser.Weight = weight; //Вес
            CurrentUser.Height = height; //Рост
            Save(); //И происходит сериализация
        }

        /// <summary>
        /// Load users data.
        /// </summary>
        private List<User> GetUsersData()
        {
            return Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();
        }
        

        /// <summary>
        /// Save user data. 
        /// </summary>
        public void Save()
        {
            Save(USERS_FILE_NAME, Users);
        }

    }
}

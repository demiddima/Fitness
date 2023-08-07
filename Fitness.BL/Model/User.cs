namespace Fitness.BL.Model
{
    /// <summary>
    /// User. 
    /// </summary>
    [Serializable]
    public class User
    {
        #region Properties
        /// <summary>
        /// Name user.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Gender user.    
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Birth date user.
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Age user.
        /// </summary>
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        /// <summary>
        /// Weight user.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Height user.
        /// </summary>
        public double Height { get; set; }
        #endregion

        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="name">Name user</param>
        /// <param name="gender">Gender user</param>
        /// <param name="birthDate">Birth date user.</param>
        /// <param name="weight">Weight user</param>
        /// <param name="height">Height user</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region CheckInput
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Пол не может быть null", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата рождения", nameof(birthDate));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Вес не может быть меньше или равен нулю", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Рост не может быть меньше или равен нулю", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;

        }
        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="name">Name user</param>
        /// <exception cref="ArgumentNullException"></exception>
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return $"{Name} {Age}";
        }


    }
}

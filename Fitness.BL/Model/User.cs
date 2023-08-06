using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// <summary>
    /// User. 
    /// </summary>
    public class User
    {
        /// <summary>
        /// Name user.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Gender user.    
        /// </summary>
        public Gender Gender { get; }
        /// <summary>
        /// Birth date user.
        /// </summary>
        public DateTime BirthDate { get; }
        /// <summary>
        /// Weight user.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Height user.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="name">Name user</param>
        /// <param name="gender">Gender user</param>
        /// <param name="birthDate">Birth date user.</param>
        /// <param name="weight">Weight user</param>
        /// <param name="height">Height eser</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(name));
            }

            if(gender == null)
            {
                throw new ArgumentNullException("Пол не может быть null", nameof(gender));
            }

            if(birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата рождения", nameof(birthDate));
            }

            if(weight <= 0)
            {
                throw new ArgumentException("Вес не может быть меньше или равен нулю", nameof(weight));
            }

            if(height <= 0)
            {
                throw new ArgumentException("Рост не может быть меньше или равен нулю", nameof(height));
            }

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;

        }
           
        
    }
}

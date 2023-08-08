using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Eating
    /// </summary>
    [Serializable]
    public class Eating
    {
        /// <summary>
        /// Moment of eating
        /// </summary>
        public DateTime Moment { get; }
        /// <summary>
        /// The content of eating
        /// </summary>
        public Dictionary<Food, double> Foods { get; }
        /// <summary>
        /// User
        /// </summary>
        public User User { get; }
        /// <summary>
        /// Create new eating
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }
   
        /// <summary>
        /// Add food to eating
        /// </summary>
        /// <param name="food">Food</param>
        /// <param name="weight">Weiht</param>
        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name)); //Если такой продукт уже есть в списке, то добавляем к нему вес
            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}

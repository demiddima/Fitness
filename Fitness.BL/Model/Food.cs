using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Food.
    /// </summary>
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Name of food.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Protein
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Fats
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Carbohydrate
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Calories per 100 grams of food.
        /// </summary>
        public double Calories { get; }

        /// <summary>
        /// Create new food.
        /// </summary>
        /// <param name="name"></param>
        public Food(string name) : this(name, 0, 0, 0, 0) { }
        /// <summary>
        /// Create new food.
        /// </summary>
        /// <param name="name">Name of food</param>
        /// <param name="calories">Calories per 100 grams of food</param>
        /// <param name="proteins">Protein</param>
        /// <param name="fats">Fats</param>
        /// <param name="carbohydrates">Carbohydrates</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            #region Проверка условий
            //if (string.IsNullOrWhiteSpace(name))
            //{
            //    throw new ArgumentNullException("Имя продукта не может быть пустым", nameof(name));
            //}

            //if(calories <= 0)
            //{
            //    throw new ArgumentException("Калорийность продукта не может быть меньше или равна 0", nameof(calories));
            //}

            //if (proteins <= 0)
            //{
            //    throw new ArgumentException("Количество белков продукта не может быть меньше или равна 0", nameof(proteins));
            //}

            //if (fats <= 0)
            //{
            //    throw new ArgumentException("Количество жиров продукта не может быть меньше или равна 0", nameof(fats));
            //}

            //if (carbohydrates <= 0)
            //{
            //    throw new ArgumentException("Количество углеводов продукта не может быть меньше или равна 0", nameof(carbohydrates));
            //}
            #endregion

            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;

        }

        public override string ToString()
        {
            return Name;
        }
    }
}

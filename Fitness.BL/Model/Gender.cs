using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Gender.
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Name gender.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Create new gender
        /// </summary>
        /// <param name="name">Name gender</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Название пола не может быть пустым или null");
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}

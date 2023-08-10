using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; }
        public double CaloriesPerMinute { get; }

        public Activity(string name, double caloriesPerMinute)
        {
            //TODO: Проверка
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }
        public override string ToString()
        {
           return Name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract2
{
    internal class Shrub : Plant
    {
        public Shrub(Height height, PlantType type, string name)
            : base(height, type, name)
        {
            if (type == PlantType.Rose || type == PlantType.Raspberry || 
                type == PlantType.Currant || type == PlantType.Lilac || type == PlantType.None)
            {
                Type =  type;
            } 
            else
            {
                throw new ArgumentException($"Тип {type} не является кустом!");
            }
        }

        public void Grow(double growAmount)
        {
            if (growAmount <= 0)
                throw new ArgumentException("Для роста куста нужно ввести положительное значение");
            Height = new Height(Height.Meters + growAmount);
            Console.WriteLine($"Куст вырос на {growAmount} м, текущая высота = {Height.Meters}.");
        }
        
        public override string ToString()
        {
            string height = Height.HeightToString();
            return $"{Name}: тип - {Type}, рост  - {height}";
        }
        
    }
}

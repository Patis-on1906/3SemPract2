using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract2
{
    internal class Plant : PlantTypes
    {
        private readonly string _name;
        protected Height _height;
        protected PlantType _type;
        public string Name => _name;
        
        public Height Height
        {
            get => _height;
            set
            {
                if (value.Meters < 0)
                    throw new ArgumentException("Рост должен быть положительным");
                _height = value;
            }
        }
        
        public PlantType Type 
        {   get => _type;
            set
            {
                if (!Enum.IsDefined(typeof(PlantTypes.PlantType), value))
                    throw new ArgumentException("Неверный ввод типа растения");
                _type = value;
            }
        }

        protected Plant()
        {
            Height = new Height(0);
            Type = PlantType.None;
            _name = "Неизвестное дерево";
        }
        
        protected Plant(Height height, PlantType type, string name)
        {
            Height = height;
            Type = type; 
            _name = name;
        }
        
        public void Deconstruct(out Height height, out PlantType type)
        {
            height = Height;
            type = Type;
        }
    }
}

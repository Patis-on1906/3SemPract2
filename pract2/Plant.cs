using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract2
{
    internal class Plant : PlantTypes
    {
        protected Height Height {  get; set; }
        protected TreeType Type {  get; set; }
        
        private readonly string _name;
        protected string Name { get; }

        protected Plant()
        {
            Height = new Height(0);
            Type = TreeType.None;
            _name = "Неизвестное дерево";
        }
        
        protected Plant(Height height, TreeType type, string name)
        {
            Height = height;
            Type = type; 
            _name = name;
        }
        
        public void Deconstruct(out Height height, out TreeType type)
        {
            height = Height;
            type = Type;
        }
    }
}

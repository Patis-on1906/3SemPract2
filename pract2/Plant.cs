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

        public Plant()
        {
            Height = new Height(0);
            Type = TreeType.None;
        }
        
        public Plant(Height height, TreeType type)
        {
            Height = height;
            Type = type;
        }
        
        public void Deconstruct(out Height height, out TreeType type)
        {
            height = Height;
            type = Type;
        }
    }
}

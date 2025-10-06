using System;
using System.Linq.Expressions;

namespace pract2
{
    public class PlantTypes
    {
        public enum PlantType
        {
            // деревья
            Oak, Pine, Birch, Maple,
            
            None,
            
            // кусты
            Rose, Raspberry, Currant, Lilac
        }
        
        public struct Height
        {
            public double Meters { get; }
            
            public Height(double meters)
            {
                if (meters < 0)
                    throw new ArgumentException("Высота не должна быть отрицательной");
                Meters = meters;
            }

            public string HeightToString() => $"{Meters:F2} м";
        }
    }
}
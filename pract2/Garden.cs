using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract2
{
    internal class Garden : IGarden
    {
        private List<Plant> _plants = new List<Plant>();

        public void AddPlant(Plant plant)
        {
            _plants.Add(plant);
        }
        
        public void RemovePlant(Plant plant)
        {
            _plants.Remove(plant);
        }

        public void ShowPlants()
        {
            Console.WriteLine($"Сад содержит {_plants.Count} растений:");
            foreach (var plant in _plants)
            {   
                Console.WriteLine(plant);
            }
        }
        
        public void CutDownTree(Tree tree)
        {
            RemovePlant(tree);
            Console.WriteLine("Дерево срезано.");
        }
    }
}

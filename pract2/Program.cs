using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Garden garden = new Garden();
            Tree currentTree = null;
            Shrub currentShrub = null;

            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?\n1 - добавить в сад дерево/взаимодействовать с деревом\n2 - добавить в сад куст\n" +
                                  "3 - отобразить растения в саду\n4 - завершить работу");

                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    Console.WriteLine("Некорректный ввод, введите число в диапазоне 1-4.");
                    continue;
                }

                try
                {
                    switch (input)
                    {
                        case 1:
                            currentTree = MenuTree(currentTree, garden);
                            break;
                        case 2:
                            currentShrub = MenuShrub(currentShrub);
                            garden.AddPlant(currentShrub);
                            break;
                        case 3:
                            garden.ShowPlants();
                            break;
                        case 4:
                            return;
                    }
                }
                catch 
                {

                }
            }
        }
        
        static (double height, PlantTypes.TreeType type, string name) InputPlantData()
        {
            Console.Write("Введите высоту (в метрах): ");
            double height = double.Parse(Console.ReadLine());
            Console.Write("Выберите тип (0 - Oak, 1 - Pine, 2 - Birch, 3 - Maple): ");
            var type = (PlantTypes.TreeType)int.Parse(Console.ReadLine());
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            
            return (height, type, name);
        }

        static Tree CreateTree()
        {   
            var (height, type, name)  = InputPlantData();
            Console.WriteLine("Введите возраст дерева:");
            double age = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите количество фруктов на дереве:");
            int countFruit = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Здорово ли дерево (да = 0, нет = 1):");
            bool treeSick  = Convert.ToBoolean(Console.ReadLine());
            
            return new Tree(new PlantTypes.Height(height), type, name, age, countFruit, treeSick);
        }

        static Tree MenuTree(Tree currentTree, Garden garden)
        {
            Console.WriteLine("1 — Задать параметры дерева\n2 — Показать свойства дерева\n3 — Собрать урожай\n" +
                              "4 — Позаботиться о дереве\n5 — Потрогать под вдохновляющую музыку\n6 — Вернуться в главное меню\n");
            
            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                Console.WriteLine("Некорректный ввод, введите число в диапазоне 1-6.");
                return currentTree;
            }

            switch (input)
            {
                case 1:
                    currentTree = CreateTree();
                    if (currentTree != null)
                        garden.AddPlant(currentTree);
                    break;
                case 2:
                    if (currentTree == null)
                        Console.WriteLine("Дерево ещё не создано!");
                    else
                        Console.WriteLine(currentTree.ToString());
                    break;
                case 3:
                    Console.WriteLine($"Сколько фруктов вы хотите собрать (сейчас на дереве {currentTree.CountFruit} фруктов):");
                    int amountToHarvest = Convert.ToInt32(Console.ReadLine());
                    amountToHarvest = currentTree.Harvesting(amountToHarvest);
                    Console.WriteLine($"Собрано {amountToHarvest.ToString()} фруктов");
                    break;
                case 4:
                    currentTree.TakeCare();
                    break;
                case 5:
                    currentTree.Touch();
                    break;
                case 6:
                    return currentTree;
            }
            
            return currentTree;
        }

        static Shrub CreateShrub()
        {
            var (height, type, name) = InputPlantData();
            return new Shrub(new PlantTypes.Height(height), type, name);
        }

        static Shrub MenuShrub(Shrub currentShrub)
        {
            Console.WriteLine("1 — Задать параметры куста\n2 — Показать свойства куста\n" +
                              "3 — Вырастить куст\n4 — Вернуться в главное меню");
            
            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                Console.WriteLine("Некорректный ввод, введите число в диапазоне 1–4.");
                return currentShrub;
            }

            switch (input)
            {
                case 1:
                    currentShrub = CreateShrub();
                    break;
                case 2:
                    Console.WriteLine(currentShrub.ToString());
                    break;
                case 3:
                    Console.WriteLine("На сколько вырастить куст в метрах (например, 0.35)");
                    double growAmount = Convert.ToDouble(Console.ReadLine());
                    currentShrub.Grow(growAmount);
                    break;
                case 4:
                    return currentShrub;
            }
            
            return currentShrub;
        }
    }
}

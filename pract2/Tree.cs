using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace pract2
{
    internal class Tree : Plant
    {
        private double _age;
        private int _countFruit;
        bool TreeSick {  get; set; }

        public double Age
        {
            get { return _age; }
            set
            {
                if (value < 0)
                    throw new  ArgumentException("Возраст должен быть положительным");
                _age =  value; 
            }
        }
        
        public int CountFruit
        {
            get { return _countFruit; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Количество фруктов должно быть положительным");
                _countFruit = value;
            }
        }

        public Tree(double age, int countFruit, bool treeSick)
        {
            Age = age;
            CountFruit = countFruit;
            TreeSick = treeSick;
        }
        
        public int Harvesting(int amountToHarvest)
        {   
            if (amountToHarvest <= 0)
                throw new ArgumentException("Количество для сбора должно быть положительным");
            
            if (TreeSick)
            {
                Console.WriteLine("Дерево болеет, урожай испорчен");
                return 0;
            }
            
            if (_countFruit < amountToHarvest)
                throw new InvalidOperationException("Недостаточно фруктов для сбора");
            
            _countFruit -= amountToHarvest;
            return amountToHarvest;
        }

        public void TakeCare()
        {
            var rand = new Random();
            if (TreeSick)
            {
                Console.WriteLine("Вы попытались вылечить дерево...");
                if (rand.Next(0, 2) == 0)
                {
                    TreeSick = false;
                    Console.WriteLine("Дерево выздоровело!");
                }
                else
                {
                    Console.WriteLine("Дерево ещё больное.");
                }
            }

            _countFruit += rand.Next(5, 15);
            Console.WriteLine($"Теперь на дереве {_countFruit} фруктов.");
        }

        public void Touch()
        {
            var rand =  new Random();
            Console.WriteLine("Вы трогаете дерево под вдохновляющую музыку...");
            
            int effects =  rand.Next(0, 3);
            switch (effects)
            {
                case 0:
                    _countFruit += 5;
                    Console.WriteLine("Дерево расцвело! Появились новые фрукты.");
                    break;
                case 1:
                    TreeSick = false;
                    Console.WriteLine("Дерево исцелилось!");
                    break;
                case 2:
                    Console.WriteLine("Дерево шелестит листвой!");
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01War
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Soldier> list = new List<Soldier>();
            List<Soldier> neededSoldiers = new List<Soldier>();
            List<int> result = new List<int>();

            int c = int.Parse(input);

            input = MainLogic(list);

            list.Sort();

            Console.WriteLine($"For \"C\" = {c}");

            foreach (var e in list)
            {
                if (c >= e.WFood)
                {
                    neededSoldiers.Add(new Soldier() { SoldierIndex = e.SoldierIndex, MLoad = e.MLoad, WFood = e.WFood });
                    c = c - e.WFood;
                }
            }

            neededSoldiers.Sort();
            neededSoldiers.Reverse();

            result = Result(neededSoldiers);
            Console.WriteLine($"Mmax = {Mmax(neededSoldiers)}");
            Console.Write($"Our best soldier is: ");
            Console.WriteLine(string.Join(", ", result));
        }

        private static string MainLogic(List<Soldier> list)
        {
            string input;
            int soldier = 1;
            while ((input = Console.ReadLine()) != "0")
            {
                int[] inputParams = input.Split(new char[] { ',', ' ' }).Select(int.Parse).ToArray();

                list.Add(new Soldier() { SoldierIndex = soldier, WFood = inputParams[0], MLoad = inputParams[1] });

                //input = Console.ReadLine();
                soldier++;
            }

            return input;
        }

        private static List<int> Result(List<Soldier> neededSoldiers)
        {
            List<int> soldiers = new List<int>();

            foreach (var element in neededSoldiers)
            {
                soldiers.Add(element.SoldierIndex);
            }

            return soldiers;
        }

        private static int Mmax(List<Soldier> result)
        {
            int Mmax = 0;
            foreach (var element in result)
            {
                Mmax += element.MLoad;
            }

            return Mmax;
        }
    }
}

using System;

namespace BullsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите 4-х значное целое число: ");
            string strRaw = Console.ReadLine();
            string str = strRaw.Replace(" ", "");
            bool checkLenght = str.Length == 4;
            ushort num;
            bool checkNum = UInt16.TryParse(str, out num);
            Console.WriteLine("Проверка на длину - {0}", checkLenght);
            Console.WriteLine("Проверка на число - {0}", checkNum);
            Console.WriteLine("Число = {0}", num);
        }
    }
}

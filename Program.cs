using System;

namespace BullsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите 4-х значное целое число из разных цифр: ");
            string strRaw = Console.ReadLine();

            string str = strRaw.Replace(" ", "");
            bool checkLenght = str.Length == 4;

            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[i] == str[j])
                    {
                        count++;
                    }
                }
            }
            bool checkUniq = count == str.Length;

            uint num;
            bool checkNum = UInt32.TryParse(str, out num);

            Console.WriteLine("Проверка на длину - {0}", checkLenght);
            Console.WriteLine("Проверка на число - {0}", checkNum);
            Console.WriteLine("Проверка на уникальность - {0}", checkUniq);
            Console.WriteLine("Строка = {0}", str);
            Console.WriteLine("Число = {0}", num);
        }
    }
}

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

            bool checkUniq = true;
            for (int i = 0; i < str.Length - 2; i++)
            {
                for (int j = 1; j < str.Length - i; j++) // Epic fail
                {
                    if (str[i] == str[j])
                    {
                        checkUniq = false;
                    }
                }
            }
            
            ushort num;
            bool checkNum = UInt16.TryParse(str, out num);

            Console.WriteLine("Проверка на длину - {0}", checkLenght);
            Console.WriteLine("Проверка на число - {0}", checkNum);
            Console.WriteLine("Проверка на уникальность - {0}", checkUniq);
            Console.WriteLine("Строка = {0}", str);
            Console.WriteLine("Число = {0}", num);
        }
    }
}

using System;

namespace BullsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите 4-х значное целое число из разных цифр: ");
            string s = Console.ReadLine();
            CheckString(s);
            while (CheckString(s) == false)
            {
                Console.WriteLine("Неверный ввод данных!");
                Console.Write("Введите 4-х значное целое число из разных цифр: ");
                s = Console.ReadLine();
                CheckString(s);
            }
            
            Console.WriteLine("\nДля продолжения нажмите любую клавишу . . .");
            Console.ReadKey();
        }

        static bool CheckString(string rawStr)
        {
            string str = rawStr.Replace(" ", "");
            bool checkLenght = str.Length == 4;
            uint num;
            bool checkNum = UInt32.TryParse(str, out num);
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
            if (checkLenght == false | checkNum == false | checkUniq == false)
            {
                return false;
            }
            return true;
        }
    }
}

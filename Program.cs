using System;

namespace BullsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("Введите 4-х значное целое число из разных цифр: ");
                string s = Console.ReadLine();
                bool check = CheckString(s);
            } while (check == true);
            
            Console.WriteLine("\nДля продолжения нажмите любую клавишу . . .");
            Console.ReadKey();
        }

        static bool CheckString(string raw)
        {
            string str = raw.Replace(" ", "");
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
                Console.WriteLine("Неверный ввод данных!");
                return false;
            }
            return true;
        }
    }
}

using System;

namespace BullsAndCows //Быки и коровы
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите 4-х значное целое число из разных цифр: ");
            string s = Console.ReadLine();
            while (CheckString(s) == false) //Повторять, пока не будет введено верное значение
            {
                Console.WriteLine("Неверный ввод данных!");
                Console.Write("Введите 4-х значное целое число из разных цифр: ");
                s = Console.ReadLine();
            }

            Console.WriteLine("\nДля продолжения нажмите любую клавишу . . .");
            Console.ReadKey();
        }
        
        static bool CheckString(string rawStr) //Блок проверки числа
        {
            string str = rawStr.Replace(" ", ""); //Удаление пробелов
            
            bool checkLenght = str.Length == 4; //Проверка на длину
            if (checkLenght == false)
            {
                return false;
            }
            
            uint num; //Проверка на число
            bool checkNum = UInt32.TryParse(str, out num);
            if (checkNum == false)
            {
                return false;
            }
            
            int count = 0; //Проверка цифр на уникальность
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
            if (checkUniq == false)
            {
                return false;
            }

            return true;
        }
    }
}

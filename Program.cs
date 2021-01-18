using System;

namespace BullsAndCows //Быки и коровы
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите 4-х значное целое число из разных цифр: ");
            string s = Console.ReadLine();
            CheckString(s);
            while (CheckString(s) == false) //Повторять запрос числа, пока не будет введено верное значение
            {
                Console.WriteLine("Неверный ввод данных!");
                Console.Write("Введите 4-х значное целое число из разных цифр: ");
                s = Console.ReadLine();
                CheckString(s);
            }
            
            Console.WriteLine("\nДля продолжения нажмите любую клавишу . . .");
            Console.ReadKey(); //Выход из программы
        }
	
        static bool CheckString(string rawStr) //Блок проверки числа
        {
            string str = rawStr.Replace(" ", ""); //Удаление пробелов
            bool checkLenght = str.Length == 4; //Проверка на длину
            uint num;
            bool checkNum = UInt32.TryParse(str, out num); //Проверка на число
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
            bool checkUniq = count == str.Length; //Проверка цифр на уникальность
            if (checkLenght == false || checkNum == false || checkUniq == false)
            {
                return false;
            }
            return true;
        }
    }
}

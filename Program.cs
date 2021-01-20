using System;

namespace BullsAndCows //Быки и коровы
{
    class Program
    {
        static void Main(string[] args)
        {
            string question = "";

            do //Повторять, пока не будет сгенерировано верное значение
            {
                string[] array = new string[4];

                for (int i = 0; i < 4; i++)
                {
                    Random rnd = new Random();
                    int value = rnd.Next(0, 9);
                    string s = value.ToString();
                    array[i] = s;
                }

                question = String.Join("", array);
                Console.WriteLine(question);

            } while (CheckString(question) == false);

            Console.WriteLine("Компьютер загадал число!");
            Console.WriteLine("\nНайди число, задуманное компьютером!");
            string answer = Console.ReadLine();

            while (CheckString(answer) == false) //Повторять, пока не будет введено верное значение
            {
                Console.WriteLine("Неверный ввод данных!");
                Console.WriteLine("Нужны 4 не повторяющиеся цифры!");
                answer = Console.ReadLine();
            }

            Console.WriteLine("\nДля продолжения нажми любую клавишу . . .");
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

using System;

namespace BullsAndCows //Быки и коровы
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Игра \"Быки и коровы\"\n");
            Console.WriteLine("Компьютер загадывает число, ты угадываешь. Всё просто!\n");
            Console.WriteLine("Нажми <F1> для справки или любую клавишу для продолжения . . .\n");

            if (Console.ReadKey().Key == ConsoleKey.F1)
            {
                Console.WriteLine("Правила игры");
                Console.WriteLine("\nДля продолжения нажми любую клавишу . . .");
                Console.ReadKey();
            }

            string question = "";

            do //Генератор последовательности случайных чисел
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

            Console.WriteLine("Найди число, задуманное компьютером!");

            string answer = Console.ReadLine();

            while (CheckString(answer) == false) //Повторять ввод, пока не будет получено верное значение
            {
                Console.WriteLine("Неверный ввод данных!");
                Console.WriteLine("Нужны 4 не повторяющиеся цифры!");
                answer = Console.ReadLine();
            }

            if (question == answer)
            {
                Console.WriteLine("Угадал с первой попытки!!! Да ты экстрасенс!!!");
            }

            Console.WriteLine("\nДля продолжения нажми любую клавишу . . .");
            Console.ReadKey();
        }
        
        static bool CheckString(string rawStr) //Блок проверки последовательности чисел
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

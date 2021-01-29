using System;

namespace BullsAndCows //Быки и коровы
{
    class Program
    {
        static void Main(string[] args)
        {

            // Приветствие
            Console.WriteLine("Игра \"Быки и коровы\"\n");
            Console.WriteLine("Компьютер задумывает число, ты угадываешь его. Всё просто!\n");
            Console.WriteLine("Нажми <F1> для справки или любую клавишу для продолжения . . .\n");

            // Правила игры
            if (Console.ReadKey(true).Key == ConsoleKey.F1)
            {
                Console.WriteLine(" *Правила игры*\n");
                Console.WriteLine("Компьютер задумывает четыре различные цифры из 0, 1, 2, ... 9.");
                Console.WriteLine("Игрок делает ходы, чтобы узнать эти цифры и их порядок.");
                Console.WriteLine("Каждый ход состоит из четырёх цифр, 0 может стоять на первом месте.");
                Console.WriteLine("В ответ компьютер показывает число отгаданных цифр,");
                Console.WriteLine("стоящих на своих местах (число быков) и число отгаданных цифр,");
                Console.WriteLine("стоящих не на своих местах (число коров).\n");
                Console.WriteLine(" *Пример*\n");
                Console.WriteLine("Компьютер задумал 0834.\n");
                Console.WriteLine("Игрок сделал ход 8134.\n");
                Console.WriteLine("Компьютер ответил: 2 быка (цифры 3 и 4) и 1 корова (цифра 8).\n");
                Console.WriteLine("Для продолжения нажми любую клавишу . . .\n");
                Console.ReadKey(true);
            }

            // Начало игры
            while (true)
            {
                // Компьютер генерирует число
                string question;
                do
                {
                    Random rnd = new Random();
                    int value = rnd.Next(123, 9999);
                    if (value < 1000)
                    {
                        question = "0" + value.ToString();
                    }
                    else
                    {
                        question = value.ToString();
                    }

                } while (CheckString(question) == false);

                Console.WriteLine("Найди число, задуманное компьютером!\n");

                // Пользователь делает ход
                string answer;
                int step = 1;
                do
                {
                    Console.WriteLine("Номер хода {0}\n", step);
                    answer = Console.ReadLine().Replace(" ", "");
                    while (CheckString(answer) == false)
                    {
                        Console.WriteLine("\nНеверный ввод данных!");
                        Console.WriteLine("Нужны 4 не повторяющиеся цифры!\n");
                        answer = Console.ReadLine().Replace(" ", "");
                    }

                    // Пользователь - телепат!
                    if (question == answer && step == 1)
                    {
                        Console.WriteLine("\nУгадал с первой попытки!!! Да ты телепат?!!");
                    }

                    // Победа
                    if (question == answer && step > 1)
                    {
                        Console.WriteLine("\nПоздравляю!!! Ты угадал число!!!");
                    }

                    // Вывод результатов
                    if (question != answer)
                    {
                        Console.WriteLine("\nКоличество быков {0}", BullsCount(question, answer));
                        Console.WriteLine("Количество коров {0}\n", CowsCount(question, answer));
                    }

                    step++;

                } while (question != answer);

                // Выход
                Console.WriteLine("\nНажми <Esc> для выхода или любую клавишу для продолжения . . .\n");
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    return;
                }
            }
        }

        // Блок подсчёта быков
        static int BullsCount(string str1, string str2)
        {
            int bulls = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] == str2[i])
                {
                    bulls++;
                }
            }

            return bulls;
        }

        // Блок подсчёта коров
        static int CowsCount(string str1, string str2)
        {
            int count = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                for (int j = 0; j < str1.Length; j++)
                {
                    if (str1[i] == str2[j])
                    {
                        count++;
                    }
                }
            }

            int cows = count - BullsCount(str1, str2);
            return cows;
        }

        // Блок проверки последовательности чисел
        static bool CheckString(string str)
        {
            // Проверка на длину
            bool checkLenght = str.Length == 4;
            if (checkLenght == false)
            {
                return false;
            }

            // Проверка на число
            bool checkNum = UInt32.TryParse(str, out _);
            if (checkNum == false)
            {
                return false;
            }

            // Проверка цифр на уникальность
            for (int i = 0; i < str.Length - 1; i++)
            {
                for (int j = i + 1; j < str.Length; j++)
                {
                    if (str[i] == str[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

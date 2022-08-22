using Homework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Включение Кириллицы в консоли
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            bool runProgram = true;

            while (runProgram)
            {
                Console.WriteLine("=====================================================");
                Console.WriteLine("1 -> Задача 1");
                Console.WriteLine("2 -> Задача 2");
                Console.WriteLine("0 -> Выход");
                Console.WriteLine("=====================================================");

                int taskNumber;

                // Если пользователь неправильно ввёл номер задачи, то taskNumber будет равным -1, и в блоке switch
                // программа сообщит об этом пользователю
                if (!int.TryParse(CommonMethods.AskInfo("Введите номер задачи: "), out taskNumber))
                {
                    taskNumber = -1;
                }

                switch (taskNumber)
                {
                    default:
                        Console.WriteLine("Некорректый номер задачи. Повторие ввод.\n");
                        break;

                    case 0:
                        runProgram = false;
                        break;

                    case 1:
                        Task1();
                        break;

                    case 2:
                        Task2();
                        break;
                }
            }

            CommonMethods.Pause("\nНажмите любую клавишу, чтобы выйти...");
        }

        #region Методы для вызова задачь из домашней работы

        static void Task1()
        {
            CommonMethods.PrintTaskInfo(
                5, 
                1,
                "Создать программу, которая будет проверять корректность ввода логина.\n" +
                "Корректным логином будет строка от 2 до 10 символов, содержащая только\n" +
                "буквы латинского алфавита или цифры, при этом цифра не может быть первой.", 
                "Грачёв Виктор Алексеевич"
            );

            string alphabet =
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "abcdefghijklmnopqrstuvwxyz" +
                "0123456789";

            string login = CommonMethods.AskInfo("Введите логин: ");


            bool isLoginCorrect = false;

            if (login.Length >= 2 &&
                login.Length <= 10 &&
                !Char.IsDigit(login[0]) &&
                isAlphabetOnly(login, alphabet)
            )
                isLoginCorrect = true;


            if (isLoginCorrect)
                Console.WriteLine("Логин введён корректно");
            else
                Console.WriteLine("Логин введён некорректно");

            CommonMethods.Pause("\nНажмие любую клавишу, чтобы выйти...");
        }

        static void Task2()
        {
            CommonMethods.PrintTaskInfo(
                5,
                2,
                "Разработать статический класс Message, содержащий следующие статические методы для обработки текста:\n" +
                "а) Вывести только те слова сообщения, которые содержат не более n букв.\n" +
                "б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.\n" +
                "в) Найти самое длинное слово сообщения.\n" +
                "г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.\n" +
                "д) ***Создать метод, который производит частотный анализ текста.\n" +
                "В качестве параметра в него передается массив слов и текст,\n" +
                "в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст.\n" +
                "Здесь требуется использовать класс Dictionary.",
                "Грачёв Виктор Алексеевич"
            );


            string text = CommonMethods.AskInfo("Введите текст, с которым вы будете работать: ");
            TextOperation(text);


            CommonMethods.Pause("\nНажмие любую клавишу, чтобы выйти...");
        }

        #endregion

        #region Вспомогательные методы

        /// <summary>
        /// Получает на вход две строки и проверяет, состоит ли первая строка только из символов, которые есть во второй
        /// </summary>
        static bool isAlphabetOnly(string str, string alphabet)
        { 
            bool isAlphabetOnly = true;

            for (int i = 0; i < str.Length; i++)
            {
                if (!alphabet.Contains(str[i]))
                {
                    isAlphabetOnly = false;
                    break;
                }
            }

            return isAlphabetOnly;
        }

        /// <summary>
        /// Спрашивает у пользователя, что нужно сделать с текстом и вызывает соответствущие методы для его обработки
        /// </summary>
        static void TextOperation(string text)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("1 -> а) Вывести только те слова сообщения, которые содержат не более n букв");
                Console.WriteLine("2 -> б) Удалить из сообщения все слова, которые заканчиваются на заданный символ");
                Console.WriteLine("3 -> в) Найти самое длинное слово сообщения");
                Console.WriteLine("4 -> г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения");
                Console.WriteLine("5 -> д) Найти частоту появления разных слов в тексте");
                Console.WriteLine();

                int chooseNumber;
           
                if (!int.TryParse(CommonMethods.AskInfo("Введите номер: "), out chooseNumber))
                {
                    chooseNumber = -1;
                }

                switch (chooseNumber)
                {
                    default:
                        Console.WriteLine("Некорректый номер. Повторие ввод.\n");
                        break;

                    case 1:
                        Subtask1(text);
                        exit = true;
                        break;

                    case 2:
                        Subtask2(text);
                        exit = true;
                        break;

                    case 3:
                        Console.WriteLine($"Самое длинное слово: {Message.getLongestWord(text)}");
                        exit = true;
                        break;

                    case 4:
                        Subtask4(text);
                        exit = true;
                        break;

                    case 5:
                        Subtask5(text);
                        exit = true;
                        break;
                }
            }
        }

        #region подзадачи для второй задачи

        static void Subtask1(string text)
        {
            int n = CommonMethods.AskInfoInt("\nВведите максимальное количество букв в слове: ");
            Console.WriteLine($"\n{Message.GetWordsFromStringMax(text, n)}");
        }

        static void Subtask2(string text)
        {
            char c = CommonMethods.AskInfoChar("\nВведите символ: ");
            Console.WriteLine($"\n{Message.DeleteWords(text, c)}");
        }

        static void Subtask4(string text)
        {
            int n = CommonMethods.AskInfoInt("\nВведите количество букв, начиная с которого слово будет считаться длинным: ");
            Console.WriteLine($"\n{Message.GetWordsFromStringMin(text, n)}");
        }

        static void Subtask5(string text)
        {
            int n = CommonMethods.AskInfoInt("\nВведите количество слов: ");
            string[] words = new string[n];

            for (int i = 0; i < n; i++)
            {
                words[i] = CommonMethods.AskInfo("Введите слово: ");
            }

            Console.WriteLine();

            Dictionary<string, int> analazedWords = Message.AnalyzeText(words, text);
            foreach (var wordData in analazedWords)
            {
                Console.WriteLine($"{wordData.Key}: {wordData.Value}");
            }
        }

        #endregion


        #endregion

    }
}

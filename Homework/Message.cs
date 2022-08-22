using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public static class Message
    {
        private static string[] separators = { " ", ",", ".", ":", ";", "?", "!" };

        /// <summary>
        /// Получет на вход строку, делит её на слова и возвращает строку, состоящую из слов, длина которых меньше либо равна max
        /// </summary>
        public static string GetWordsFromStringMax(string message, int max)
        {
            if (string.IsNullOrEmpty(message))
                return null;

            StringBuilder stringBuilder = new StringBuilder();
            string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (word.Length <= max)
                    stringBuilder.Append($"{word}\n");
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Получет на вход строку, делит её на слова и возвращает строку, состоящую из слов, длина которых больше либо равна min
        /// </summary>
        public static string GetWordsFromStringMin(string message, int min)
        {
            if (string.IsNullOrEmpty(message))
                return null;

            StringBuilder stringBuilder = new StringBuilder();
            string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (word.Length >= min)
                    stringBuilder.Append($"{word} ");
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Получает на вход строку и символ, после чего удаляет все слова из строки, которые заканчиваются на этот символ
        /// </summary>
        public static string DeleteWords(string message, char endChar)
        {
            if (string.IsNullOrEmpty(message))
                return null;

            string newString = "";

            string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (word[word.Length - 1] != endChar)
                    newString += word + " ";
            }

            return newString;
        }

        /// <summary>
        /// Получает на вход строку, делит её на слова, и возвращает самое длинное слово
        /// </summary>
        public static string getLongestWord(string message)
        {
            if (string.IsNullOrEmpty(message))
                return null;


            string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string longestWord = words[0];

            foreach (string word in words)
            {
                if (word.Length > longestWord.Length)
                    longestWord = word;
            }

            return longestWord;
        }

        /// <summary>
        /// Метод, который производит частотный анализ текста.
        /// В качестве параметра в него передается массив слов и текст,
        /// в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст.
        /// </summary>
        public static Dictionary<string, int> AnalyzeText(string[] words, string message)
        {
            Dictionary<string, int> analysis = new Dictionary<string, int>();

            string[] wordsFromText = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                int count = 0;

                for (int j = 0; j < wordsFromText.Length; j++)
                {
                    if (words[i] == wordsFromText[j])
                        count++;
                }

                analysis.Add(words[i], count);
            }

            return analysis;
        }
    }
}

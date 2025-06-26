using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.VisualBasic;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            //Word List
            string[] words = { "apple", "pencil", "program", "device", "book", "study", "university" };
            Random rnd = new Random();
            string selectedWord = words[rnd.Next(words.Length)].ToLower();

            //variables
            char[] guessedLetters = new string('_', selectedWord.Length).ToCharArray();
            List<char> wrongGuesses = new List<char>();
            int remainingTries = 6;

            //Game loop
            while (remainingTries > 0 && new string(guessedLetters) != selectedWord)
            {
                Console.Clear();
                Console.WriteLine("---HANGMAN---");
                Console.WriteLine("Word: " + new string(guessedLetters));
                Console.WriteLine("Wrong Letters: " + string.Join(",", wrongGuesses));
                Console.WriteLine($"Lives: {remainingTries}");
                Console.Write("Guess a Letter: ");

                string input = Console.ReadLine().ToLower();

                //Input Kontrol
                if (string.IsNullOrWhiteSpace(input) || input.Length != 1 || !char.IsLetter(input[0]))
                {
                    Console.WriteLine("Please enter one letter!");
                    Console.ReadKey();
                    continue;
                }

                char guess = input[0];

                //Entered before?
                if (new string(guessedLetters).Contains(guess) || wrongGuesses.Contains(guess))
                {
                    Console.WriteLine("You entered this letter before!");
                    Console.ReadKey();
                    continue;
                }

                //Correct guess?
                if (selectedWord.Contains(guess))
                {
                    for (int i = 0; i < selectedWord.Length; i++)
                    {
                        if (selectedWord[i] == guess)
                        {
                            guessedLetters[i] = guess;
                        }
                    }
                }
                else
                {
                    wrongGuesses.Add(guess);
                    remainingTries--;
                }
            }

            //Game Result
            Console.Clear();
            if (new string(guessedLetters) == selectedWord)
            {
                Console.WriteLine("Congratulations! The word is correct!");
            }
            else
            {
                Console.WriteLine("Please Enter if you want to play again!");
                Console.ReadLine();
            }

        }
    }
}

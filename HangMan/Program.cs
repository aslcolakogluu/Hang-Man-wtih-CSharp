using System;
using System.Collections.Generic;


namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                
                string[] words = { "apple", "pencil", "program", "device", "book", "study", "university" };
                Random rnd = new Random();
                string selectedWord = words[rnd.Next(words.Length)].ToLower();

                
                char[] guessedLetters = new string('_', selectedWord.Length).ToCharArray();
                List<char> wrongGuesses = new List<char>();
                int remainingTries = 3;

                
                while (remainingTries > 0 && new string(guessedLetters) != selectedWord)
                {
                    Console.Clear();
                    Console.WriteLine("---HANGMAN---");
                    Console.WriteLine("Word: " + new string(guessedLetters));
                    Console.WriteLine("Wrong Letters: " + string.Join(",", wrongGuesses));
                    Console.WriteLine($"Lives: {remainingTries}");
                    Console.Write("Guess a Letter: ");

                    string input = Console.ReadLine().ToLower();

                    
                    if (string.IsNullOrWhiteSpace(input) || input.Length != 1 || !char.IsLetter(input[0]))
                    {
                        Console.WriteLine("Please enter one letter!");
                        Console.ReadKey();
                        continue;
                    }

                    char guess = input[0];

                    
                    if (new string(guessedLetters).Contains(guess) || wrongGuesses.Contains(guess))
                    {
                        Console.WriteLine("You entered this letter before!");
                        Console.ReadKey();
                        continue;
                    }

                    
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

                
                Console.Clear();
                if (new string(guessedLetters) == selectedWord)
                {
                    Console.WriteLine("Congratulations! The word is correct!");
                }
                else
                {
                    Console.WriteLine("You lost! True word" + selectedWord);

                }

                
                Console.WriteLine("\nPlay again? (y/n): ");
                string again = Console.ReadLine().ToLower();
                if (again != "y")
                {
                    break;
                }
            }

            Console.WriteLine("Thanks for playing!!!");
        }
    }
}


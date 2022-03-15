using System;
using DictionaryLibrary;

namespace VucabularyConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Wordstrainy!\n");
            string choices = "Use any of the following functions: \n" +
                 "-lists\n" +
                 "-new < list name > < language 1 > < language 2 > .. < langauge n >\n" +
                 "-add < list name >\n" +
                 "-remove < list name > < language > < word 1 > < word 2 > .. < word n >\n" +
                 "-words<listname> < sortByLanguage >\n" +
                 "-count < listname >\n" +
                 "-practice < listname >\n" +
                 "-deletelist < listname >\n";

            if (args.Length == 0)
            {
                Console.WriteLine(choices);
            }
            else if (args[0] == "-lists")
            {
                PrintLists();
            }
            else if (args[0] == "-new")
            {
                AddNewWordlist();
            }
            else if (args[0] == "-add")
            {
                AddWords(FirstLetterToUpper(args[1]));
            }
            else if (args[0] == "-remove")
            {
                DeleteWord();
            }
            else if (args[0] == "-words")
            {
                PrintWords();
            }
            else if (args[0] == "-count")
            {
                CountWords();
            }
            else if (args[0] == "-practice")
            {
                PracticeWords();
            }
            else if (args[0] == "-deletelist")
            {
                DeleteWordlist();
            }
            else
            {
                Console.WriteLine(choices);
            }


            void AddWords(string name)
            {
                bool continuing = true;
                int insetWords = 0;

                Console.WriteLine("\nHere, you may add words to your chosen list\n" +
                    "To stop the input, press enter on an empty line!\n");

                var wordList = WordList.LoadList(name);
                if (wordList != null)
                {
                    while (continuing)
                    {
                        var wordArray = new string[wordList.Languages.Length];

                        for (int i = 0; i < wordArray.Length; i++)
                        {
                            Console.Write($"Write the {wordList.Languages[i]} word or transltaion: ");
                            var words = Console.ReadLine();

                            wordArray[i] = words.ToLower();
                            if (string.IsNullOrEmpty(words))
                            {
                                continuing = false;
                                wordList.Save();
                                Console.WriteLine($"\n{insetWords} words have been added to word list '{name}'");
                                break;
                            }
                        }
                        Console.WriteLine();
                        wordList.Add(wordArray);
                        insetWords++;
                    }
                }
                else
                {
                    Console.WriteLine($"There is no wordlist with the given name!");
                }
            }

            int GetLanguageIndex(WordList wordlist)
            {
                var languageIndex = 0;

                if (args.Length > 2)
                {
                    for (int i = 0; i < wordlist.Languages.Length; i++)
                    {
                        if (FirstLetterToUpper(wordlist.Languages[i]) == FirstLetterToUpper(args[2]))
                        {
                            languageIndex = i;
                            return languageIndex;
                        }
                    }
                }
                return 0;
            }

            void PrintLists()
            {
                Console.WriteLine("Here are all the lists storaged in the database:\n");
                var lists = WordList.GetLists();
                foreach (var item in lists) Console.WriteLine(item);
                Console.WriteLine();
            }

            void AddNewWordlist()
            {
                var languages = new string[args.Length - 2];
                for (int i = 2; i < args.Length; i++)
                {
                    languages[i - 2] = FirstLetterToUpper(args[i]);
                }
                WordList newList = new WordList(FirstLetterToUpper(args[1]), languages);
                bool addNewList = true;
                var existedLists = WordList.GetLists();
                foreach (var item in existedLists)
                {
                    if (item == FirstLetterToUpper(args[1]))
                    {
                        Console.WriteLine($"A List with the same name is already existes\n" +
                            "If you want to replace it with an empty new one, enter Y else N to cancel");
                        string answer = Console.ReadLine();
                        if (answer.ToUpper() == "Y")
                        {
                            newList.Save();
                            Console.WriteLine($"\nYour old {FirstLetterToUpper(args[1])} list has been replaced with a new one");
                            AddWords(FirstLetterToUpper(args[1]));
                            addNewList = false;
                        }
                        else if (answer.ToUpper() == "N")
                        {
                            Console.WriteLine($"\nYour old {FirstLetterToUpper(args[1])} list has been spared\n");
                            addNewList = false;
                        }
                    }
                }
                if (addNewList)
                {
                    newList.Save();
                    Console.WriteLine($"\nA new list {FirstLetterToUpper(args[1])} is been added and saved\n");
                    AddWords(FirstLetterToUpper(args[1]));
                }
            }

            void DeleteWord()
            {
                var WordsToBeRemoved = WordList.LoadList(FirstLetterToUpper(args[1]));
                if (WordsToBeRemoved != null)
                {
                    for (int i = 3; i < args.Length; i++)
                    {
                        var check = WordsToBeRemoved.Remove(GetLanguageIndex(WordsToBeRemoved), args[i].ToLower());
                        if (check) Console.WriteLine($"The word '{args[i]}' has been found and successfully deleted");
                        else Console.WriteLine($"The word '{args[i]}' was not found in this wordlist");
                    }
                    WordsToBeRemoved.Save();
                }
                Console.WriteLine();
            }

            void PrintWords()
            {
                var wordList = WordList.LoadList(FirstLetterToUpper(args[1]));
                if (wordList != null)
                {
                    foreach (var item in wordList.Languages)
                    {
                        Console.Write(FirstLetterToUpper(item.PadRight(20)));
                    }

                    Console.WriteLine();

                    wordList.List(GetLanguageIndex(wordList), w =>
                    {
                        Console.WriteLine();
                        foreach (var item in w)
                        {
                            Console.Write(FirstLetterToUpper(item.PadRight(20)));
                        }
                    });
                    Console.WriteLine("\n");
                }
            }

            void CountWords()
            {
                var countedList = WordList.LoadList(FirstLetterToUpper(args[1]));
                if (countedList != null)
                {
                    Console.WriteLine($"The list {countedList.Name} conatins {countedList.Count()} Words\n");
                }
            }

            void PracticeWords()
            {
                var continuing = true;
                var correctAnswers = 0f;
                var answerTry = 0f;
                var practiceWordList = WordList.LoadList(FirstLetterToUpper(args[1]));
                if (practiceWordList != null)
                {

                    Console.WriteLine($"Here is a good vucabulary training\n"
                        + "To stop practicing, press enter on an empty line!\n");
                    while (continuing)
                    {
                        var training = practiceWordList.GetWordToPractice();
                        var fromLanguage = practiceWordList.Languages[training.FromLanguage];
                        var toLanguage = practiceWordList.Languages[training.ToLanguage];
                        var fromTranslation = training.Translations[training.FromLanguage];
                        var toTranslation = training.Translations[training.ToLanguage];

                        Console.Write($"Type the {toLanguage} Translate of the {fromLanguage} word '{fromTranslation}': ");
                        var input = Console.ReadLine();


                        if (string.IsNullOrEmpty(input))
                        {
                            continuing = false;
                            float accuracy = correctAnswers / answerTry;
                            Console.WriteLine($"\n<<You have got {correctAnswers} correct answers out of {answerTry}>>");
                            Console.WriteLine($"Accuracy rate: {accuracy:p1}\n");
                            break;
                        }

                        if (FirstLetterToUpper(input) == FirstLetterToUpper(toTranslation))
                        {
                            Console.WriteLine("\nRight! Your answer is correct!\n");
                            correctAnswers++;
                        }
                        else
                        {
                            Console.WriteLine("\nWrong, focus friend!\n");
                        }
                        answerTry++;
                    }
                }
            }

            void DeleteWordlist()
            {
                var deletedList = WordList.DeleteList(FirstLetterToUpper(args[1]));
                if (deletedList != null)
                {
                    Console.WriteLine($"{FirstLetterToUpper(args[1])} has been found and successfully deleted\n");
                }
                else
                {
                    Console.WriteLine($"{FirstLetterToUpper(args[1])} can not be found amoung your lists\n");
                }
            }
        }
        private static string FirstLetterToUpper(string text)
        {
            return text.Substring(0,1).ToUpper() + text.Substring(1);
        }
    }
}
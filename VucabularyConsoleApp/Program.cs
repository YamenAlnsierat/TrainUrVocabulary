using System;
using DictionaryLibrary;

namespace VucabularyConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //WordList.LoadList("mylist");
            WordList myList = new WordList("mylist", "en", "sv");
            WordList yourList = new WordList("yourList", "en", "sv");
            myList.Save();
            yourList.Save();
            //yourList.Add("Dog", "Hund");


            //WordList.LoadList("yourList").Add("Cat", "Katt");
            //WordList.LoadList("mylist").Add("Horse", "Häst");
            WordList.LoadList("yourList").Add("Dog", "Hund");

            var lists = WordList.GetLists();
            foreach (var list in lists)
            {
                Console.WriteLine(list);
            }



            Console.WriteLine(WordList.LoadList("mylist").Count());
            Console.WriteLine(WordList.LoadList("yourList").Count());

            WordList.LoadList("yourList").Remove(0, "Dog");

            Console.WriteLine(WordList.LoadList("yourList").Count());

        }
    }
}

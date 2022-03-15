using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryLibrary
{
    public class WordList
    {
        private WordListModel wordListModel = new WordListModel();

        public string Name => wordListModel.Name;  //Namnet på listan.
        public string[] Languages => wordListModel.Languages;  //Namnen på språken.



        public WordList(string name, params string[] languages)
        {
            wordListModel.Name = name;
            wordListModel.Languages = languages;
            wordListModel.Words = new List<WordModel>();
        }

        public static string[] GetLists()
        {
            var client = new MongoClient();
            var db = client.GetDatabase("MyDictionary");
            var collection = db.GetCollection<WordListModel>("WordLists");
            List<WordListModel> wordLists = collection.Find(p => true).ToList();

            string[] lists = new string[wordLists.Count];

            for (int i = 0; i < wordLists.Count; i++) lists[i] = wordLists[i].Name;

            return lists;
        }


        public static WordList LoadList(string name)
        {

            var client = new MongoClient();
            var db = client.GetDatabase("MyDictionary");
            var collection = db.GetCollection<WordListModel>("WordLists");

            var list = collection.Find(p => p.Name == name).FirstOrDefault();
            if (list != null)
            {
                var wordList = new WordList(list.Name, list.Languages);
                wordList.wordListModel = list;
                return wordList;
            }
            else
            {
<<<<<<< HEAD
                //Console.WriteLine($"There is no wordlist with the given name!\n");
=======
>>>>>>> dba3e85838eab611106a2757ef511e8e48b461a3
                return null;
            }
            
        }


        public void Save()
        {

            var client = new MongoClient();
            var database = client.GetDatabase("MyDictionary");
            var collection = database.GetCollection<WordListModel>("WordLists");

            var currentlist = collection.Find(p => p.Name == wordListModel.Name).FirstOrDefault();


            if (currentlist != null) wordListModel.Id = currentlist.Id;

            else wordListModel.Id = Guid.NewGuid();


            collection.ReplaceOne(
                p => p.Name == wordListModel.Name,
                wordListModel,
                new ReplaceOptions { IsUpsert = true });
        }


        public void Add(params string[] translations)
        {
            //var exists = wordListModel.Words.First(p => p.Translations == translations);
            if (Languages.Length != translations.Length) throw new Exception();
            else wordListModel.Words.Add(new WordModel(translations));
        }


        public bool Remove(int translation, string word)
        {

            var ToBeDeleted = wordListModel.Words.FindAll(x => x.Translations[translation] == word);

            if (ToBeDeleted.Count > 0)
            {
                foreach (var item in ToBeDeleted)
                {
                wordListModel.Words.Remove(item);
                }
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }


        public int Count()
        {
            return wordListModel.Words.Count;
        }


        public void List(int sortByTranslation, Action<string[]> showTranslations)
        {
            var sortedList = wordListModel.Words.OrderBy(p => p.Translations[sortByTranslation]).ToList();

            foreach (var item in sortedList) showTranslations?.Invoke(item.Translations);
        }


        public WordModel GetWordToPractice()
        {
            var random = new Random();
            var rndWord = random.Next(0, wordListModel.Words.Count);
            var rndFromLanguage = random.Next(0, Languages.Length);
            var rndToLanguage = random.Next(0, Languages.Length);

            while (rndFromLanguage == rndToLanguage)
            {
                rndFromLanguage = random.Next(0, Languages.Length);
            }

            var translations = new WordModel(rndFromLanguage, rndToLanguage, wordListModel.Words[rndWord].Translations);
            return translations;

        }

        public static WordListModel DeleteList(string name)
        {

            var client = new MongoClient();
            var db = client.GetDatabase("MyDictionary");
            var collection = db.GetCollection<WordListModel>("WordLists");

            var deletedList = collection.FindOneAndDelete(p => p.Name == name);
            if (deletedList != null)
            {
                return deletedList;
            }
            else
            {
                return null;
            } 
        }
    }
}

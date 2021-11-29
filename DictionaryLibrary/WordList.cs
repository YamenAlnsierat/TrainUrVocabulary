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

        //Namnet på listan.
        public string Name => wordListModel.Name;

        //Namnen på språken.
        public string[] Languages => wordListModel.Languages;



        public WordList(string name, params string[] languages)
        {
            //Konstruktor.Sätter properites Name och Languages till parametrarnas värden.
            wordListModel.Name = name.ToLower();
            wordListModel.Languages = languages;
            wordListModel.Words = new List<WordModel>();
            wordListModel.Id = Guid.NewGuid();


            //Save();

        }


        public static string[] GetLists()
        {
            //Returnerar array med namn på alla listor som finns lagrade.
            var client = new MongoClient();
            var db = client.GetDatabase("MyDictionary");
            var collection = db.GetCollection<WordListModel>("WordLists");
            List<WordListModel> wordLists = collection.Find(p => true).ToList();


            string[] lists = new string[wordLists.Count];
            for (int i = 0; i < wordLists.Count; i++)
            {
                lists[i] = wordLists[i].Name;
            }

            return lists;
        }


        public static WordList LoadList(string name)
        {

            //Laddar in ordlistan och returnerar som WordList.

            var client = new MongoClient();
            var db = client.GetDatabase("MyDictionary");
            var collection = db.GetCollection<WordListModel>("WordLists");


            var list = collection.Find(p => p.Name == name.ToLower()).FirstOrDefault();

            var wordList = new WordList(list.Name, list.Languages);
            wordList.wordListModel = list;
            //wordList.Save();
            return wordList;
            
        }


        public void Save()
        {
            //Sparar listan till en fil med samma namn som listan

            var client = new MongoClient();
            var database = client.GetDatabase("MyDictionary");
            var collection = database.GetCollection<WordListModel>("WordLists");

            //new BsonDocument("_id", new BsonBinaryData(wordListModel.Id, GuidRepresentation.Standard))

            //var filter = Builders<WordListModel>.Filter.Eq("_id", wordListModel.Id);

            collection.ReplaceOne(
                p => p.Name == wordListModel.Name,
                wordListModel,
                new ReplaceOptions { IsUpsert = true });


        }

        public void Add(params string[] translations)
        {
            WordModel wordModel = new WordModel(translations);
            wordListModel.Words.Add(wordModel);
            Save();
        }

        public bool Remove(int translation, string word)
        {
            //translation motsvarar index i Languages.Sök igenom språket och ta bort ordet.
            //returnerar true om den hittade & tog bort ordet.

            for (int i = 0; i < Languages.Length; i++)
            {
                if (Languages[i] == Languages[translation])
                {
                    for (int t = 0; t < wordListModel.Words.Count; t++)
                    {
                        if (wordListModel.Words[t].Translations[i] == word)
                        {
                            wordListModel.Words[t].Translations[i] = "";
                            Save();
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public int Count()
        {
            //Räknar och returnerar antal ord i listan.

            return wordListModel.Words.Count;
        }

        public void List(int sortByTranslation, Action<string[]> showTranslations)
        {
            //sortByTranslation = Vilket språk listan ska sorteras på.
            //showTranslations = Callback som anropas för varje ord i listan.
            for (int i = 0; i < Languages.Length; i++)
            {
                if (Languages[i] == Languages[sortByTranslation])
                {
                    //foreach (var item in showTranslations)
                    //{

                    //}
                }
            }
        }

        public WordModel GetWordToPractice()
        {
            //var wordModel = new WordModel(0,1,Console.ReadLine());

            //Returnerar slumpmässigt Word från listan, med slumpmässigt valda
            //FromLanguage och ToLanguage(dock inte samma)
            return null;

        }
    }
}

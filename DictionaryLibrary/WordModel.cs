using System;

namespace DictionaryLibrary
{
    public class WordModel
    {
        public string[] Translations { get; set; }
        public int FromLanguage { get; }
        public int ToLanguage { get; }
        //Translations lagrar översättningarna, en för varje språk.Med FromLanguage och
        //ToLanguage kan man ange för övningar vilket språk som ska översättas till
        //respektive från. Dessa används av metoden WordList.GetWordToPractice() och
        //behöver inte lagras i databasen.


        public WordModel(params string[] translations)
        {
            Translations = translations;        
            //initialiserar ’Translations’ med data som skickas in som ’translations’ 
        }

        public WordModel(int fromLanguage, int toLanguage, params string[] translations)
        {
            FromLanguage = fromLanguage;
            ToLanguage = toLanguage;
            Translations = translations;
            //samma som ovan, fast sätter även FromLanguage och ToLanguage.
        }
    }
}

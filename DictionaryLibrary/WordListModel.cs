using System;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Text;

namespace DictionaryLibrary
{
    public class WordListModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string[] Languages { get; set; }
        public List<WordModel> Words { get; set; }



    }
}

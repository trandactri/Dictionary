using Newtonsoft.Json;

namespace MultipleLanguagesDictionary1.Models
{
    public class Dictionary
    {

        public string word { get; set; }
        public string phonetic { get; set; }
        public string origin { get; set; }

        [JsonProperty("meanings")]
        public List<ValueSet> meanings { get; set; }
        public class ValueSet
        {

            [JsonProperty("partOfSpeech")]
            public string partOfSpeech { get; set; }

            [JsonProperty("definitions")]
            public List<Value> definitions { get; set; }
        }
        public class Value
        {
            [JsonProperty("definition")]
            public string definition { get; set; }

            // [JsonProperty("synonyms")]
            // public Array synonyms { get; set; }
        }

    }


}
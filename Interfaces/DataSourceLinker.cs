using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace QuizLibrary
{
    public class DataSourceLinker
    {
        public bool AddData(List<Question> questionList)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            string jsonString = String.Empty;
            
            using (StreamWriter streamWriter=new StreamWriter("questions.json",false))
            {
                streamWriter.WriteLine(JsonConvert.SerializeObject(questionList,Formatting.Indented));
            }
            return true;
        }

        public Question GetData(string qId)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            Question question=new Question();

            using (StreamReader file = File.OpenText("questions.json"))
            {
                using (JsonTextReader jsonTextReader = new JsonTextReader(file))
                {
                    jsonTextReader.SupportMultipleContent = true;
                    while (jsonTextReader.Read())
                    {
                        if (jsonTextReader.TokenType == JsonToken.StartObject)
                        {
                            question = jsonSerializer.Deserialize<Question>(jsonTextReader);
                            if (question.QuestionId == qId)
                                return question;
                        }
                    }
                    
                }
                    
            }
            return null;
        }

        public List<Question> GetData()
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            List<Question> questionList = new List<Question>();

            using (StreamReader file = File.OpenText("questions.json"))
            {
                using (JsonTextReader jsonTextReader = new JsonTextReader(file))
                {
                    jsonTextReader.SupportMultipleContent = true;
                    while (jsonTextReader.Read())
                    {
                        if (jsonTextReader.TokenType == JsonToken.StartObject)
                        {
                            questionList.Add(jsonSerializer.Deserialize<Question>(jsonTextReader));
                        }
                    }

                }

            }
            
            return questionList;
        }
    }
}

﻿using System;
using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Potentiometer.Core.QuestionTypes
{
    public class MCQOption
    {
        public string Raw { get; set; }
        public string OptionText { get; set; }
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    [BsonDiscriminator("MCQ")]
    public class MCQ : IQuestion
    {
        public MCQ()
        {
            this.QuestionId = ObjectId.GenerateNewId().ToString();
        }

        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string QuestionId { get; set; }

        public string Title { get; set; }
        public string Domain { get; set; }
        public string QuestionType { get; set; }
        public string[] ConceptTags { get; set; }
        public string Taxonomy { get; set; }
        public int DifficultyLevel { get; set; }

        public string QuestionText { get; set; }
        public string Raw { get; set; }
        public List<MCQOption> Options { get; set; }
        public MCQOption CorrectAnswer { get; set; }
        public MCQOption Response { get; set; }
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public bool Evaluate()
        {
            return Response.ToString() == CorrectAnswer.ToString();
        }
    }
}

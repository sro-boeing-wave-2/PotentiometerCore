using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Potentiometer.Core.QuestionTypes
{
    public class MMCQOption
    {
        public string Raw { get; set; }
        public string OptionText { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    [BsonDiscriminator("MMCQ")]
    public class MMCQ : IQuestion
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string QuestionId { get; set; }

        public string Title { get; set; }
        public string Domain { get; set; }
        public string QuestionType { get; set; }
        public string[] ConceptTags { get; set; }
        public string Taxonomy { get; set; }

        public string QuestionText { get; set; }
        public string Raw { get; set; }
        public List<MMCQOption> Options { get; set; }
        public List<MMCQOption> CorrectOptions { get; set; }
        public List<MMCQOption> Response { get; set; }

        public bool Evaluate()
        {
            return Response.ToString() == CorrectOptions.ToString();
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
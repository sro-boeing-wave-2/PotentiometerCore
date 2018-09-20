using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Potentiometer.Core.QuestionTypes
{
    /// <summary>
    /// BaseClass for all the Question types
    /// </summary>
    public interface IQuestion
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string QuestionId { get; set; }

        string Title { get; set; }
        string Domain { get; set; }
        string QuestionType { get; set; }
        string[] ConceptTags { get; set; }
        string Taxonomy { get; set; } //BloomsTaxanomy level
        bool Evaluate();
    }
}
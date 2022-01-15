using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creditcard.Core
{
    public class Creditcard
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string SCode { get; set; }
        public string Cardnumber { get; set; }
        public string IUser { get; set; }


    }
}

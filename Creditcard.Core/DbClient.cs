using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creditcard.Core
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Creditcard> _creditcards;

        public DbClient(IOptions<CreditcardDbConfig> creditcardDbConfig)
        {
            var client = new MongoClient(creditcardDbConfig.Value.Connection_String);
            var database = client.GetDatabase(creditcardDbConfig.Value.Database_Name);
            _creditcards = database.GetCollection<Creditcard>(creditcardDbConfig.Value.Creditcard_Collection_Name);
        }

        public IMongoCollection<Creditcard> GetCreditcardCollection() => _creditcards;
    }
}

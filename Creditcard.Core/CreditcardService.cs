using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Creditcard.Core
{
    public class CreditcardService : ICreditcardService
    {
        private readonly IMongoCollection<Creditcard> _creditcards;
        public CreditcardService(IDbClient dbClient)
        {
            _creditcards=dbClient.GetCreditcardCollection();
        }

        public Creditcard AddCreditcard(Creditcard creditcard)
        {
            _creditcards.InsertOne(creditcard);
            return creditcard;
        }

        public List<Creditcard> GetCreditcards()
        {
            return  _creditcards.Find(creditcard =>true).ToList();
        }
    }
}

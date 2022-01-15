using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creditcard.Core
{
    public interface IDbClient
    {
        IMongoCollection<Creditcard> GetCreditcardCollection();
    }
}

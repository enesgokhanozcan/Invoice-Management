using System;
using System.Collections.Generic;

namespace Creditcard.Core
{
    public class CreditcardService : ICreditcardService
    {
        public List<Creditcard> GetCreditcards()
        {
            return new List<Creditcard>
            {
                new Creditcard
                {
                    Name ="Enes",
                    Surname ="Ozcan"
                }
            };
        }
    }
}

using Creditcard.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditcardController : ControllerBase
    {
        private readonly ICreditcardService creditcardService;
        public CreditcardController(ICreditcardService _creditcardService)
        {
            creditcardService = _creditcardService;
        }
        [HttpGet]
        public IActionResult GetCards()
        {
            return Ok(creditcardService.GetCreditcards());
        }
        [HttpPost]
        public IActionResult AddCreditcard (Creditcard.Core.Creditcard creditcard)
        {
            creditcardService.AddCreditcard(creditcard);
            return Ok(creditcard);
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TP3_REST.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        [HttpGet]
        public string[] Get()
        {
            return new string[]
            {
                "val 1",
                "val 2"
            };
        }

        [HttpGet ("{id}") ]
        public IActionResult Get(int id, string query)
        {
            return Ok(new Livre { ISBN = id, Titre = "livre" + id });
        }

        [HttpPost]
        public IActionResult Post([FromBody] Livre livre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get", new { isbn = livre.ISBN }, livre);

        }

    }

    public class Value
    {
        public int Id { get; set; }
        [MinLength(3)]
        public string Text { get; set; }
    }
}
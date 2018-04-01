using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TP3_REST.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    public class BiblioController : Controller
    {

        

        //retourne la liste des livres
        [HttpGet]
        public ActionResult Get()
        {
            return View(Biblio.livres);
        }

        [HttpGet ("{isbn}") ]
        public Livre GetLivreByISBN(int isbn)
        {
            Livre lvr = new Livre("livre not found", "auteur not found", "editeur not found", 00000, 0);
            foreach (Livre item in Biblio.livres)
            {
                if (item.ISBN == isbn)
                    lvr = item;
            }
            return lvr;
        }

        [HttpGet("{auteur}")]
        public Livre GetLivreByAuteur(string auteur)
        {
            Livre lvr = new Livre("livre not found", "auteur not found", "editeur not found", 00000, 0);
            foreach (Livre item in Biblio.livres)
            {
                if (item.Auteur == auteur)
                    lvr = item;
            }
            return lvr;
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
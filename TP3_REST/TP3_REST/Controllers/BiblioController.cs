using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP3_REST.Models;

namespace TP3_REST.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    public class BiblioController : Controller
    {

        private readonly BiblioContext _context;

        public BiblioController(BiblioContext context)
        {
            _context = context;
            if (_context.Livres.Count() == 0)
            {
                _context.Livres.Add(new Livre("harry potter", "jk rowling", "poche", 12345, 12));
                _context.Livres.Add(new Livre("lord of the rings", "Tolkien", "ace books", 87452, 6));
                _context.Livres.Add(new Livre("the hobbit", "Tolkien", "ace books", 87450, 6));
                _context.Livres.Add(new Livre("don quixote", "de cervantes", "glenat", 25478, 8));

                _context.Users.Add(new UtilisateurAbonne("ali"));
                _context.Users.Add(new UtilisateurAbonne("tom"));
                _context.Users.Add(new UtilisateurAbonne("tom"));

                _context.Commentaires.Add(new Commentaire(12345, "un commentaire hp"));
                _context.Commentaires.Add(new Commentaire(12345, "un deuxieme commentaire"));

                _context.SaveChanges();
            }
        }

        //retourne la liste des livres
        [HttpGet(Name ="GetAll")]
        public IEnumerable<Livre> GetLivres()
        {
            return _context.Livres.ToList();
        }

        [HttpGet("users", Name = "GetAllUsers")]
        public IEnumerable<UtilisateurAbonne> GetUtilisateurs()
        {
            return _context.Users.ToList();
        }

        [HttpGet("livres/isbn/{isbn}", Name ="GetLivreByIsbn")]
        public IActionResult GetLivreByISBN(int isbn)
        {
            var item = _context.Livres.FirstOrDefault(t => t.ISBN == isbn);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpGet("livres/auteur/{auteur}")]
        public IActionResult GetLivreByAuteur(string auteur)
        {
            var item = _context.Livres.Where(res => res.Auteur == auteur);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpGet("users/user/{user}", Name ="getUserById")]
        public IActionResult GetUserById(string user)
        {
            var item = _context.Users.FirstOrDefault(t => t.Numero == user);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }


        [HttpPost]
        public IActionResult AjouterLivre([FromBody] Livre livre)
        {
            if (livre == null)
            {
                return BadRequest();
            }

            _context.Livres.Add(livre);
            _context.SaveChanges();

            return CreatedAtRoute("GetAll", new { isbn = livre.ISBN }, livre);

        }

        [HttpGet("livres/commentaires/{isbn}", Name ="commentaireByLivre")]
        public IActionResult getCommentsByLivre(int isbn)
        {
            var commentaire = _context.Commentaires.Where(t => t.idLivre == isbn);
            if (commentaire == null)
            {
                return NotFound();
            }

            return new ObjectResult(commentaire);
        }

        [HttpPost("livres/addCommentaire/{isbn}")]
        public IActionResult AjouterCommentaire([FromBody] Commentaire commentaire)
        {
            if (commentaire == null)
            {
                return BadRequest();
            }
            Commentaire comment = new Commentaire(commentaire.idLivre, commentaire.commentaire);
            _context.Commentaires.Add(comment);
            _context.SaveChanges();
            
            return CreatedAtRoute("commentaireByLivre", new { isbn = comment.idLivre}, comment);
        }

        [HttpPost("users/addUser")]
        public IActionResult AjouterUtilisateur([FromBody] UtilisateurAbonne user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtRoute("getUserById", new { user = user.Numero }, user);
        }


        [HttpDelete("users/deleteUser/{user}")]
        public IActionResult DeleteUser(string user)
        {
            var User = _context.Users.FirstOrDefault(r => r.Numero == user);
            if (User == null)
            {
                return NotFound();
            }

            _context.Users.Remove(User);
            _context.SaveChanges();
            return new NoContentResult();

        }
        
    }
}
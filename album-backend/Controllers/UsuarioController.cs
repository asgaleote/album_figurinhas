using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AlbumFigurinhasContext _context;

        public UsuarioController(AlbumFigurinhasContext context)
        {
            _context = context;

            if (_context.Usuarios.Count() == 0) 
            {
                _context.Usuarios.Add(
                    new Usuario {
                        Nome = "John Snow",
                        Email = "johnsnow@winterfell.wes",
                        Senha = "ghost_wolf",
                        MeuAlbum = new Album {}
                    });
                _context.SaveChanges();
            }
        }

        [HttpPost]
        public string PostUsuario(Usuario usuario){

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return "200";
        }

        [HttpGet]
        public ActionResult<List<Usuario>> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        [HttpGet("{id}", Name = "GetUsuario")]
        public ActionResult<Usuario> GetById(long id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null) {
                return NotFound();
            }
            return usuario;
        }

        [HttpGet("{email}", Name = "GetUsuarioEmail")]
        public ActionResult<List<Usuario>> GetByEmailPwd(string email, string senha)
        {
            var usuario = _context.Usuarios.Where(u => u.Email.Contains(email) 
                    && u.Senha.Contains(senha)).ToList();
            
            if (usuario == null) {
                return NotFound();
            }
            
            return usuario;
        }
    }
}
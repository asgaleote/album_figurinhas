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
    }
}
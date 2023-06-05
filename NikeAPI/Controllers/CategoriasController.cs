
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NikeAPI.Context;
using NikeAPI.Domain;
using System.Data.Entity;

namespace NikeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriiasProdutos()
        {
            return _context.Categorias.Include(p => p.Produtos).ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            var categorias = _context.Categorias.ToList();

            if(categorias.Any()) 
                return categorias;
            else
                return NotFound("Categorias não encontradas.");
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id) 
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);

            if (categoria is null)
                return NotFound("Categoria não encontrada.");
            else
                return Ok(categoria);
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria) 
        {
            if (categoria is null)
                return BadRequest();

            var categoriaExiste = _context.Categorias.FirstOrDefault(c => c.Id == categoria.Id);
            if (categoriaExiste is not null)
                return BadRequest();

            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id,  Categoria categoria) 
        {
            if(id != categoria.Id)
                return BadRequest();

            _context.Entry(categoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id) 
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);

            if (categoria is null)
                return NotFound("Categoria não encontrada.");

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return Ok(categoria);
        }
    }
}

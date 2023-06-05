using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NikeAPI.Context;
using NikeAPI.Domain;

namespace NikeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.Produtos.ToList();

            if(produtos.Any())
                return Ok(produtos);
            else
                return NotFound("Produtos não encontrados...");
            
        }

        [HttpGet("{id:int}", Name=("ObterProduto"))]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null)
                return NotFound("Produto não encontrado...");
            else
                return Ok(produto);
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
                return BadRequest();

            var produtoExiste = _context.Produtos.FirstOrDefault(p => p.Id == produto.Id);
            if (produtoExiste is not null)
                return BadRequest();

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto", new {  id = produto.Id }, produto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if(id != produto.Id) 
                return BadRequest();

            _context.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id) 
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

            if (produto is null)
                return NotFound("Produto não encontrado.");

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }
    }
}

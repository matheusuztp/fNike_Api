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
                return produtos;
            else
                return NotFound("Produtos não encontrados...");
            
        }

        [HttpGet("{id:int}")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null)
                return NotFound("Produto não encontrado...");
            else
                return produto;
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {

        }
    }
}

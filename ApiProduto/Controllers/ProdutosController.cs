using ApiProduto.Context;
using ApiProduto.Models;
using ApiProduto.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProduto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        //private readonly AppDbContext _context;


        //public ProdutosController(AppDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IProdutoService _produto;

        public ProdutosController(IProdutoService produto)
        {
            _produto = produto;
        }

        // Get: Api/Produtos
        [HttpGet]
        public async Task<IEnumerable<Produto>> GetProdutos()
        {
            return await _produto.ObterProdutos();
        }

        // Get: Api/Produto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _produto.ObterProduto(id);

            if (produto == null)
                return NotFound("Produto não encontrado!");

            return produto;
        }

        // Put: api/Produto/5
        [HttpPut()]
        public async Task PutProduto(Produto produto)
        {
           await _produto.AtualizarProduto(produto);
        }

        // Get: Api/Produto/5
        [HttpDelete()]
        public async Task DeleteProduto([FromQuery] int id)
        {
            await _produto.DeletarProduto(id);
        }

        // Post: api/Produto
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            await _produto.CriarProduto(produto);
            return CreatedAtAction("GetProduto", new { id = produto.Id }, produto);
        }

    }
}

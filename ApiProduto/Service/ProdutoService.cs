using ApiProduto.Context;
using ApiProduto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProduto.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly AppDbContext _context;
        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Produto> ObterProduto(int id) => await _context.Produtos.FindAsync(id);
        public async Task<IEnumerable<Produto>> ObterProdutos() => await _context.Produtos.ToListAsync();
        public async Task<IEnumerable<Produto>> ObterProdutosPorNome(string nome) => await _context.Produtos.Where(n => n.Nome.Contains(nome)).ToListAsync();
        public async Task CriarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }
        public async Task AtualizarProduto(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletarProduto(int id)
        {
            Produto produto = _context.Produtos.Single(x => x.Id == id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }
    }
}

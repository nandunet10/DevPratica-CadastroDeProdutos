using ApiProduto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProduto.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> ObterProdutos();
        Task<IEnumerable<Produto>> ObterProdutosPorNome(string nome);
        Task<Produto> ObterProduto(int id);
        Task CriarProduto(Produto produto);
        Task AtualizarProduto(Produto produto);
        Task DeletarProduto(int id);

    }
}

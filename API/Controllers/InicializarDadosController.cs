using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/inicializar")]
    public class InicializarDadosController : ControllerBase
    {
        private readonly DataContext _context;
        public InicializarDadosController(DataContext context)
        {
            _context = context;
        }

        //POST: api/inicializar/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create()
        {
            _context.Categorias.AddRange(new Categoria[]
                {
                    new Categoria { CategoriaId = 1, Nome = "Creatina" },
                    new Categoria { CategoriaId = 2, Nome = "BCA" },
                    new Categoria { CategoriaId = 3, Nome = "Pre Treino" },
                }
            );
            _context.Produtos.AddRange(new Produto[]
                {
                    new Produto { ProdutoId = 1, Nome = "Supino reto", Preco = 1, Descricao = "Para treino de peito!", Quantidade = 1, CategoriaId = 1 },
                    new Produto { ProdutoId = 2, Nome = "Kit Com Barras De Halteres ", Preco = 2, Descricao = "Para treino de superiores", Quantidade = 2, CategoriaId = 2 },
                    new Produto { ProdutoId = 3, Nome = "Halter 5 Kg", Preco = 30, Descricao = "Para treino de biceps", Quantidade = 3, CategoriaId = 3 },
                }
            );
            _context.FormaPagamentos.AddRange(new FormaPagamento[]
            {
                new FormaPagamento {Id = 1, Numero = "1000000000000000" , Nome = "Banco do brasil", Cvv = "100", Vencimento = "10/29"},
                new FormaPagamento {Id = 2, Numero = "2000000000000000" , Nome = "ITAU", Cvv = "200", Vencimento = "01/03"},
            });
            _context.SaveChanges();
            return Ok(new { message = "Dados inicializados" });
        }
    }
}
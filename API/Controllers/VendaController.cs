using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/venda")]
    public class VendaController : ControllerBase
    {
        private readonly DataContext _context;
        public VendaController(DataContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] Venda venda)
        {
            _context.Vendas.Add(venda);
            _context.SaveChanges();
            return Created("", venda);
        }


        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            return Ok(_context.Vendas.ToList());
        }
    }
}
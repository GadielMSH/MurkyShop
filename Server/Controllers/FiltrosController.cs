using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MurkyShop.Server.Data;
using MurkyShop.Shared.Models;

namespace MurkyShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiltrosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public FiltrosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<List<Filtro>> Filtros()
        {
            List<Filtro> filtros = new List<Filtro>();

            filtros = await context.Filtros.ToListAsync();

            return filtros;
        }
    }
}


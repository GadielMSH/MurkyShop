using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MurkyShop.Server.Data;
using MurkyShop.Shared.Models;

namespace MurkyShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AditivosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AditivosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<List<Aditivo>> Aditivos()
        {
            List<Aditivo> aditivos = new List<Aditivo>();

            aditivos = await context.Aditivos.ToListAsync();

            return aditivos;
        }
    }
}

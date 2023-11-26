using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MurkyShop.Server.Data;
using MurkyShop.Shared.Models;

namespace MurkyShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PecesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PecesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<List<Pez>> Peces()
        {
            List<Pez> peces = new List<Pez>();

            peces = await context.Peces.ToListAsync();

            return peces;
        }
    }
}

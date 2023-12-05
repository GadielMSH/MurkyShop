
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MurkyShop.Server.Data;
using MurkyShop.Shared.Models;

namespace MurkyShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PecerasController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PecerasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<List<Pecera>> Peceras()
        {
            List<Pecera> peceras = new List<Pecera>();

            peceras = await context.Peceras.ToListAsync();

            return peceras;
        }
    }
}

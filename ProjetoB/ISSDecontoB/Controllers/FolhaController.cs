using ISSDecontoB.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ISSDecontoB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolhaController : ControllerBase
    {
        private readonly IRabbitMQServices _services;
        public FolhaController(IRabbitMQServices services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_services.ConsumirQueue());
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [HttpGet]
        [Route("total")]
        public async void Total()
        {
        }

        [HttpGet]
        [Route("media")]
        public async void Media()
        {
        }

    }
}

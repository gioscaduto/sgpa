using Microsoft.AspNetCore.Mvc;
using Sgpa.Api.Controllers;

namespace Sgpa.Api.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/produtos")]
    public class ProdutosController : MainController
    {
        [HttpGet]
        public IActionResult Obter()
        {
            return Ok(new { id = Guid.NewGuid(), name = "Produto Teste" });
        }
    }
}

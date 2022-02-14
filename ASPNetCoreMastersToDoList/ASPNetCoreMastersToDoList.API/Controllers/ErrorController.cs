using Microsoft.AspNetCore.Mvc;

namespace ASPNetCoreMastersToDoList.API.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/error")]
        public IActionResult Error() => Problem();
    }
}

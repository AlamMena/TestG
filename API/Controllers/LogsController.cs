using API.DbModels;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogsController : Controller
    {
        private readonly ILogginService _logginService;

        public LogsController(ILogginService logginService)
        {
            _logginService = logginService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetLogs()
        {
            try
            {
                var logs = await _logginService.GetLogs();

                return Ok(logs);

            }
            catch (Exception ex)
            {
                await _logginService.Savelog(new Log()
                {
                    Request = "",
                    RequestDate = DateTime.Now,
                    Response = ex.Message,
                    ResponseDate = DateTime.Now,
                    StatusCode = 400,
                    User = 1,
                });
                return BadRequest(ex.Message);
                //return (ex.Message);
            }
        }
    }
}

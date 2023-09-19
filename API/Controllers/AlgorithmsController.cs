using API.DbModels;
using API.Services;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlgorithmsController : Controller
    {
        private readonly IAlgorithmsService _algorithmsService;
        private readonly ILogginService _logginService;

        public AlgorithmsController(IAlgorithmsService algorithmsService, ILogginService logginService)
        {
            _algorithmsService = algorithmsService;
            _logginService = logginService;
        }

        [HttpPost("pattern")]
        public async Task<IActionResult> GetPattern(PatternRequest request)
        {
            try
            {
                if (request.Phrase.IsNullOrEmpty())
                {
                    return BadRequest("Invalid input");
                }
                var pattern = _algorithmsService.GetPattern(request.Phrase);


                await _logginService.Savelog(new Log()
                {
                    Request = JsonSerializer.Serialize(request),
                    RequestDate = request.RequestDate,
                    Response = pattern,
                    ResponseDate = DateTime.Now,
                    StatusCode = 200,
                    User = request.User,
                });

                return Ok(new { pattern });

            }
            catch (Exception ex)
            {
                await _logginService.Savelog(new Log()
                {
                    Request = JsonSerializer.Serialize(request),
                    RequestDate = DateTime.Now,
                    Response = ex.Message,
                    ResponseDate = DateTime.Now,
                    StatusCode = 400,
                    User = 1,
                });
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("generateFace")]
        public async Task<IActionResult> GetFace(FaceParametersInput parametersInput)
        {
            try
            {
                var face = _algorithmsService.BuildFace(parametersInput);

                await _logginService.Savelog(new Log()
                {
                    Request = JsonSerializer.Serialize(parametersInput),
                    RequestDate = DateTime.Now,
                    Response = face,
                    ResponseDate = DateTime.Now,
                    StatusCode = 200,
                    User = 1,
                });

                return Ok(new { face });

            }
            catch (Exception ex)
            {
                await _logginService.Savelog(new Log()
                {
                    Request = JsonSerializer.Serialize(parametersInput),
                    RequestDate = DateTime.Now,
                    Response = ex.Message,
                    ResponseDate = DateTime.Now,
                    StatusCode = 400,
                    User = 1,
                });
                return BadRequest(ex.Message);
            }

        }
    }
}

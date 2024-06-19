using EXAMPLE_API.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using EXAMPLE_API.Entities.Request;
using EXAMPLE_API.Entities.Config;

namespace EXAMPLE_API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(UserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        private Languages lng;
        private Languages Lng
        {
            get
            {
                if (lng == null)
                {
                    var lngJson = (string)_httpContextAccessor.HttpContext.Items["languages"];
                    lng = JsonConvert.DeserializeObject<Languages>(lngJson);
                }
                return lng;
            }
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _userService.gestion(
                    Lng,
                    1,
                    "solanol",
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null
                );

                if (result.TypeResult == 0) // Asumiendo 0 significa éxito
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{idUser}")]
        public async Task<IActionResult> Get(int idUser)
        {
            try
            {
                var result = await _userService.gestion(
                    Lng,
                    2,
                    "solanol",
                    idUser,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null
                );
                if (result.TypeResult == 0) // Asumiendo 0 significa éxito
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserRequest request)
        {
            try
            {
                var result = await _userService.gestion(
                    Lng,
                    3,
                    "solanol",
                    null,
                    request.PcFirstName,
                    request.PcLastName,
                    request.PcEmail,
                    request.PdBirthdate,
                    request.PnIdRole,
                    request.PnStatus
                );

                if (result.TypeResult == 0) // Asumiendo 0 significa éxito
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut("{idUser}")]
        public async Task<IActionResult> Put(int idUser, UserRequest request)
        {
            try
            {
                var result = await _userService.gestion(
                    Lng,
                    4,
                    "solanol",
                    idUser,
                    request.PcFirstName,
                    request.PcLastName,
                    request.PcEmail,
                    request.PdBirthdate,
                    request.PnIdRole,
                    request.PnStatus
                );

                if (result.TypeResult == 0) // Asumiendo 0 significa éxito
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPatch("{idUser}/disable")]
        public async Task<IActionResult> Patch(int idUser)
        {
            try
            {
                var result = await _userService.gestion(
                    Lng,
                    5,
                    "solanol",
                    idUser,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null
                );

                if (result.TypeResult == 0) // Asumiendo 0 significa éxito
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{idUser}")]
        public async Task<IActionResult> Delete(int idUser)
        {
            try
            {
                var result = await _userService.gestion(
                    Lng,
                    6,
                    "solanol",
                    idUser,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null
                );

                if (result.TypeResult == 0) // Asumiendo 0 significa éxito
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}

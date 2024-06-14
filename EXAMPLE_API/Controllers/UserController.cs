using EXAMPLE_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EXAMPLE_API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _userService.gestion(
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

        [HttpPatch("{idUser}")]
        public async Task<IActionResult> Patch(int idUser)
        {
            try
            {
                var result = await _userService.gestion(
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

    public class UserRequest
    {
        public string PcFirstName { get; set; }
        public string PcLastName { get; set; }
        public string PcEmail { get; set; }
        public DateTime? PdBirthdate { get; set; }
        public int? PnIdRole { get; set; }
        public int? PnStatus { get; set; }
    }

}

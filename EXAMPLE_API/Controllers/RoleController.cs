using EXAMPLE_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EXAMPLE_API.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _roleService.gestion(
                    1,
                    "solanol",
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

        [HttpGet("{idRole}")]
        public async Task<IActionResult> Get(int idRole)
        {
            try
            {
                var result = await _roleService.gestion(
                    2,
                    "solanol",
                    idRole,
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
        public async Task<IActionResult> Post(RoleRequest request)
        {
            try
            {
                var result = await _roleService.gestion(
                    3,
                    "solanol",
                    null,
                    request.PcName,
                    request.PcDescription,
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

        [HttpPut("{idRole}")]
        public async Task<IActionResult> Put(int idRole, RoleRequest request)
        {
            try
            {
                var result = await _roleService.gestion(
                    4,
                    "solanol",
                    idRole,
                    request.PcName,
                    request.PcDescription,
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

        [HttpPatch("{idRole}")]
        public async Task<IActionResult> Patch(int idRole)
        {
            try
            {
                var result = await _roleService.gestion(
                    5,
                    "solanol",
                    idRole,
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

        [HttpDelete("{idRole}")]
        public async Task<IActionResult> Delete(int idRole)
        {
            try
            {
                var result = await _roleService.gestion(
                    6,
                    "solanol",
                    idRole,
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

    public class RoleRequest
    {
        public string PcName { get; set; }
        public string PcDescription { get; set; }
        public int? PnStatus { get; set; }
    }
}

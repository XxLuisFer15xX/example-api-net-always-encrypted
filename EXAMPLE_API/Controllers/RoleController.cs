using EXAMPLE_API.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using EXAMPLE_API.Entities.Request;
using EXAMPLE_API.Entities.Config;

namespace EXAMPLE_API.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RoleController(RoleService roleService, IHttpContextAccessor httpContextAccessor)
        {
            _roleService = roleService;
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
                var result = await _roleService.gestion(
                    Lng,
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
                    Lng,
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
                    Lng,
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
                    Lng,
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

        [HttpPatch("{idRole}/disable")]
        public async Task<IActionResult> Patch(int idRole)
        {
            try
            {
                var result = await _roleService.gestion(
                    Lng,
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
                    Lng,
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
}

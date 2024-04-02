using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using new_wr_api.Data;
using new_wr_api.Dto;
using new_wr_api.Service;

namespace new_wr_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class PermissionController : ControllerBase
    {
        private readonly PermissionService _service;

        public PermissionController(PermissionService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("list")]
        public async Task<List<PermissionDto>> GetAllPermission()
        {
            return (await _service.GetAllPermissionAsync());
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<PermissionDto> GetPermissionById(int Id)
        {
            return await _service.GetPermissionByIdAsync(Id);
        }

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult<Permissions>> SavePermission(PermissionDto dto)
        {
            var res = await _service.SavePermissionAsync(dto);
            if (res == true)
            {
                return Ok(new { message = "Saved permission successfully" });
            }
            else
            {
                return BadRequest(new { message = "Save permission failed", error = true });
            }
        }

        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult<Permissions>> DeletePermission(PermissionDto dto)
        {
            var res = await _service.DeletePermissionAsync(dto);
            if (res == true)
            {
                return Ok(new { message = "Permission successfully deleted" });
            }
            else
            {
                return BadRequest(new { message = "Removing permissions failed", error = true });
            }
        }
    }
}

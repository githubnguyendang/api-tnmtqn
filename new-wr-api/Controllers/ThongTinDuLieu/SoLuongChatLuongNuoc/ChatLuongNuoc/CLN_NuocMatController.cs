using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using new_wr_api.Data;
using new_wr_api.Dto;

using new_wr_api.Service;

namespace new_wr_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CLN_NuocMatController : ControllerBase
    {
        private readonly CLN_NuocMatService _service;

        public CLN_NuocMatController(CLN_NuocMatService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach/{tu_nam}/{den_nam}")]
        public async Task<List<CLN_NuocMatDto>> GetAll(int tu_nam, int den_nam)
        {
            return await _service.GetAllCLN_NuocMatAsync(tu_nam, den_nam);
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<CLN_NuocMatDto>> Save(CLN_NuocMatDto moddel)
        {
            var res = await _service.SaveAsync(moddel);
            if (res == true)
            {
                return Ok(new { message = "Dữ liệu đã được lưu" });
            }
            else
            {
                return BadRequest(new { message = "Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<CLN_NuocMatDto>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}

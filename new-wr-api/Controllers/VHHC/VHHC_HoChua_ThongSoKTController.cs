using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using new_wr_api.Data;
using new_wr_api.Dto;

using new_wr_api.Service;

namespace new_wr_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VHHC_HoChua_ThongSoKTController : ControllerBase
    {
        private readonly VHHC_HoChua_ThongSoKTService _service;

        public VHHC_HoChua_ThongSoKTController(VHHC_HoChua_ThongSoKTService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<VHHC_HoChua_ThongSoKTDto>> GetAll()
        {
            return await _service.GetAllVHHC_HoChua_ThongSoKTAsync();
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<VHHC_HoChua_ThongSoKTDto>> Save(VHHC_HoChua_ThongSoKTDto moddel)
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
        public async Task<ActionResult<VHHC_HoChua_ThongSoKTDto>> Delete(int Id)
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

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using new_wr_api.Data;
using new_wr_api.Dto;
using new_wr_api.Service;

namespace new_wr_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ThongSoDiemQuanTracController : ControllerBase
    {
        private readonly ThongSoDiemQuanTracService _service;

        public ThongSoDiemQuanTracController(ThongSoDiemQuanTracService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<ThongSoDiemQuanTracDto>> GetAll(int nam)
        {
            return (await _service.GetAllAsync(nam));
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<ThongSoDiemQuanTracDto> GetById(int Id)
        {
            return await _service.GetByIdAsync(Id);
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<ThongSoDiemQuanTrac>> Save(ThongSoDiemQuanTracDto moddel)
        {
            var res = await _service.SaveAsync(moddel);
            if (res == true)
            {
                return Ok(new { message = "Dữ liệu :Dữ liệu đã được lưu" });
            }
            else
            {
                return BadRequest(new { message = "Dữ liệu :Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<ThongSoDiemQuanTrac>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Dữ liệu :Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Dữ liệu :Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}

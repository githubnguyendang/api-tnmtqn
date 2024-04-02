using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using new_wr_api.Data;
using new_wr_api.Dto;
using new_wr_api.Service;

namespace new_wr_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    // [Authorize]
    public class TramQuangNgaiController : ControllerBase
    {
        private readonly TramQuangNgaiService _service;

        public TramQuangNgaiController(TramQuangNgaiService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<TramQuangNgaiDto>> GetAll()
        {
            return (await _service.GetAllTramQuangNgaiAsync());
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<TramQuangNgai>> Save(TramQuangNgaiDto moddel)
        {
            var res = await _service.SaveAsync(moddel);
            if (res == true)
            {
                return Ok(new { message = "Trạm :Dữ liệu đã được lưu" });
            }
            else
            {
                return BadRequest(new { message = "Trạm :Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("thong-ke-yeu-to-khi-tuong")]
        public async Task<List<ApexChartSeriesTramDto>> TramQuangNgai()
        {
            return (await _service.TramQuangNgaiAsync());
        }

        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<TramQuangNgai>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Trạm :Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Trạm :Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}

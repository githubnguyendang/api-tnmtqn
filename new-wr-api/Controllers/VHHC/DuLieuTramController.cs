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
    public class DuLieuTramController : ControllerBase
    {
        private readonly DuLieuTramService _service;

        public DuLieuTramController(DuLieuTramService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<DuLieuTramDto>> GetAll()
        {
            return (await _service.GetAllDuLieuTramAsync());
        }

        [HttpGet]
        [Route("thong-ke-yeu-to-khi-tuong")]
        public async Task<List<ApexChartSeriesTramDto>> DuLieuTram()
        {
            return (await _service.DuLieuTramAsync());
        }

        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<DuLieuTram>> Delete(int Id)
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

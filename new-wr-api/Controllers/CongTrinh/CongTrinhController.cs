using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using new_wr_api.Data;
using new_wr_api.Dto;
using new_wr_api.Service;

namespace new_wr_api.Controllers
{
    [Route("cong-trinh")]
    [ApiController]
    [Authorize]
    public class CongTrinhController : ControllerBase
    {
        private readonly CT_ThongTinService _service;

        public CongTrinhController(CT_ThongTinService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<CT_ThongTinDto>> GetAllData(string? tenct, int? loai_ct, int? huyen, int? xa, int? song, int? luuvuc, int? tieu_luuvuc, int? tang_chuanuoc, string? nguonnuoc_kt)
        {
            return await _service.GetAllAsync(tenct, loai_ct, huyen, xa, song, luuvuc, tieu_luuvuc, tang_chuanuoc, nguonnuoc_kt);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<CT_ThongTinDto?> GetOneData(int Id)
        {
            return await _service.GetByIdAsync(Id);
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<CT_ThongTin>> Save(CT_ThongTinSaveDto dto)
        {
            var res = await _service.SaveAsync(dto);
            if (res > 0)
            {
                return Ok(new { message = "Công trình: Dữ liệu đã được lưu", id = res });
            }
            else
            {
                return BadRequest(new { message = "Công trình: Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<CT_ThongTin>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Công trình: Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Công trình: Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}

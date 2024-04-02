using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using new_wr_api.Data;
using new_wr_api.Dto;
using new_wr_api.Service;

namespace new_wr_api.Controllers
{
    [Route("tien-cap-quyen")]
    [ApiController]
    [Authorize]
    public class TienCapQuyenController : ControllerBase
    {
        private readonly TCQ_ThongTinService _service;

        public TienCapQuyenController(TCQ_ThongTinService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<TCQ_ThongTinDto>> GetAll()
        {
            return (await _service.GetAllAsync());
        }

        [HttpGet]
        [Route("danh-sach/{coquan_cp}")]
        public async Task<List<TCQ_ThongTinDto>> GetByLicensingAuthorities(string coquan_cp)
        {
            return (await _service.GetByLicensingAuthoritiesAsync(coquan_cp));
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<TCQ_ThongTinDto> GetById(int Id)
        {
            return await _service.GetByIdAsync(Id);
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<TCQ_ThongTin>> Save(TCQ_ThongTinDto dto)
        {
            var res = await _service.SaveAsync(dto);
            if (res > 0)
            {
                return Ok(new { message = "Tiền cấp quyền: Dữ liệu đã được lưu", id = res });
            }
            else
            {
                return BadRequest(new { message = "Tiền cấp quyền: Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<TCQ_ThongTin>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Tiền cấp quyền: Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Tiền cấp quyền: Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}

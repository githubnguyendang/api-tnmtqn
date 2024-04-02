using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using new_wr_api.Data;
using new_wr_api.Dto;

using new_wr_api.Service;

namespace new_wr_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class NDD_TongLuongController : ControllerBase
    {
        private readonly NDD_TongLuongService _service;

        public NDD_TongLuongController(NDD_TongLuongService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<KKTNN_NuocDuoiDat_TongLuongDto>> GetAll()
        {
            return (await _service.GetAllAsync());
        }

        //[HttpPost]
        //[Route("luu")]
        //public async Task<ActionResult<KKTNN_NuocMua_TongLuongDto>> Save(KKTNN_NuocMua_TongLuongDto moddel)
        //{
        //    var res = await _service.SaveAsync(moddel);
        //    if (res == true)
        //    {
        //        return Ok(new { message = "Loại công trình: Dữ liệu đã được lưu" });
        //    }
        //    else
        //    {
        //        return BadRequest(new { message = "Loại công trình: Lỗi lưu dữ liệu", error = true });
        //    }
        //}

        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<KKTNN_NuocDuoiDat_TongLuongDto>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Loại công trình: Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Loại công trình: Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}

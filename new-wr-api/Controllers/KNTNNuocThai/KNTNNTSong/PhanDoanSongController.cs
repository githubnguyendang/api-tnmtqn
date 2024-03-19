using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using new_wr_api.Data;
using new_wr_api.Dto;
using new_wr_api.Service;
using static new_wr_api.Dto.PhanDoanSongDto;

namespace new_wr_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PhanDoanSongController : ControllerBase
    {
        private readonly PhanDoanSongService _service;

        public PhanDoanSongController(PhanDoanSongService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<PhanDoanSongDto>> GetAll()
        {
            return (await _service.GetAllAsync());
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<PhanDoanSongDto?> GetById(int Id)
        {
            return await _service.GetByIdAsync(Id);
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<PhanDoanSong>> Save(PhanDoanSongDto moddel)
        {
            var res = await _service.SaveAsync(moddel);
            if (res == true)
            {
                return Ok(new { message = "Lưu vực :Dữ liệu đã được lưu" });
            }
            else
            {
                return BadRequest(new { message = "Lưu vực :Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<PhanDoanSong>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Lưu vực :Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Lưu vực :Lỗi xóa dữ liệu", error = true });
            }
        }

        [HttpGet("tai-luong")]
        public async Task<ActionResult<List<PhanDoanSongDto>>> GetCalculatedPollutantData()
        {
            try
            {
                var phanDoanSongsWithComputedData = await _service.GetDataCaculatePolutantAsync();
                return Ok(phanDoanSongsWithComputedData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

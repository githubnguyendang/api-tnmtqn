﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using new_wr_api.Data;
using new_wr_api.Dto;
using new_wr_api.Service;

namespace new_wr_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ThongSoCLNSongController : ControllerBase
    {
        private readonly ThongSoCLNSongService _service;

        public ThongSoCLNSongController(ThongSoCLNSongService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danhsach")]
        public async Task<List<ThongSoCLNSongDto>> GetAll()
        {
            return await _service.GetAllThongSoCLNSongAsync();
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<ThongSoCLNSong>> Save(ThongSoCLNSongDto dto)
        {
            var res = await _service.SaveThongSoCLNSongAsync(dto);
            if (res == true)
            {
                return Ok(new { message = "Biểu mẫu: Dữ liệu đã được lưu", id = res });
            }
            else
            {
                return BadRequest(new { message = "Biểu mẫu: Lỗi lưu dữ liệu", error = true });
            }
        }


        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var res = await _service.DeleteThongSoCLNSongAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Dữ liệu: Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Dữ liệu: Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}
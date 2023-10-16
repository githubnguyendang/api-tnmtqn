﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using new_wr_api.Data;
using new_wr_api.Dto;
using new_wr_api.Service;

namespace new_wr_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TieuVungLuuVucController : ControllerBase
    {
        private readonly TieuVungLuuVucService _service;

        public TieuVungLuuVucController(TieuVungLuuVucService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<TieuVungLuuVucDto>> GetAll()
        {
            return (await _service.GetAllAsync());
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<TieuVungLuuVucDto?> GetById(int Id)
        {
            return await _service.GetByIdAsync(Id);
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<TieuVungLuuVuc>> Save(TieuVungLuuVucDto moddel)
        {
            var res = await _service.SaveAsync(moddel);
            if (res == true)
            {
                return Ok(new { message = "Tiểu vùng quy hoạch :Dữ liệu đã được lưu" });
            }
            else
            {
                return BadRequest(new { message = "Tiểu vùng quy hoạch :Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpPost]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<TieuVungLuuVuc>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Tiểu vùng quy hoạch :Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Tiểu vùng quy hoạch :Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}

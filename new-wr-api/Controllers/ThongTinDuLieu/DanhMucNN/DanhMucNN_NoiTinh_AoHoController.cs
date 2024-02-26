﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using new_wr_api.Data;
using new_wr_api.Dto;
using new_wr_api.Models;
using new_wr_api.Service;

namespace new_wr_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DanhMucNN_NoiTinh_AoHoController : ControllerBase
    {
        private readonly DanhMucNN_NoiTinh_AoHoService _service;

        public DanhMucNN_NoiTinh_AoHoController(DanhMucNN_NoiTinh_AoHoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<DanhMucNN_NoiTinh_AoHoDto>> GetAll()
        {
            return await _service.GetAllDanhMucNN_NoiTinh_AoHoAsync();
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<DanhMucNN_NoiTinh_AoHoDto>> Save(DanhMucNN_NoiTinh_AoHoDto moddel)
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
        public async Task<ActionResult<DanhMucNN_NoiTinh_AoHoDto>> Delete(int Id)
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

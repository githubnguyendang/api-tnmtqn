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
    public class DanhMucNN_LienTinhController : ControllerBase
    {
        private readonly DanhMucNN_LienTinhService _service;

        public DanhMucNN_LienTinhController(DanhMucNN_LienTinhService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<DanhMucNN_LienTinhDto>> GetAll()
        {
            return await _service.GetAllDanhMucNN_LienTinhAsync();
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<DanhMucNN_LienTinhDto>> Save(DanhMucNN_LienTinhDto moddel)
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
        public async Task<ActionResult<DanhMucNN_LienTinhDto>> Delete(int Id)
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

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
    public class NN_NguonNuoc_AoHoDamPhaController : ControllerBase
    {
        private readonly NN_NguonNuoc_AoHoDamPhaService _service;

        public NN_NguonNuoc_AoHoDamPhaController(NN_NguonNuoc_AoHoDamPhaService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<NN_NguonNuoc_AoHoDamPhaDto>> GetAll()
        {
            return await _service.GetAllNguonNuocAoHoDamPhaAsync();
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<NN_NguonNuoc_AoHoDamPhaDto>> Save(NN_NguonNuoc_AoHoDamPhaDto moddel)
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
        public async Task<ActionResult<NN_NguonNuoc_AoHoDamPhaDto>> Delete(int Id)
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

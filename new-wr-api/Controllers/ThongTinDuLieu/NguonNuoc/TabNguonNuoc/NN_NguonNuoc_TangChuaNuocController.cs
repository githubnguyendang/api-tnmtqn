﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using new_wr_api.Data;
using new_wr_api.Dto;

using new_wr_api.Service;

namespace new_wr_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NN_NguonNuoc_TangChuaNuocController : ControllerBase
    {
        private readonly NN_NguonNuoc_TangChuaNuocService _service;

        public NN_NguonNuoc_TangChuaNuocController(NN_NguonNuoc_TangChuaNuocService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<NN_NguonNuoc_TangChuaNuocDto>> GetAll()
        {
            return await _service.GetAllNguonNuocTangChuaNuocAsync();
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<NN_NguonNuoc_TangChuaNuocDto>> Save(NN_NguonNuoc_TangChuaNuocDto moddel)
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
        public async Task<ActionResult<NN_NguonNuoc_TangChuaNuocDto>> Delete(int Id)
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

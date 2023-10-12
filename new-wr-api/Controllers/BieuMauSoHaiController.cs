﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using new_wr_api.Data;
using new_wr_api.Dto;
using new_wr_api.Service;

namespace new_wr_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BieuMauSoHaiController : ControllerBase
    {
        private readonly BieuMauHaiService _service;

        public BieuMauSoHaiController(BieuMauHaiService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danhsach")]
        public async Task<List<BieuMauHaiDto>> GetAll()
        {
            return await _service.GetAllBieuMauHaiAsync();
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<BieuMauSoHai>> Save(BieuMauHaiDto dto)
        {
            var res = await _service.SaveBieuMauHaiAsync(dto);
            if (res == true)
            {
                return Ok(new { message = "Biểu mẫu: Dữ liệu đã được lưu", id = res });
            }
            else
            {
                return BadRequest(new { message = "Biểu mẫu: Lỗi lưu dữ liệu", error = true });
            }
        }
        

        [HttpPost]
        [Route("xoa/{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var res = await _service.DeleteBieuMauHaiAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Role: Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Role: Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}
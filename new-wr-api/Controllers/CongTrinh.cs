﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using new_wr_api.Data;
using new_wr_api.Dto;
using new_wr_api.Service;

namespace new_wr_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CongTrinh : ControllerBase
    {
        private readonly CT_ThongTinService _service;

        public CongTrinh(CT_ThongTinService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danhsach")]
        public async Task<List<CT_ThongTinDto>> GetAllData(int? loai_ct, string? huyen, string? xa, int? song, int? luuvuc, int? tieu_luuvuc, int? tang_chuanuoc, int tochuc_canhan)
        {
            return await _service.GetAllAsync(loai_ct, huyen, xa, song, luuvuc, tieu_luuvuc, tang_chuanuoc, tochuc_canhan);
        }

        [HttpGet]
        [Route("laytheoid/{Id}")]
        public async Task<CT_ThongTinDto?> GetOneData(int Id)
        {
            return await _service.GetByIdAsync(Id);
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<CT_ThongTin>> SaveConstruction(CT_ThongTinDto dto)
        {
            var res = await _service.SaveAsync(dto);
            if (res > 0)
            {
                return Ok(new { message = "Công trình: Dữ liệu đã được lưu", id = res });
            }
            else
            {
                return BadRequest(new { message = "Công trình: Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpPost]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<CT_ThongTin>> DeleteConstruction(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Công trình: Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Công trình: Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}
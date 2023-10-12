﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using new_wr_api.Data;
using new_wr_api.Dto;
using new_wr_api.Models;
using new_wr_api.Service;

namespace new_wr_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class LoaiGiayPhepController : ControllerBase
    {
        private readonly GP_LoaiService _service;

        public LoaiGiayPhepController(GP_LoaiService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("list")]
        public async Task<List<GP_LoaiDto>> GetAllGP_Loai()
        {
            return (await _service.GetAllAsync());
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<GP_LoaiDto?> GetGP_LoaiById(int Id)
        {
            return await _service.GetGP_LoaiByIdAsync(Id);
        }

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult<GP_Loai>> SaveGP_Loai(GP_LoaiDto dto)
        {
            var res = await _service.SaveAsync(dto);
            if (res == true)
            {
                return Ok(new { message = "Loại giấy phép: Dữ liệu đã được lưu" });
            }
            else
            {
                return BadRequest(new { message = "Loại giấy phép: Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpPost]
        [Route("delete/{Id}")]
        public async Task<ActionResult<GP_Loai>> DeleteLicenseType(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Loại giấy phép: Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Loại giấy phép: Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}

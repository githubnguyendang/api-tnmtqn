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
    public class NN_HanhLangBaoVeNN_AoHoDamTuNhienNhanTaoController : ControllerBase
    {
        private readonly NN_HanhLangBaoVeNN_AoHoDamTuNhienNhanTaoService _service;

        public NN_HanhLangBaoVeNN_AoHoDamTuNhienNhanTaoController(NN_HanhLangBaoVeNN_AoHoDamTuNhienNhanTaoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<NN_HanhLangBaoVeNN_AoHoDamTuNhienNhanTaoDto>> GetAll()
        {
            return await _service.GetAllHanhLangBaoVeNN_AoHoDamTuNhienNhanTaoAsync();
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<NN_HanhLangBaoVeNN_AoHoDamTuNhienNhanTaoDto>> Save(NN_HanhLangBaoVeNN_AoHoDamTuNhienNhanTaoDto moddel)
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
        public async Task<ActionResult<NN_HanhLangBaoVeNN_AoHoDamTuNhienNhanTaoDto>> Delete(int Id)
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

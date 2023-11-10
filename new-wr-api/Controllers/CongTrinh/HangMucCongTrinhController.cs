﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using new_wr_api.Data;
using new_wr_api.Dto;
using new_wr_api.Service;

namespace new_wr_api.Controllers
{
    [Route("api/hang-muc-ct")]
    [ApiController]
    [Authorize]
    public class HangMucCongTrinhController : ControllerBase
    {
        private readonly CT_HangMucService _service;

        public HangMucCongTrinhController(CT_HangMucService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<CT_HangMuc>> Save(CT_HangMucDto dto)
        {
            var res = await _service.SaveAsync(dto);
            if (res > 0)
            {
                return Ok(new { message = "Hạng mục công trình: Dữ liệu đã được lưu", id = res });
            }
            else
            {
                return BadRequest(new { message = "Hạng mục công trình: Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<CT_HangMuc>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Hạng mục công trình: Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Hạng mục công trình: Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}

﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using new_wr_api.Data;
using new_wr_api.Dto;
using new_wr_api.Service;

namespace new_wr_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KhaNangTiepNhanNuocHoController : ControllerBase
    {
        private readonly KhaNangTiepNhanNuocHoService _service;

        public KhaNangTiepNhanNuocHoController(KhaNangTiepNhanNuocHoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<KhaNangTiepNhanNuocHoDto>> GetAll()
        {
            return (await _service.GetAllAsync());
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<KhaNangTiepNhanNuocHoDto> GetById(int Id)
        {
            return await _service.GetByIdAsync(Id);
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<KhaNangTiepNhanNuocHo>> Save(KhaNangTiepNhanNuocHoDto moddel)
        {
            var res = await _service.SaveAsync(moddel);
            if (res == true)
            {
                return Ok(new { message = "Lưu vực :Dữ liệu đã được lưu" });
            }
            else
            {
                return BadRequest(new { message = "Lưu vực :Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<KhaNangTiepNhanNuocHo>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Lưu vực :Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Lưu vực :Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}

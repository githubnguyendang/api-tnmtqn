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
    public class CTKTSDN_PDK_NuocMatController : ControllerBase
    {
        private readonly CTKTSDN_PDK_NuocMatService _service;

        public CTKTSDN_PDK_NuocMatController(CTKTSDN_PDK_NuocMatService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<CTKTSDN_PDK_NuocMatDto>> GetAll()
        {
            return await _service.GetAllCTKTSDN_PDK_NuocMatAsync();
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<CTKTSDN_PDK_NuocMatDto>> Save(CTKTSDN_PDK_NuocMatDto moddel)
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
        public async Task<ActionResult<CTKTSDN_PDK_NuocMatDto>> Delete(int Id)
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

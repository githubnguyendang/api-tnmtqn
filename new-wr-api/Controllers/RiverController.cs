﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using new_wr_api.Data;
using new_wr_api.Models;
using new_wr_api.Service;

namespace new_wr_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Administrator")]
    public class RiverController : ControllerBase
    {
        private readonly RiverService _service;

        public RiverController(RiverService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("list")]
        public async Task<List<RiverModel>> GetAllRiver()
        {
            return (await _service.GetAllRiverAsync());
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<RiverModel?> GetRiverById(int Id)
        {
            return await _service.GetRiverByIdAsync(Id);
        }

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult<Rivers>> SaveRiver(RiverModel moddel)
        {
            var res = await _service.SaveRiverAsync(moddel);
            if (res == true)
            {
                return Ok(new { message = "Dữ liệu đã được lưu", id = res });
            }
            else
            {
                return BadRequest(new { message = "Lỗi lưu dữ liệu" });
            }
        }

        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult<Rivers>> DeleteRiver(RiverModel moddel)
        {
            var res = await _service.DeleteRiverAsync(moddel);
            if (res == true)
            {
                return Ok(new { message = "River: Dữ liệu đã được xóa" });
            }
            else
            {
                return Ok(new { message = "River: Lỗi xóa dữ liệu" });
            }
        }
    }
}
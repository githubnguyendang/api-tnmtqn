﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using new_wr_api.Data;
using new_wr_api.Models;
using new_wr_api.Service;

namespace new_wr_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class ConstructionController : ControllerBase
    {
        private readonly ConstructionService _service;

        public ConstructionController(ConstructionService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("list")]
        public async Task<List<ConstructionModel>> GetAllConstruction()
        {
            return (await _service.GetAllConstructionAsync());
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<ConstructionModel?> GetConstructionById(int Id)
        {
            return await _service.GetConstructionByIdAsync(Id);
        }

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult<Constructions>> SaveConstruction(ConstructionModel moddel)
        {
            var res = await _service.SaveConstructionAsync(moddel);
            if (res == true)
            {
                return Ok(new { message = "Construction: Dữ liệu đã được lưu" });
            }
            else
            {
                return BadRequest(new { message = "Construction: Lỗi lưu dữ liệu" });
            }
        }

        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult<Constructions>> DeleteConstruction(ConstructionModel moddel)
        {
            var res = await _service.DeleteConstructionAsync(moddel);
            if (res == true)
            {
                return Ok(new { message = "Construction: Dữ liệu đã được xóa" });
            }
            else
            {
                return Ok(new { message = "Construction: Lỗi xóa dữ liệu" });
            }
        }
    }
}
﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using new_wr_api.Data;
using new_wr_api.Dto;
using new_wr_api.Service;

namespace new_wr_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BieuMauSoMuoiController : ControllerBase
    {
        private readonly BieuMauMuoiService _service;

        public BieuMauSoMuoiController(BieuMauMuoiService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danhsach")]
        public async Task<List<BieuMauMuoiDto>> GetAll()
        {
            return await _service.GetAllBieuMauMuoiAsync();
        }
    }
}
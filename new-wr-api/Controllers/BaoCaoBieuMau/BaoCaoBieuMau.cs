using Microsoft.AspNetCore.Mvc;
using new_wr_api.Dto;
using new_wr_api.Service;

namespace new_wr_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BaoCaoBieuMauController : ControllerBase
    {
        private readonly BieuMauMuoiService _bm10;
        private readonly BieuMauMuoiMotService _bm11;
        private readonly BieuMauMuoiHaiService _bm12;
        private readonly BieuMauMuoiBaService _bm13;

        public BaoCaoBieuMauController(BieuMauMuoiService bm10, BieuMauMuoiMotService bm11, BieuMauMuoiHaiService bm12, BieuMauMuoiBaService bm13)
        {
            _bm10 = bm10;
            _bm11 = bm11;
            _bm12 = bm12;
            _bm13 = bm13;
        }

        [HttpGet]
        [Route("so10")]
        public async Task<List<BieuMauMuoiDto>> BieuMau10()
        {
            return await _bm10.GetAllAsync();
        }

        [HttpGet]
        [Route("so11")]
        public async Task<List<BieuMauMuoiMotDto>> BieuMau11()
        {
            return await _bm11.GetAllAsync();
        }

        [HttpGet]
        [Route("so12")]
        public async Task<List<BieuMauMuoiHaiDto>> BieuMau12()
        {
            return await _bm12.GetAllAsync();
        }

        [HttpGet]
        [Route("so13")]
        public async Task<List<BieuMauMuoiBaDto>> BieuMau13([FromQuery] int nam)
        {
            return await _bm13.GetAllAsync(nam);
        }
    }
}
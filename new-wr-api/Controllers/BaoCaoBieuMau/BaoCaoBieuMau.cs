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
        private readonly BieuMauMuoiHaiService _bm12;

        public BaoCaoBieuMauController(BieuMauMuoiService bm10, BieuMauMuoiHaiService bm12)
        {
            _bm10 = bm10;
            _bm12 = bm12;
        }

        [HttpGet]
        [Route("so10")]
        public async Task<List<BieuMauMuoiDto>> BieuMau10()
        {
            return await _bm10.GetAllAsync();
        }

        [HttpGet]
        [Route("so11")]
        public async Task<List<BieuMauMuoiDto>> BieuMau11()
        {
            return await _bm10.GetAllAsync();
        }

        [HttpGet]
        [Route("so12")]
        public async Task<List<BieuMauMuoiHaiDto>> BieuMau12()
        {
            return await _bm12.GetAllAsync();
        }
    }
}
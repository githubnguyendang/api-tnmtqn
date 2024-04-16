using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using new_wr_api.Data;
using new_wr_api.Dto;
using new_wr_api.Service;
using new_wr_api.Service.BaoCaoBieuMau;

namespace new_wr_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BieuMauSoHaiMuoiController : ControllerBase
    {
        private readonly BieuMauHaiMuoiService _service;

        public BieuMauSoHaiMuoiController(BieuMauHaiMuoiService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danhsach")]
        public async Task<List<CT_ThongTinDto>> GetAll()
        {
            return await _service.GetAllAsync();
        }

    }
}
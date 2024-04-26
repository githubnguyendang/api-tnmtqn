using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using new_wr_api.Data;
using new_wr_api.Dto;
using new_wr_api.Service;

namespace new_wr_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BaoCaoBieuMauController : ControllerBase
    {
        private readonly BieuMauMuoiService _service;

        public BaoCaoBieuMauController(BieuMauMuoiService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("so10")]
        public async Task<List<BieuMauMuoiDto>> GetAll()
        {
            return await _service.GetAllBieuMauMuoiAsync();
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using new_wr_api.Data;
using new_wr_api.Dto;

using new_wr_api.Service;

namespace new_wr_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class NM_KhaiThacSuDungController : ControllerBase
    {
        private readonly NM_KhaiThacSuDungService _service;

        public NM_KhaiThacSuDungController(NM_KhaiThacSuDungService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<KKTNN_NuocMat_KhaiThacSuDungDto>> GetAll()
        {
            return (await _service.GetAllAsync());
        }
    }
}

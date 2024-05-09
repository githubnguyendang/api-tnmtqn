using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using new_wr_api.Data;
using new_wr_api.Dto;

namespace new_wr_api.Service
{
    public class NM_KhaiThacSuDungService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public NM_KhaiThacSuDungService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<List<KKTNN_NuocMat_KhaiThacSuDungDto>> GetAllAsync()
        {
            // Retrieve data from the database asynchronously
            var items = await _context.CT_ThongTin!
                .Where(d => d.DaXoa == false)
                //.Include(d => d.Xa)
                //.Include(d => d.Huyen)
                .Include(d => d.LoaiCT)
                .Include(d => d.ThongSo)
                .Include(d => d.MucDichKTSD)
                .Include(d => d.LuuLuongTheoMucDich)
                .ToListAsync();

            // Filter and categorize the retrieved data
            var hochua_dapdang = items
                .Where(c => c.LoaiCT!.Id == 4 && c.ThongSo != null && c.ThongSo.DungTichToanBo != null && c.ThongSo.DungTichToanBo >= 0.01);

            var sxnn_ntts = items
                .Where(c => c.LoaiCT != null && new List<int> { 5, 6 }.Contains(c.LoaiCT.Id)
                            && c.MucDichKTSD != null && new List<int> { 4, 5 }.Contains(c.MucDichKTSD.Id)
                            && c.ThongSo!.QMaxKT > 0.1);

            var kddv_sxpnn = items
                .Where(c => c.LoaiCT != null && new List<int> { 4, 5, 6 }.Contains(c.LoaiCT.Id)
                            && c.MucDichKTSD != null && new List<int> { 2, 3 }.Contains(c.MucDichKTSD.Id)
                            && c.ThongSo!.QKhaiThac > 0.00116 && c.ThongSo.CongSuatLM > 50);

            // Combine filtered data from different categories
            var newData = hochua_dapdang.Concat(sxnn_ntts).Concat(kddv_sxpnn).ToList();

            // Map filtered data to DTOs
            var dtos = _mapper.Map<List<KKTNN_NuocMat_KhaiThacSuDungDto>>(newData);

            // Set additional property for each DTO
            foreach (var dto in dtos)
            {
                dto.tinh = "Quảng Ngãi";
            }

            return dtos;
        }
    }
}

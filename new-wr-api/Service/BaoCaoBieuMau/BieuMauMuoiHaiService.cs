using AutoMapper;
using Microsoft.EntityFrameworkCore;
using new_wr_api.Data;
using new_wr_api.Dto;

namespace new_wr_api.Service
{
    public class BieuMauMuoiHaiService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauMuoiHaiService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BieuMauMuoiHaiDto>> GetAllAsync()
        {
            var validLoaiCTIds = new HashSet<int?> { 4, 5, 6, 7, 11, 12, 13, 14, 15 };
            var nuocMatKhacIds = new HashSet<int?> { 5, 6, 11, 12, 13, 14, 15 };

            var result = await _context.LuuVucSong!
                 .Where(lvs => lvs.Id > 0)
                 .Select(lvs => new BieuMauMuoiHaiDto
                 {
                     Id = lvs.Id,
                     TenLVS = lvs.TenLVS,
                     TongCongTrinh = lvs.CongTrinh!.Count(ct => validLoaiCTIds.Contains(ct.IdLoaiCT) && ct.MucDichKT != null),
                     TuoiNguonNuocMat = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 5 && ct.MucDichKT!.ToLower().Contains("tưới")).Count(),
                     TuoiNguonNuocDuoiDat = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 7 && ct.MucDichKT!.ToLower().Contains("tưới")).Count(),
                     KhaiThacThuyDien = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 4).Sum(ct => ct.ThongSo != null ? ct.ThongSo.CongSuatLM : 0),
                     MucDichKhacNguonNuocMat = lvs.CongTrinh!.Where(ct => nuocMatKhacIds.Contains(ct.IdLoaiCT) && ct.MucDichKT != null && !ct.MucDichKT.ToLower().Contains("tưới")).Count(),
                     MucDichKhacNguonNuocDD = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 7 && ct.MucDichKT != null && !ct.MucDichKT!.ToLower().Contains("tưới")).Count(),
                 })
                 .ToListAsync();

            return result;
        }
    }
}


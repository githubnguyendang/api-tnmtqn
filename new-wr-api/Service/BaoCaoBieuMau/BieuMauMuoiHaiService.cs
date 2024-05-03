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
            var validLoaiCTIds = new HashSet<int?> { 5, 7 };

            var result = await _context.LuuVucSong!
                 .Where(lvs => lvs.Id > 0)
                 .Select(lvs => new BieuMauMuoiHaiDto
                 {
                     Id = lvs.Id,
                     TenLVS = lvs.TenLVS,
                     TongCongTrinh = lvs.CongTrinh!.Count(ct => validLoaiCTIds.Contains(ct.IdLoaiCT) && ct.MucDichKT != null),
                     TuoiNguonNuocMat = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 5 && ct.MucDichKT!.ToLower().Contains("tưới")).Sum(ct => ct.ThongSo != null ? ct.ThongSo.QKTLonNhat : 0),
                     TuoiNguonNuocDuoiDat = 0,
                     KhaiThacThuyDien = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 4).Sum(ct => ct.ThongSo != null ? ct.ThongSo.CongSuatLM : 0),
                     MucDichKhacNguonNuocMat = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 5 && ct.MucDichKT != null && !ct.MucDichKT.ToLower().Contains("tưới")).Sum(ct => ct.ThongSo != null ? ct.ThongSo.QKTLonNhat : 0) * 86400,
                     MucDichKhacNguonNuocDD = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 7 && ct.MucDichKT != null).Sum(ct => ct.ThongSo != null ? ct.ThongSo.QKTLonNhat : 0) * 86400,
                 })
                 .ToListAsync();

            return result;
        }
    }
}


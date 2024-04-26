using AutoMapper;
using Microsoft.EntityFrameworkCore;
using new_wr_api.Data;
using new_wr_api.Dto;

namespace new_wr_api.Service
{
    public class BieuMauMuoiMotService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauMuoiMotService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BieuMauMuoiMotDto>> GetAllAsync()
        {
            var result = await _context.LuuVucSong!
                 .Where(lvs => lvs.Id > 0)
                 .Select(lvs => new BieuMauMuoiMotDto
                 {
                     Id = lvs.Id,
                     LuuVucSong = lvs.TenLVS,
                     TongSoCongTrinh = 0 + lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 5).Count()
                           + lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 11).Count()
                           + lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 12).Count()
                           + lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 6).Count()
                           + lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 14).Count()
                           + lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 7).Count()
                           + lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 15).Count(),
                     CongTrinhHoChua = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 5).Count(),
                     CongTrinhDapDang = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 11).Count(),
                     CongTrinhCong = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 12).Count(),
                     CongTrinhTramBom = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 6).Count(),
                     CongTrinhKhacNuocMat = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 14).Count(),
                     CongTrinhGieng = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 7).Count(),
                     CongTrinhKhacNDD = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 15).Count(),
                 })
                 .ToListAsync();

            return result;
        }

    }
}


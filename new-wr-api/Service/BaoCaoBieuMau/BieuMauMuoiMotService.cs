using AutoMapper;
using Microsoft.EntityFrameworkCore;
using new_wr_api.Data;
using new_wr_api.Dto;
using System.Collections.Generic;
using System.Linq;

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
            var ids = new HashSet<int?> { 5, 11, 12, 6, 14, 7, 15 };

            var items = await _context.LuuVucSong!
                 .Where(lvs => lvs.Id > 0)
                 .Select(lvs => new BieuMauMuoiMotDto
                 {
                     Id = lvs.Id,
                     LuuVucSong = lvs.TenLVS,
                     TongSoCongTrinh = lvs.CongTrinh!.Where(ct => ids.Contains(ct.IdLoaiCT)).Count(),
                     CongTrinhHoChua = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 5).Count(),
                     CongTrinhDapDang = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 11).Count(),
                     CongTrinhCong = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 12).Count(),
                     CongTrinhTramBom = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 6).Count(),
                     CongTrinhKhacNuocMat = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 14).Count(),
                     CongTrinhGieng = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 7).Count(),
                     CongTrinhKhacNDD = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 15).Count(),
                 })
                 .ToListAsync();

            // Calculate total for summary row
            var total = new BieuMauMuoiMotDto
            {
                Id = -1,
                LuuVucSong = "Tổng",
                TongSoCongTrinh = items.Sum(item => item.TongSoCongTrinh),
                CongTrinhHoChua = items.Sum(item => item.CongTrinhHoChua),
                CongTrinhDapDang = items.Sum(item => item.CongTrinhDapDang),
                CongTrinhCong = items.Sum(item => item.CongTrinhCong),
                CongTrinhTramBom = items.Sum(item => item.CongTrinhTramBom),
                CongTrinhKhacNuocMat = items.Sum(item => item.CongTrinhKhacNuocMat),
                CongTrinhGieng = items.Sum(item => item.CongTrinhGieng),
                CongTrinhKhacNDD = items.Sum(item => item.CongTrinhKhacNDD)
            };

            // Adding the total DTO to the items list
            items.Add(total);

            // Order items by Id, with total as the last item added manually
            return items.OrderBy(item => item.Id).ToList();
        }

    }
}


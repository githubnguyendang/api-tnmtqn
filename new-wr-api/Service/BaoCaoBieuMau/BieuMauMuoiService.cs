using AutoMapper;
using Microsoft.EntityFrameworkCore;
using new_wr_api.Data;
using new_wr_api.Dto;

namespace new_wr_api.Service
{
    public class BieuMauMuoiService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauMuoiService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BieuMauMuoiDto>> GetAllAsync()
        {
            var validLoaiCTIds = new HashSet<int?> { 4, 5, 7 };

            var items = await _context.LuuVucSong!
                 .Where(lvs => lvs.Id > 0)
                 .Select(lvs => new BieuMauMuoiDto
                 {
                     Id = lvs.Id,
                     TenLVS = lvs.TenLVS,
                     TongCongTrinh = lvs.CongTrinh!.Count(ct => validLoaiCTIds.Contains(ct.IdLoaiCT) && ct.MucDichKT != null),
                     CTTuoiNuocMat = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 5).Count(),
                     CTTuoiNuocDuoiDat = 0,
                     CTThuyDien = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 4).Count(),
                     CTMucDichKhacNuocMat = lvs.CongTrinh!.Where(ct => ct.LoaiCT!.IdCha == 3 && ct.IdLoaiCT != 5 && ct.MucDichKT == null || !ct.MucDichKT!.ToLower().Contains("tưới")).Count(),
                     CTMucDichKhacNuocDuoiDat = lvs.CongTrinh!.Where(ct => ct.IdLoaiCT == 7).Count(),
                 })
                 .ToListAsync();

            // Calculate total for summary row
            var total = new BieuMauMuoiDto
            {
                Id = -1,
                TenLVS = "Tổng",
                TongCongTrinh = items.Sum(item => item.TongCongTrinh),
                CTTuoiNuocMat = items.Sum(item => item.CTTuoiNuocMat),
                CTTuoiNuocDuoiDat = 0,
                CTThuyDien = items.Sum(item => item.CTThuyDien),
                CTMucDichKhacNuocMat = items.Sum(item => item.CTMucDichKhacNuocMat),
                CTMucDichKhacNuocDuoiDat = items.Sum(item => item.CTMucDichKhacNuocDuoiDat)
            };

            // Adding the total DTO to the items list
            items.Add(total);

            // Order items by Id, with total as the last item added manually
            return items.OrderBy(item => item.Id).ToList();
        }
    }
}


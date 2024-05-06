﻿using AutoMapper;
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
            var validLoaiCTIds = new HashSet<int?> { 4, 5, 7 };

            var items = await _context.LuuVucSong!
                 .Where(lvs => lvs.Id > 0)
                 .Select(lvs => new BieuMauMuoiHaiDto
                 {
                     Id = lvs.Id,
                     TenLVS = lvs.TenLVS,
                     TongCongTrinh = lvs.CongTrinh!
                                    .Count(ct => validLoaiCTIds
                                    .Contains(ct.IdLoaiCT) && ct.MucDichKT != null),
                     TuoiNguonNuocMat = Math.Round((double)(lvs.CongTrinh!
                                        .Where(ct => ct.IdLoaiCT == 5)
                                        .SelectMany(ct => ct.LuuLuongTheoMucDich!)
                                        .Where(lld => lld.IdMucDich == 5)
                                        .Sum(lld => lld.LuuLuong) / 86400), 2), //convert m3/day to m3/s
                     TuoiNguonNuocDuoiDat = 0,
                     KhaiThacThuyDien = Math.Round((double)lvs.CongTrinh!
                                         .Where(ct => ct.IdLoaiCT == 4)
                                         .Sum(ct => ct.ThongSo != null ? ct.ThongSo.CongSuatLM : 0), 2),
                     MucDichKhacNguonNuocMat = Math.Round((double)lvs.CongTrinh!
                                        .Where(ct => ct.IdLoaiCT == 5)
                                        .SelectMany(ct => ct.LuuLuongTheoMucDich!)
                                        .Where(lld => lld.IdMucDich != 5)
                                        .Sum(lld => lld.LuuLuong), 2),
                     MucDichKhacNguonNuocDD = Math.Round((double)lvs.CongTrinh!
                                        .Where(ct => ct.IdLoaiCT == 7)
                                        .Sum(ct => ct.ThongSo.QKTLonNhat), 2),
                 })
                 .ToListAsync();

            // Calculate total for summary row
            var total = new BieuMauMuoiHaiDto
            {
                Id = -1,
                TenLVS = "Tổng",
                TongCongTrinh = items.Sum(item => item.TongCongTrinh),
                TuoiNguonNuocMat = items.Sum(item => item.TuoiNguonNuocMat),
                TuoiNguonNuocDuoiDat = 0,
                KhaiThacThuyDien = items.Sum(item => item.KhaiThacThuyDien),
                MucDichKhacNguonNuocMat = items.Sum(item => item.MucDichKhacNguonNuocMat),
                MucDichKhacNguonNuocDD = items.Sum(item => item.MucDichKhacNguonNuocDD)
            };

            // Adding the total DTO to the items list
            items.Add(total);

            // Order items by Id, with total as the last item added manually
            return items.OrderBy(item => item.Id).ToList();
        }
    }
}


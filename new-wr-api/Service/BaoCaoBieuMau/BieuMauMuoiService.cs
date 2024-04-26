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
        public async Task<List<BieuMauMuoiDto>> GetAllBieuMauMuoiAsync()
        {
            var result = await _context.LuuVucSong!
                 .Where(lvs => lvs.Id > 0)
                 .Select(lvs => new BieuMauMuoiDto
                 {
                     Id = lvs.Id,
                     TenLVS = lvs.TenLVS,
                     TongCongTrinh = lvs.CongTrinh!.Count,
                     CTTuoiNuocMat = 0,
                     CTTuoiNuocDuoiDat = 0,
                     CTThuyDien = lvs.CongTrinh.Where(ct => ct.IdLoaiCT == 4).Count(),
                     CTMucDichKhacNuocMat = 0,
                     CTMucDichKhacNuocDuoiDat = 0,
                 })
                 .ToListAsync();

            return result;
        }

        public async Task<bool> SaveBieuMauMuoiAsync(BieuMauMuoiDto dto)
        {
            var exitsItem = await _context!.BieuMauSoMuoi!.FindAsync(dto.Id);

            if (exitsItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<BieuMauSoMuoi>(dto);

                _context.BieuMauSoMuoi!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.BieuMauSoMuoi!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                _context.BieuMauSoMuoi!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteBieuMauMuoiAsync(int Id)
        {
            var exitsItem = await _context!.BieuMauSoMuoi!.FirstOrDefaultAsync(d => d.Id == Id);

            if (exitsItem == null) { return false; }

            _context.BieuMauSoMuoi?.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}


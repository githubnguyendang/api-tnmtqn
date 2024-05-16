using AutoMapper;
using Microsoft.EntityFrameworkCore;
using new_wr_api.Data;
using new_wr_api.Dto;

namespace new_wr_api.Service
{
    public class BieuMauNamService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauNamService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BieuMauNamDto>> GetAllBieuMauNamAsync(int? nam)
        {
            var items = await _context.BieuMauSoNam!.Where(x => x.Id > 0 && x.Nam == nam).ToListAsync();
            return _mapper.Map<List<BieuMauNamDto>>(items);
        }

        public async Task<bool> SaveBieuMauNamAsync(BieuMauNamDto dto)
        {
            var exitsItem = await _context!.BieuMauSoNam!.FindAsync(dto.Id);

            if (exitsItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<BieuMauSoNam>(dto);

                _context.BieuMauSoNam!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.BieuMauSoNam!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                _context.BieuMauSoNam!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteBieuMauNamAsync(int Id)
        {
            var exitsItem = await _context!.BieuMauSoNam!.FirstOrDefaultAsync(d => d.Id == Id);

            if (exitsItem == null) { return false; }

            _context.BieuMauSoNam?.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}


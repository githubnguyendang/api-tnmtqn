using AutoMapper;
using Microsoft.EntityFrameworkCore;
using new_wr_api.Data;
using new_wr_api.Dto;

namespace new_wr_api.Service
{
    public class BieuMauBaService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauBaService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BieuMauBaDto>> GetAllBieuMauBaAsync()
        {
            var items = await _context.BieuMauSoBa!.Where(x => x.Id > 0).ToListAsync();
            return _mapper.Map<List<BieuMauBaDto>>(items);
        }

        public async Task<bool> SaveBieuMauBaAsync(BieuMauBaDto dto)
        {
            var exitsItem = await _context!.BieuMauSoBa!.FindAsync(dto.Id);

            if (exitsItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<BieuMauSoBa>(dto);

                _context.BieuMauSoBa!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.BieuMauSoBa!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                _context.BieuMauSoBa!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteBieuMauBaAsync(int Id)
        {
            var exitsItem = await _context!.BieuMauSoBa!.FirstOrDefaultAsync(d => d.Id == Id);

            if (exitsItem == null) { return false; }

            _context.BieuMauSoBa?.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}


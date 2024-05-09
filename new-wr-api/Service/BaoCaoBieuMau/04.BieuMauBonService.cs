using AutoMapper;
using Microsoft.EntityFrameworkCore;
using new_wr_api.Data;
using new_wr_api.Dto;

namespace new_wr_api.Service
{
    public class BieuMauBonService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauBonService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BieuMauBonDto>> GetAllBieuMauBonAsync()
        {
            var items = await _context.BieuMauSoBon!.Where(x => x.Id > 0).ToListAsync();
            return _mapper.Map<List<BieuMauBonDto>>(items);
        }

        public async Task<bool> SaveBieuMauBonAsync(BieuMauBonDto dto)
        {
            var exitsItem = await _context!.BieuMauSoBon!.FindAsync(dto.Id);

            if (exitsItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<BieuMauSoBon>(dto);

                _context.BieuMauSoBon!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.BieuMauSoBon!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                _context.BieuMauSoBon!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteBieuMauBonAsync(int Id)
        {
            var exitsItem = await _context!.BieuMauSoBon!.FirstOrDefaultAsync(d => d.Id == Id);

            if (exitsItem == null) { return false; }

            _context.BieuMauSoBon?.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}


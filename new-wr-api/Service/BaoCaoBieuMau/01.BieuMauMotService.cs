using AutoMapper;
using Microsoft.EntityFrameworkCore;
using new_wr_api.Data;
using new_wr_api.Dto;

namespace new_wr_api.Service
{
    public class BieuMauMotService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauMotService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BieuMauMotDto>> GetAllBieuMauMotAsync()
        {
            var items = await _context.BieuMauSoMot!.Where(x => x.Id > 0).ToListAsync();
            return _mapper.Map<List<BieuMauMotDto>>(items);
        }

        public async Task<bool> SaveBieuMauMotAsync(BieuMauMotDto dto)
        {
            var exitsItem = await _context!.BieuMauSoMot!.FindAsync(dto.Id);

            if (exitsItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<BieuMauSoMot>(dto);

                _context.BieuMauSoMot!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.BieuMauSoMot!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                _context.BieuMauSoMot!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteBieuMauMotAsync(int Id)
        {
            var exitsItem = await _context!.BieuMauSoMot!.FirstOrDefaultAsync(d => d.Id == Id);

            if (exitsItem == null) { return false; }

            _context.BieuMauSoMot?.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}


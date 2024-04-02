using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using new_wr_api.Data;
using new_wr_api.Dto;

using System.Security.Claims;

namespace new_wr_api.Service
{
    public class NDD_SoLuongService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public NDD_SoLuongService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<List<KKTNN_NuocDuoiDat_SoLuongDto>> GetAllAsync()
        {
            var items = await _context.KKTNN_NuocDuoiDat_SoLuong!.Where(d => d.DaXoa == false)
                .Include(d => d.TangChuaNuoc)
                .OrderBy(d => d.Id)
                .AsQueryable().ToListAsync();

            return _mapper.Map<List<KKTNN_NuocDuoiDat_SoLuongDto>>(items);

        }

        //public async Task<bool> SaveAsync(KKTNN_NuocDuoiDat_SoLuongDto dto)
        //{

        //    var existingItem = await _context.KKTNN_NuocDuoiDat_SoLuong!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

        //    if (existingItem == null || dto.Id == 0)
        //    {
        //        var newItem = _mapper.Map<KKTNN_NuocDuoiDat_SoLuong>(dto);
        //        newItem.DaXoa = false;
        //        _context.KKTNN_NuocDuoiDat_SoLuong!.Add(newItem);
        //    }
        //    else
        //    {
        //        var updateItem = await _context.KKTNN_NuocDuoiDat_SoLuong!.FirstOrDefaultAsync(d => d.Id == dto.Id);

        //        updateItem = _mapper.Map(dto, updateItem);

        //        _context.KKTNN_NuocDuoiDat_SoLuong!.Update(updateItem);
        //    }

        //    var res = await _context.SaveChangesAsync();

        //    return true;
        //}


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.KKTNN_NuocDuoiDat_SoLuong!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.KKTNN_NuocDuoiDat_SoLuong!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using new_wr_api.Data;
using new_wr_api.Dto;

using System.Net.WebSockets;
using System.Security.Claims;

namespace new_wr_api.Service
{
    public class DuLieuTramService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public DuLieuTramService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }
        public async Task<List<DuLieuTramDto>> GetAllDuLieuTramAsync()
        {
            var items = await _context.DuLieuTram!.Where(d => d.Id >0).OrderByDescending(d => d.ThoiGian).Take(31).OrderByDescending(d => d.ThoiGian)
                .OrderBy(d => d.Id)
                .AsQueryable().ToListAsync();

            var tqnDto = _mapper.Map<List<DuLieuTramDto>>(items);

            return tqnDto;
        }
        public async Task<List<ApexChartSeriesTramDto>> DuLieuTramAsync()
        {
            var items = await _context.DuLieuTram!.Where(d => d.Id > 0).OrderByDescending(d => d.ThoiGian).Take(31).OrderByDescending(d => d.ThoiGian)
                .OrderBy(d => d.Id)
                .AsQueryable().ToListAsync();

            var seriesList = new List<ApexChartSeriesTramDto>();

            seriesList.Add(new ApexChartSeriesTramDto
            {
                name = "Lượng mưa",
                data = items.Select(x => x.LuongMua ?? 0.0).ToList() 
            });
            seriesList.Add(new ApexChartSeriesTramDto
            {
                name = "Nhiệt độ",
                data = items.Select(x => x.NhietDo ?? 0.0).ToList()
            });
            seriesList.Add(new ApexChartSeriesTramDto
            {
                name = "Độ ẩm",
                data = items.Select(x => x.DoAm ?? 0.0).ToList()
            });
            return seriesList;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.DuLieuTram!.FirstOrDefaultAsync(d => d.Id == Id);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.DuLieuTram!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using new_wr_api.Data;
using new_wr_api.Dto;
using new_wr_api.Models;
using System.Net.WebSockets;
using System.Security.Claims;

namespace new_wr_api.Service
{
    public class TramQuangNgaiService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public TramQuangNgaiService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }
        public async Task<List<TramQuangNgaiDto>> GetAllTramQuangNgaiAsync()
        {
            var items = await _context.TramQuangNgai!.Where(d => d.Id >0).OrderByDescending(d => d.ThoiGian).Take(31).OrderByDescending(d => d.ThoiGian)
                .OrderBy(d => d.Id)
                .AsQueryable().ToListAsync();

            var tqnDto = _mapper.Map<List<TramQuangNgaiDto>>(items);

            return tqnDto;
        }
        public async Task<bool> SaveAsync(TramQuangNgaiDto dto)
        {

            var existingItem = await _context.TramQuangNgai!.FirstOrDefaultAsync(d => d.Id == dto.Id);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<TramQuangNgai>(dto);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.TramQuangNgai!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.TramQuangNgai!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.TramQuangNgai!.Update(updateItem);
            }

            var res = await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<ApexChartSeriesTramDto>> TramQuangNgaiAsync()
        {
            var items = await _context.TramQuangNgai!.Where(d => d.Id > 0).OrderByDescending(d => d.ThoiGian).Take(31).OrderByDescending(d => d.ThoiGian)
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
            var existingItem = await _context.TramQuangNgai!.FirstOrDefaultAsync(d => d.Id == Id);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.TramQuangNgai!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

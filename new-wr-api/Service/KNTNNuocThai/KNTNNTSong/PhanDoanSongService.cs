using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using new_wr_api.Data;
using new_wr_api.Dto;
using System.Security.Claims;
using static new_wr_api.Dto.PhanDoanSongDto;

namespace new_wr_api.Service
{
    public class PhanDoanSongService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public PhanDoanSongService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<List<PhanDoanSongDto>> GetAllAsync()
        {
            var items = await _context.PhanDoanSong!
                .ToListAsync();
            return _mapper.Map<List<PhanDoanSongDto>>(items);
        }

        public async Task<List<PhanDoanSongDto>> GetDataCaculatePolutantAsync()
        {
            var items = await _context.PhanDoanSong!
                .Include(x => x.DuLieuNguonNuocNhan)
                .Include(p => p.DuLieuNguonNuocThaiDiem)
                .Include(p => p.DuLieuNguonNuocThaiSinhHoat)
                .Include(p => p.DuLieuNguonNuocThaiGiaCam)
                .Include(p => p.DuLieuNguonNuocThaiLon)
                .Include(p => p.DuLieuNguonNuocThaiTrauBo)
                .Include(p => p.DuLieuNguonNuocThaiTrongCay)
                .Include(p => p.DuLieuNguonNuocThaiTrongLua)
                .Include(p => p.DuLieuNguonNuocThaiTrongRung)
                .Include(p => p.DuLieuNguonNuocThaiThuySan)
                .Where(p => p.DuLieuNguonNuocNhan != null)
                .ToListAsync();

            var pdsDtos = _mapper.Map<List<PhanDoanSongDto>>(items);

            foreach (var dto in pdsDtos)
            {
                //dto.DuLieuNguonNuocNhan!.PhanDoanSong = null;
                dto.DuLieuNguonNuocThaiDiem = null;
                dto.DuLieuNguonNuocThaiSinhHoat = null;
                dto.DuLieuNguonNuocThaiGiaCam = null;
                dto.DuLieuNguonNuocThaiLon = null;
                dto.DuLieuNguonNuocThaiTrauBo = null;
                dto.DuLieuNguonNuocThaiTrongCay = null;
                dto.DuLieuNguonNuocThaiTrongLua = null;
                dto.DuLieuNguonNuocThaiTrongRung = null;
                dto.DuLieuNguonNuocThaiThuySan = null;
            }

            return pdsDtos;
        }
        public async Task<PhanDoanSongDto?> GetByIdAsync(int Id)
        {
            var item = await _context.PhanDoanSong!.FindAsync(Id);
            return _mapper.Map<PhanDoanSongDto>(item);
        }


        public async Task<bool> SaveAsync(PhanDoanSongDto dto)
        {
            var existingItem = await _context.PhanDoanSong!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<PhanDoanSong>(dto);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.PhanDoanSong!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.PhanDoanSong!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

                updateItem = _mapper.Map(dto, updateItem);
                updateItem!.DaXoa = false;
                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.PhanDoanSong!.Update(updateItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.PhanDoanSong!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.PhanDoanSong!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

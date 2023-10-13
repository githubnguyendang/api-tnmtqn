﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using new_wr_api.Data;
using new_wr_api.Dto;
using System.Security.Claims;

namespace new_wr_api.Service
{
    public class SongService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public SongService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<List<SongDto>> GetAllAsync()
        {
            var items = await _context.Song!.Where(x => x.DaXoa == false).OrderBy(x => x.Name).ToListAsync();

            var listItems = _mapper.Map<List<SongDto>>(items);

            foreach (var item in listItems)
            {
                //Song.Basin
                var basin = await _context!.LuuVucSong!.FirstOrDefaultAsync(b => b.Id == item.IdLuuVuc && b.DaXoa == false);
                item.luuvuc_song = _mapper.Map<LuuVucSongDto>(basin);
                //Song.Location
                var donvi_hc = await _context!.DonViHC!.FirstOrDefaultAsync(l => l.IdXa == item.IdXa.ToString() && l.DaXoa == false);
                item.donvi_hc = _mapper.Map<DonViHCDto>(donvi_hc);
            }

            return listItems;
        }

        public async Task<SongDto?> GetByIdAsync(int Id)
        {
            var item = await _context.Song!.FindAsync(Id);
            return _mapper.Map<SongDto>(item);
        }


        public async Task<bool> SaveAsync(SongDto dto)
        {
            var existingItem = await _context.Song!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<Song>(dto);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.Song!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.Song!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

                updateItem = _mapper.Map(dto, updateItem);

                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.Song!.Update(updateItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.Song!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.Song!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

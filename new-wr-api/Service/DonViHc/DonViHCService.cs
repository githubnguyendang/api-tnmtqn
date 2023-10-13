﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using new_wr_api.Data;
using new_wr_api.Dto;
using System.Security.Claims;

namespace new_wr_api.Service
{
    public class DonViHCService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public DonViHCService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<List<DonViHCDto>> GetAllAsync()
        {
            var items = await _context!.DonViHC!
                .Where(x => x.DaXoa == false)
                .OrderBy(x => x.TenHuyen)
                .ToListAsync();

            var listItems = _mapper.Map<List<DonViHCDto>>(items);
            return listItems;
        }

        public async Task<List<HuyenDto>> GetAllDistrictAsync(string IdTinh)
        {
            var items = await _context.DonViHC!
                .Where(l => l.IdTinh == IdTinh && l.DaXoa == false)
                .GroupBy(l => new { l.IdTinh, l.IdHuyen })
                .Select(group => group.First())
                .ToListAsync();

            var listItems = _mapper.Map<List<HuyenDto>>(items);
            return listItems;
        }

        public async Task<List<XaDto>> GetAllCommuneAsync()
        {
            var items = await _context.DonViHC!
                .Where(l => l.IdXa != null && l.DaXoa == false)
                .GroupBy(l => new { l.IdHuyen, l.IdXa })
                .Select(group => group.First())
                .ToListAsync();

            var listItems = _mapper.Map<List<XaDto>>(items);
            return listItems;
        }

        public async Task<List<XaDto>> GetAllCommuneByDistrictAsync(string IdHuyen)
        {
            var items = await _context.DonViHC!
                .Where(l => l.IdHuyen == IdHuyen && l.DaXoa == false)
                .GroupBy(l => new { l.IdHuyen, l.IdXa })
                .Select(group => group.First())
                .ToListAsync();

            var listItems = _mapper.Map<List<XaDto>>(items);
            return listItems;
        }

        public async Task<DonViHCDto?> GetByIdAsync(int Id)
        {
            var item = await _context.DonViHC!.FindAsync(Id);
            return _mapper.Map<DonViHCDto>(item);
        }


        public async Task<bool> SaveAsync(DonViHCDto model)
        {
            var existingItem = await _context.DonViHC!.FirstOrDefaultAsync(d => d.Id == model.Id && d.DaXoa == false);

            if (existingItem == null || model.Id == 0)
            {
                var newItem = _mapper.Map<DonViHC>(model);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.DonViHC!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.DonViHC!.FirstOrDefaultAsync(d => d.Id == model.Id && d.DaXoa == false);

                updateItem = _mapper.Map(model, updateItem);

                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.DonViHC!.Update(updateItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.DonViHC!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.DonViHC!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

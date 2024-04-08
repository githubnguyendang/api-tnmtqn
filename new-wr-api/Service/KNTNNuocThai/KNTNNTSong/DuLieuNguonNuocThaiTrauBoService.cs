﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using new_wr_api.Data;
using new_wr_api.Dto;
using System.Security.Claims;

namespace new_wr_api.Service
{
    public class DuLieuNguonNuocThaiTrauBoService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;

        public DuLieuNguonNuocThaiTrauBoService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        public async Task<List<DuLieuNguonNuocThaiTrauBoDto>> GetAllAsync()
        {
            var query = _context.DuLieuNguonNuocThaiTrauBo!
                .Where(gp => gp.DaXoa == false)
                .Include(x => x.PhanDoanSong)
                .AsQueryable();

            // Apply filters based on input parameters
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            var listItems = _mapper.Map<List<DuLieuNguonNuocThaiTrauBoDto>>(query);

            return listItems;
        }

        public async Task<DuLieuNguonNuocThaiTrauBoDto?> GetByIdAsync(int Id)
        {
            var item = await _context.DuLieuNguonNuocThaiTrauBo!.FindAsync(Id);
            return _mapper.Map<DuLieuNguonNuocThaiTrauBoDto>(item);
        }


        public async Task<bool> SaveAsync(DuLieuNguonNuocThaiTrauBoDto dto)
        {
            var existingItem = await _context.DuLieuNguonNuocThaiTrauBo!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<DuLieuNguonNuocThaiTrauBo>(dto);
                newItem.DaXoa = false;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.DuLieuNguonNuocThaiTrauBo!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.DuLieuNguonNuocThaiTrauBo!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

                updateItem = _mapper.Map(dto, updateItem);
                updateItem!.DaXoa = false;
                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.DuLieuNguonNuocThaiTrauBo!.Update(updateItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.DuLieuNguonNuocThaiTrauBo!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.DuLieuNguonNuocThaiTrauBo!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

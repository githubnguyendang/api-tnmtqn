﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using new_wr_api.Data;
using new_wr_api.Dto;

using System.Security.Claims;

namespace new_wr_api.Service
{
    public class NN_VungCamHanCheKTNDDService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public NN_VungCamHanCheKTNDDService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }
        public async Task<List<NN_VungCamHanCheKTNDDDto>> GetAllVungCamHanCheKTNDDAsync()
        {
            var items = await _context.NN_VungCamHanCheKTNDD!.Where(d => d.DaXoa == false)
                .OrderBy(d => d.Id)
                .AsQueryable().ToListAsync();

            var ttdlDto = _mapper.Map<List<NN_VungCamHanCheKTNDDDto>>(items);

            return ttdlDto;
        }
        public async Task<bool> SaveAsync(NN_VungCamHanCheKTNDDDto dto)
        {

            var existingItem = await _context.NN_VungCamHanCheKTNDD!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<NN_VungCamHanCheKTNDD>(dto);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.NN_VungCamHanCheKTNDD!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.NN_VungCamHanCheKTNDD!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.NN_VungCamHanCheKTNDD!.Update(updateItem);
            }

            var res = await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.NN_VungCamHanCheKTNDD!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.NN_VungCamHanCheKTNDD!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

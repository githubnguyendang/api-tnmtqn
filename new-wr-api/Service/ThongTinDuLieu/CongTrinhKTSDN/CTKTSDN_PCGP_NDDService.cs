﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using new_wr_api.Data;
using new_wr_api.Dto;

using System.Security.Claims;

namespace new_wr_api.Service
{
    public class CTKTSDN_PCGP_NDDService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public CTKTSDN_PCGP_NDDService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }
        public async Task<List<CTKTSDN_PCGP_NDDDto>> GetAllCTKTSDN_PCGP_NDDAsync()
        {
            var items = await _context.CTKTSDN_PCGP_NDD!.Where(d => d.DaXoa == false)
                .OrderBy(d => d.Id)
                .AsQueryable().ToListAsync();

            var ttdlDto = _mapper.Map<List<CTKTSDN_PCGP_NDDDto>>(items);

            return ttdlDto;
        }
        public async Task<bool> SaveAsync(CTKTSDN_PCGP_NDDDto dto)
        {

            var existingItem = await _context.CTKTSDN_PCGP_NDD!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                var newItem = _mapper.Map<CTKTSDN_PCGP_NDD>(dto);
                newItem.DaXoa = false;
                newItem.ThoiGianTao = DateTime.Now;
                newItem.TaiKhoanTao = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.CTKTSDN_PCGP_NDD!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.CTKTSDN_PCGP_NDD!.FirstOrDefaultAsync(d => d.Id == dto.Id);

                updateItem = _mapper.Map(dto, updateItem);
                updateItem!.ThoiGianSua = DateTime.Now;
                updateItem.TaiKhoanSua = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.CTKTSDN_PCGP_NDD!.Update(updateItem);
            }

            var res = await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.CTKTSDN_PCGP_NDD!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.CTKTSDN_PCGP_NDD!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

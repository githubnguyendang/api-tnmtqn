﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using new_wr_api.Data;
using new_wr_api.Dto;
using new_wr_api.Models;
using System.Security.Claims;

namespace new_wr_api.Service
{
    public class TCQ_ThongTinService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;

        public TCQ_ThongTinService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        public async Task<List<TCQ_ThongTinDto>> GetAllAsync()
        {
            var items = await _context!.TCQ_ThongTin!
                .Where(u => u.DaXoa == false)
                .ToListAsync();

            var listItems = _mapper.Map<List<TCQ_ThongTinDto>>(items);

            return listItems;
        }

        public async Task<List<TCQ_ThongTinDto>> GetByLicensingAuthoritiesAsync(string coquan_cp)
        {
            var query = _context!.TCQ_ThongTin!
                .Where(u => u.DaXoa == false);

            if (coquan_cp == "bo-cap")
            {
                query = query.Where(u => u.CoQuanCP == "BTNMT");
            }
            else if (coquan_cp == "tinh-cap")
            {
                query = query.Where(u => u.CoQuanCP == "UBNDT");
            }

            var items = await query.ToListAsync();

            var listItems = _mapper.Map<List<TCQ_ThongTinDto>>(items);

            foreach (var item in listItems)
            {
                var qd_bosung = await _context!.TCQ_ThongTin!.FirstOrDefaultAsync(tcq => tcq.Id == item.IdCon && tcq.DaXoa == false);
                item.qd_bosung = _mapper.Map<TCQ_ThongTinDto>(qd_bosung);
            }

            return listItems;
        }

        public async Task<TCQ_ThongTinDto?> GetByIdAsync(int Id)
        {
            var item = await _context.TCQ_ThongTin!.FindAsync(Id);
            return _mapper.Map<TCQ_ThongTinDto>(item);
        }

        public async Task<int> SaveAsync(TCQ_ThongTinDto dto)
        {
            int id = 0;
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);
            TCQ_ThongTin? item = null; // Declare item variable

            var existingItem = await _context.TCQ_ThongTin!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                item = _mapper.Map<TCQ_ThongTin>(dto);
                item.DaXoa = false;
                item.ThoiGianTao = DateTime.Now;
                item.TaiKhoanTao = currentUser != null ? currentUser.UserName : null;

                _context.TCQ_ThongTin!.Add(item);
            }
            else
            {
                item = existingItem; // Assign existingItem to item

                _mapper.Map(dto, item); // Map properties from dto to item
                item.ThoiGianSua = DateTime.Now;
                item.TaiKhoanSua = currentUser != null ? currentUser.UserName : null;
                _context.TCQ_ThongTin!.Update(item);
            }

            var res = await _context.SaveChangesAsync();

            // Simplified assignment of id
            id = (int)(res > 0 ? item.Id : 0);

            return id;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.TCQ_ThongTin!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);

            if (existingItem == null) { return false; }

            existingItem!.DaXoa = true;
            _context.TCQ_ThongTin!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
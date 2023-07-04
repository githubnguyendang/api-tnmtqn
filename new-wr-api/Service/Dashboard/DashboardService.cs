﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using new_wr_api.Data;
using new_wr_api.Models;
using System.Security.Claims;

namespace new_wr_api.Service
{
    public class DashboardService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public DashboardService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<List<DashboardModel>> GetAllDashboardAsync()
        {
            var items = await _context.Dashboards!.Where(x => !x.IsDeleted).ToListAsync();
            return _mapper.Map<List<DashboardModel>>(items);
        }

        public async Task<DashboardModel?> GetDashboardByIdAsync(int Id)
        {
            var item = await _context.Dashboards!.FindAsync(Id);
            return _mapper.Map<DashboardModel>(item);
        }


        public async Task<IdentityResult> SaveDashboardAsync(DashboardModel model)
        {
            var existingItem = await _context.Dashboards!.FirstOrDefaultAsync(d => d.Id == model.Id);

            if (existingItem == null || model.Id == 0)
            {
                var newItem = _mapper.Map<Dashboards>(model);
                newItem.IsDeleted = false;
                newItem.Status = true;
                newItem.CreatedTime = DateTime.Now;
                newItem.CreatedUser = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.Dashboards!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.Dashboards!.FirstOrDefaultAsync(d => d.Id == model.Id);

                updateItem = _mapper.Map(model, updateItem);

                updateItem!.ModifiedTime = DateTime.Now;
                updateItem.ModifiedUser = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.Dashboards!.Update(updateItem);
            }

            await _context.SaveChangesAsync();
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteDashboardAsync(DashboardModel model)
        {
            var existingItem = await _context.Dashboards!.FirstOrDefaultAsync(d => d.Id == model.Id);

            existingItem!.IsDeleted = true;
            await _context.SaveChangesAsync();

            return IdentityResult.Success;
        }
    }
}

﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using new_wr_api.Data;
using new_wr_api.Models;
using System.Security.Claims;

namespace new_wr_api.Service
{
    public class LocationService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public LocationService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<List<LocationsModel>> GetAllLocationAsync()
        {
            var items = await _context!.Locations!
                .Where(x => x.IsDeleted == false)
                .OrderBy(x => x.DistrictName)
                .ToListAsync();

            var listItems = _mapper.Map<List<LocationsModel>>(items);
            return listItems;
        }

        public async Task<List<DistrictModel>> GetAllDistrictAsync(string CityId)
        {
            var items = await _context!.Locations!
                .Where(u => u.IsDeleted == false && u.CityId == CityId)
                .ToListAsync();

            var listItems = _mapper.Map<List<DistrictModel>>(items);
            return listItems;
        }

        public async Task<List<CommuneModel>> GetAllCommuneAsync(string DistrictId)
        {
            var items = await _context!.Locations!
                .Where(u => u.IsDeleted == false && u.DistrictId == DistrictId)
                .ToListAsync();

            var listItems = _mapper.Map<List<CommuneModel>>(items);
            return listItems;
        }

        public async Task<LocationsModel?> GetLocationByIdAsync(int Id)
        {
            var item = await _context.Locations!.FindAsync(Id);
            return _mapper.Map<LocationsModel>(item);
        }


        public async Task<bool> SaveLocationAsync(LocationsModel model)
        {
            var existingItem = await _context.Locations!.FirstOrDefaultAsync(d => d.Id == model.Id);

            if (existingItem == null || model.Id == 0)
            {
                var newItem = _mapper.Map<Locations>(model);
                newItem.IsDeleted = false;
                newItem.CreatedTime = DateTime.Now;
                newItem.CreatedByUser = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.Locations!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.Locations!.FirstOrDefaultAsync(d => d.Id == model.Id);

                updateItem = _mapper.Map(model, updateItem);

                updateItem!.ModifiedTime = DateTime.Now;
                updateItem.ModifiedByUser = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.Locations!.Update(updateItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteLocationAsync(LocationsModel modle)
        {
            var existingItem = await _context.Locations!.FirstOrDefaultAsync(d => d.Id == modle.Id);

            if (existingItem == null) { return false; }

            existingItem!.IsDeleted = true;
            _context.Locations!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

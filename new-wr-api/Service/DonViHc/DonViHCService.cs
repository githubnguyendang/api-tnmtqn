using AutoMapper;
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
        private readonly UserManager<AspNetUsers> _userManager;

        public DonViHCService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        public async Task<List<HuyenDto>> GetAllDistrictAsync()
        {
            var items = await _context.Huyen!
                .Where(l => l.DaXoa == false)
                .ToListAsync();

            var listItems = _mapper.Map<List<HuyenDto>>(items);
            return listItems;
        }

        public async Task<List<XaDto>> GetAllCommuneAsync()
        {
            var items = await _context.Xa!
                .Where(l => l.DaXoa == false)
                .ToListAsync();

            var listItems = _mapper.Map<List<XaDto>>(items);
            return listItems;
        }

        public async Task<List<XaDto>> GetAllCommuneByDistrictAsync(string IdHuyen)
        {
            var items = await _context.Xa!
                .Where(l => l.IdHuyen == IdHuyen && l.DaXoa == false)
                .ToListAsync();

            var listItems = _mapper.Map<List<XaDto>>(items);
            return listItems;
        }
    }
}

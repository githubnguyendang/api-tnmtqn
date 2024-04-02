using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using new_wr_api.Data;
using new_wr_api.Dto;

using System.Security.Claims;

namespace new_wr_api.Service
{
    public class TCQ_ThongTinService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;

        // Constructor to initialize the service with required dependencies
        public TCQ_ThongTinService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        // Method to get all TCQ_ThongTin entities
        public async Task<List<TCQ_ThongTinDto>> GetAllAsync()
        {
            var items = await _context!.TCQ_ThongTin!
                .Where(u => u.DaXoa == false)
                .ToListAsync();

            var listItems = _mapper.Map<List<TCQ_ThongTinDto>>(items);

            foreach (var dto in listItems)
            {
                await PopulateDataAsync(dto);
            }

            return listItems;
        }

        // Method to get TCQ_ThongTin entities by licensing authorities
        public async Task<List<TCQ_ThongTinDto>> GetByLicensingAuthoritiesAsync(string coquan_cp)
        {
            var query = _context!.TCQ_ThongTin!
                .Where(u => u.DaXoa == false)
                .Include(tcq => tcq.GP_TCQ)
                .OrderBy(x => x.NgayKy)
                .AsQueryable();

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

            foreach (var dto in listItems)
            {
                await PopulateDataAsync(dto);
            }

            return listItems;
        }

        // Method to get TCQ_ThongTin entity by Id
        public async Task<TCQ_ThongTinDto> GetByIdAsync(int Id)
        {
            var item = await _context.TCQ_ThongTin!.FindAsync(Id);

            var dto = _mapper.Map<TCQ_ThongTinDto>(item);
            await PopulateDataAsync(dto);
            return dto;
        }

        private async Task PopulateDataAsync(TCQ_ThongTinDto dto)
        {
            var qd_bosung = await _context!.TCQ_ThongTin!.FirstOrDefaultAsync(tcq => tcq.Id == dto.IdCon && tcq.DaXoa == false);
            dto.qd_bosung = _mapper.Map<TCQ_ThongTinDto>(qd_bosung);
            if (qd_bosung != null)
            {
                dto.qd_bosung.gp_tcq = null;
            }

            // Assuming this code is within an async method
            var gpIds = dto.gp_tcq!.Select(x => x.IdGP).ToList();

            var gpList = await _context.GP_ThongTin!
                .Where(x => gpIds.Contains(x.Id) && x.DaXoa == false)
                .ToListAsync();

            dto.giayphep = _mapper.Map<List<GP_ThongTinDto>>(gpList);

            if (dto.giayphep != null)
            {
                foreach (var gp in dto.giayphep)
                {
                    gp.gp_tcq = null;
                }
                var ctIds = dto.giayphep.Select(x => x.IdCT).ToList();
                var cts = await _context.CT_ThongTin!.Where(ct => ctIds.Contains(ct.Id)).ToListAsync();
                dto.congtrinh = _mapper.Map<List<CT_ThongTinDto>>(cts);
                if (dto.congtrinh != null)
                {
                    foreach (var ct in dto.congtrinh)
                    {
                        ct.giayphep = null;
                    }
                }
            }

            dto.gp_tcq = null;
        }

        // Method to save or update a TCQ_ThongTin entity
        public async Task<int> SaveAsync(TCQ_ThongTinDto dto)
        {
            int id = 0;
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);
            TCQ_ThongTin? item = null; // Declare item variable

            // Retrieve an existing item based on Id or if dto.Id is 0
            var existingItem = await _context.TCQ_ThongTin!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                // If the item doesn't exist or dto.Id is 0, create a new item
                item = _mapper.Map<TCQ_ThongTin>(dto);
                item.DaXoa = false;
                item.ThoiGianTao = DateTime.Now;
                item.TaiKhoanTao = currentUser != null ? currentUser.UserName : null;
                _context.TCQ_ThongTin!.Add(item);
            }
            else
            {
                // If the item exists, update it with values from the dto
                item = existingItem;
                _mapper.Map(dto, item);
                item.DaXoa = false;
                item.ThoiGianSua = DateTime.Now;
                item.TaiKhoanSua = currentUser != null ? currentUser.UserName : null;
                _context.TCQ_ThongTin!.Update(item);
            }

            // Save changes to the database
            var res = await _context.SaveChangesAsync();

            // Simplified assignment of id based on the result of SaveChanges
            id = (int)(res > 0 ? item.Id : 0);

            // Return the id
            return id;
        }

        // Method to delete a TCQ_ThongTin entity
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

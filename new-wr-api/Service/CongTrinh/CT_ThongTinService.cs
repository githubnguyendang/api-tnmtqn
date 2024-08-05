using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using new_wr_api.Data;
using new_wr_api.Dto;

namespace new_wr_api.Service
{
    public class CT_ThongTinService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly ILogChangeService _logChangeService;

        // Constructor to initialize the service with required dependencies
        public CT_ThongTinService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager, ILogChangeService logChangeService)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
            _logChangeService = logChangeService;
        }

        // Method to retrieve a list of CT_ThongTin entities based on specified filters
        public async Task<List<CT_ThongTinDto>> GetAllAsync(string? TenCT, int? IdLoaiCT, int? IdHuyen, int? IdXa, int? IdSong, int? IdLuuVuc, int? IdTieuLuuVuc, int? IdTangChuaNuoc, string? NguonNuocKT)
        {
            _context.Database.SetCommandTimeout(120);

            var query = _context.CT_ThongTin!
                .Where(ct => ct.DaXoa == false)
                .Include(ct => ct.LoaiCT)
                .Include(ct => ct.TangChuaNuoc)
                .Include(ct => ct.HangMuc!).ThenInclude(hm => hm.ThongSo)
                .Include(ct => ct.ThongSo)
                .Include(ct => ct.LuuVuc)
                .Include(ct => ct.CT_ViTri!).ThenInclude(vt => vt.Xa)
                .Include(ct => ct.CT_ViTri!).ThenInclude(vt => vt.Huyen)
                .Include(ct => ct.GiayPhep!).ThenInclude(gp => gp.ToChuc_CaNhan)
                .Include(ct => ct.GiayPhep!).ThenInclude(gp => gp.GP_TCQ)
                .Include(ct => ct.LuuLuongTheoMucDich!).ThenInclude(lld => lld.MucDichKT)
                .OrderBy(x => x.IdLoaiCT)
                .AsQueryable();

            // Apply filters based on input parameters
            if (!string.IsNullOrEmpty(TenCT))
            {
                query = query.Where(ct => ct.TenCT!.Contains(TenCT));
            }

            if (IdLoaiCT > 0)
            {
                query = query.Where(ct => IdLoaiCT == 1 || IdLoaiCT == 2 || IdLoaiCT == 3 || IdLoaiCT == 24 ? ct.LoaiCT!.IdCha == IdLoaiCT : ct.LoaiCT!.Id == IdLoaiCT);
            }

            if (IdXa > 0)
            {
                query = query.Where(ct => ct.CT_ViTri!.Any(x => x.IdXa!.Contains(IdXa.ToString()!)));
            }

            if (IdHuyen > 0)
            {
                query = query.Where(ct => ct.CT_ViTri!.Any(x => x.IdHuyen!.Contains(IdHuyen.ToString()!)));
            }

            if (IdSong > 0)
            {
                query = query.Where(ct => ct.IdSong == IdSong);
            }

            if (IdLuuVuc > 0)
            {
                query = query.Where(ct => ct.IdLuuVuc == IdLuuVuc);
            }

            if (IdTieuLuuVuc > 0)
            {
                query = query.Where(ct => ct.IdTieuLuuVuc == IdTieuLuuVuc);
            }

            if (IdTangChuaNuoc > 0)
            {
                query = query.Where(ct => ct.IdTangChuaNuoc == IdTangChuaNuoc);
            }

            if (!string.IsNullOrEmpty(NguonNuocKT))
            {
                query = query.Where(ct => ct.NguonNuocKT!.Contains(NguonNuocKT));
            }

            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            if (currentUser != null)
            {
                if (await _userManager.IsInRoleAsync(currentUser!, "Construction"))
                {
                    query = query.Where(ct => ct.TaiKhoan!.ToLower() == currentUser!.UserName!.ToLower());
                }

                if (await _userManager.IsInRoleAsync(currentUser!, "District"))
                {
                    query = query.Where(ct => ct.CT_ViTri!.Any(x => x.IdHuyen == currentUser!.IdHuyen));
                }
            }

            var congtrinh = await query.ToListAsync();

            // Map the result to DTOs
            var congTrinhDtos = _mapper.Map<List<CT_ThongTinDto>>(congtrinh);

            // Further processing on DTOs
            foreach (var dto in congTrinhDtos)
            {
                await PopulateDataAsync(dto);
            }

            // Return the list of DTOs
            return congTrinhDtos;
        }

        // Method to retrieve a single CT_ThongTin entity by Id
        public async Task<CT_ThongTinDto?> GetByIdAsync(int Id)
        {
            var query = _context.CT_ThongTin!
                .Where(ct => ct.DaXoa == false)
                .Include(ct => ct.LoaiCT)
                .Include(ct => ct.TangChuaNuoc)
                .Include(ct => ct.HangMuc!).ThenInclude(hm => hm.ThongSo)
                .Include(ct => ct.ThongSo)
                .Include(ct => ct.LuuVuc)
                .Include(ct => ct.CT_ViTri)
                .Include(ct => ct.CT_ViTri!).ThenInclude(vt => vt.Xa)
                .Include(ct => ct.CT_ViTri!).ThenInclude(vt => vt.Huyen)
                .Include(ct => ct.GiayPhep!).ThenInclude(gp => gp.ToChuc_CaNhan)
                .Include(ct => ct.GiayPhep!).ThenInclude(gp => gp.GP_TCQ)
                .Include(ct => ct.LuuLuongTheoMucDich!).ThenInclude(lld => lld.MucDichKT)
                .OrderBy(x => x.IdLoaiCT)
                .AsQueryable();

            var congTrinh = await query.SingleOrDefaultAsync(ct => ct.Id == Id);

            if (congTrinh == null)
            {
                // Handle the case where the record is not found
                return null;
            }

            var congTrinhDto = _mapper.Map<CT_ThongTinDto>(congTrinh);

            await PopulateDataAsync(congTrinhDto);

            return congTrinhDto;
        }

        private async Task PopulateDataAsync(CT_ThongTinDto dto)
        {
            dto.hangmuc = _mapper.Map<List<CT_HangMucDto>>(dto.hangmuc!.Where(x => x.DaXoa == false));
            //dto.luuluongtheo_mucdich = _mapper.Map<List<LuuLuongTheoMucDichDto>>(dto.luuluongtheo_mucdich!.Where(x => x.DaXoa == false));

            dto.giayphep = _mapper.Map<List<GP_ThongTinDto>>(dto.giayphep!.Where(x => x.DaXoa == false));

            foreach (var dtoGP in dto.giayphep)
            {
                var tcqIds = dtoGP.gp_tcq!.Select(x => x.IdTCQ).ToList();

                var tcqThongTinList = await _context.TCQ_ThongTin!
                    .Where(x => tcqIds.Contains(x.Id) && x.DaXoa == false)
                    .ToListAsync();

                dtoGP.tiencq = _mapper.Map<List<TCQ_ThongTinDto>>(tcqThongTinList);

                dtoGP.gp_tcq = null;
            }
        }

        // Method to save or update a CT_ThongTin entity
        public async Task<int> SaveAsync(CT_ThongTinSaveDto dto)
        {
            int id = 0;
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);
            CT_ThongTin? item = null; // Declare item variable

            // Retrieve an existing item based on Id or if dto.Id is 0
            var existingItem = await _context.CT_ThongTin!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.DaXoa == false);

            if (existingItem == null || dto.Id == 0)
            {
                // If the item doesn't exist or dto.Id is 0, create a new item
                item = _mapper.Map<CT_ThongTin>(dto);
                item.DaXoa = false;
                item.ThoiGianTao = DateTime.Now;
                item.TaiKhoanTao = currentUser != null ? currentUser.UserName : null;
                _context.CT_ThongTin!.Add(item);

                // Log the creation (CREATED)
                await _logChangeService.LogChangeAsync(
                    "CT_ThongTin",
                    "CREATED",
                    null,
                    item,
                    currentUser != null ? currentUser.UserName : null
                );
            }
            else
            {
                // If the item exists, update it with values from the dto
                var oldItem = _mapper.Map<CT_ThongTinSaveDto>(existingItem);
                item = existingItem;
                _mapper.Map(dto, item);
                item.DaXoa = false;
                item.ThoiGianSua = DateTime.Now;
                item.TaiKhoanSua = currentUser != null ? currentUser.UserName : null;
                _context.CT_ThongTin!.Update(item);

                // Log the creation (UPDATED)
                await _logChangeService.LogChangeAsync(
                    "CT_ThongTin",
                    "UPDATED",
                    oldItem,
                    dto,
                    currentUser != null ? currentUser.UserName : null
                );
            }

            // Save changes to the database
            var res = await _context.SaveChangesAsync();

            // Simplified assignment of id based on the result of SaveChanges
            id = (int)(res > 0 ? item.Id : 0);

            // Return the id
            return id;
        }

        // Method to delete a CT_ThongTin entity
        public async Task<bool> DeleteAsync(int Id)
        {
            // Retrieve an existing item based on Id
            var existingItem = await _context.CT_ThongTin!.FirstOrDefaultAsync(d => d.Id == Id && d.DaXoa == false);
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            if (existingItem == null) { return false; } // If the item doesn't exist, return false

            var oldItem = _mapper.Map<CT_ThongTinSaveDto>(existingItem);
            existingItem!.DaXoa = true; // Mark the item as deleted
            existingItem.ThoiGianSua = DateTime.Now;
            existingItem.TaiKhoanSua = currentUser != null ? currentUser.UserName : null;
            _context.CT_ThongTin!.Update(existingItem);

            // Log the creation (DELETE)
            await _logChangeService.LogChangeAsync(
                "CT_ThongTin",
                "DELETE",
                null,
                oldItem,
                currentUser != null ? currentUser.UserName : null
            );

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return true to indicate successful deletion
            return true;
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using new_wr_api.Data;
using new_wr_api.Dto;
using System.Security.Claims;

namespace new_wr_api.Service
{
    public class GiamSatService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        // Constructor to initialize the service with required dependencies
        public GiamSatService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        // Method to retrieve and map all data for monitoring
        public async Task<List<GS_SoLieuDto>> GetAllAsync(int? loaict, int? tochuc_canhan, string? tenct)
        {
            // Initial query to retrieve construction information
            var query = _context.CT_ThongTin!
                .Where(ct => ct.DaXoa == false)
                .Include(ct => ct.LoaiCT)
                .Include(ct => ct.TangChuaNuoc)
                .Include(ct => ct.ThongSo)
                .Include(ct => ct.GiayPhep!).ThenInclude(gp => gp.ToChuc_CaNhan)
                .OrderBy(x => x.IdLoaiCT)
                .AsQueryable();

            // Apply additional filters based on parameters
            if (loaict > 0)
            {
                query = query.Where(ct => loaict == 1 || loaict == 2 || loaict == 3 || loaict == 24 ? ct.LoaiCT!.IdCha == loaict : ct.LoaiCT!.Id == loaict);
            }

            if (tochuc_canhan > 0)
            {
                query = query.Where(ct => ct.GiayPhep!.Any(gp => gp.IdTCCN == tochuc_canhan));
            }

            if (!string.IsNullOrEmpty(tenct))
            {
                query = query.Where(ct => ct.TenCT!.Contains(tenct));
            }

            var congtrinh = await query.ToListAsync();

            // Map the construction information to DTOs
            var congTrinhDtos = _mapper.Map<List<GS_SoLieuDto>>(congtrinh);

            // Iterate over each DTO and retrieve additional monitoring data
            foreach (var item in congTrinhDtos)
            {
                var solieu = _context.GS_DuLieu!.Where(x => x.ConstructionCode == item.MaCT).OrderByDescending(x => x.Time).FirstOrDefault();

                if (solieu != null)
                {
                    // Map monitoring data to DTO properties
                    item.ThoiGian = solieu.Time;

                    switch (solieu.StationCode!.ToLower())
                    {
                        case "quatran":
                            item.QXaTranTT = solieu.Value;
                            break;
                        case "nhamay":
                            item.QXaMaxTT = solieu.Value;
                            break;
                        case "dctt":
                            item.DCTTTT = solieu.Value;
                            break;
                        case "haluu":
                            item.HHaLuuTT = solieu.Value;
                        break;
                        case "dungtich":
                            item.DungTichTT = solieu.Value;
                        break;
                        case "thuongluu":
                            item.HThuongLuuTT = solieu.Value;
                        break;
                    }
                }
            }

            // Return the list of mapped DTOs
            return congTrinhDtos;
        }
    }
}

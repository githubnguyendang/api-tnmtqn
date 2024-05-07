using AutoMapper;
using Microsoft.EntityFrameworkCore;
using new_wr_api.Data;
using new_wr_api.Dto;

namespace new_wr_api.Service
{
    public class BieuMauMuoiBonService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public BieuMauMuoiBonService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BieuMauMuoiBonDto>?> GetAllAsync(int? nam)
        {
            var items = _context.CLN_NDD!.Where(d => d.DaXoa == false && d.ThoiGianQuanTrac == nam)
                .Select(cln => new BieuMauMuoiBonDto
                {
                    Id = cln.Id,
                    ThoiGianQuanTrac = cln.ThoiGianQuanTrac,
                    LuuVucSong = cln.LuuVucSong,
                    TangChuaNuoc = cln.TangChuaNuoc,
                    ViTriQuanTrac = cln.ViTriQuanTrac,
                    PHlonNhat = new[] { cln.PhDot1 , cln.PhDot2 , cln.PhDot3  }.Max(),
                    PHNhoNhat = new[] { cln.PhDot1, cln.PhDot2, cln.PhDot3 }.Min(),
                    PHTrungBinh = Math.Round((double)new[] { cln.PhDot1 , cln.PhDot2 , cln.PhDot3  }.Average()!, 2),
                    ColiformlonNhat = new[] { cln.ColiformDot1 , cln.ColiformDot2 , cln.ColiformDot3  }.Max(),
                    ColiformNhoNhat = new[] { cln.ColiformDot1 , cln.ColiformDot2 , cln.ColiformDot3  }.Min(),
                    ColiformTrungBinh = Math.Round((double)new[] { cln.ColiformDot1 , cln.ColiformDot2 , cln.ColiformDot3  }.Average()!, 2),
                    NitratelonNhat = new[] { cln.NitrateDot1 , cln.NitrateDot2 , cln.NitrateDot3  }.Max(),
                    NitrateNhoNhat = new[] { cln.NitrateDot1 , cln.NitrateDot2 , cln.NitrateDot3  }.Min(),
                    NitrateTrungBinh = Math.Round((double)new[] { cln.NitrateDot1 , cln.NitrateDot2 , cln.NitrateDot3  }.Average()!, 2),
                    AmonilonNhat = new[] { cln.AmoniDot1 , cln.AmoniDot2 , cln.AmoniDot3  }.Max(),
                    AmoniNhoNhat = new[] { cln.AmoniDot1 , cln.AmoniDot2 , cln.AmoniDot3  }.Min(),
                    AmoniTrungBinh = Math.Round((double)new[] { cln.AmoniDot1 , cln.AmoniDot2 , cln.AmoniDot3  }.Average()!, 2),
                    TDSlonNhat = new[] { cln.TDSDot1 , cln.TDSDot2 , cln.TDSDot3  }.Max(),
                    TDSNhoNhat = new[] { cln.TDSDot1 , cln.TDSDot2 , cln.TDSDot3  }.Min(),
                    TDSTrungBinh = Math.Round((double)new[] { cln.TDSDot1 , cln.TDSDot2 , cln.TDSDot3  }.Average()!, 2),
                    DoCungLonNhat =new[] { cln.DoCungDot1 ?? 0, cln.DoCungDot2 ??0, cln.DoCungDot3 ?? 0 }.Max(),
                    DoCungNhoNhat = new[] { cln.DoCungDot1 ?? 0, cln.DoCungDot2 ?? 0, cln.DoCungDot3 ?? 0 }.Min(),
                    DoCungTrungBinh = Math.Round((double)new[] { cln.DoCungDot1 ?? 0, cln.DoCungDot2 ??0, cln.DoCungDot3 ??0}.Average()!, 2),
                    ArsenicLonNhat = new[] { cln.ArsenicDot1 ?? 0, cln.ArsenicDot2 ?? 0, cln.ArsenicDot3 ?? 0 }.Max(),
                    ArsenicNhoNhat = new[] { cln.ArsenicDot1 ?? 0, cln.ArsenicDot2 ?? 0, cln.ArsenicDot3 ?? 0 }.Min(),
                    ArsenicTrungBinh =Math.Round((double)new[] { cln.ArsenicDot1 ?? 0, cln.ArsenicDot2 ?? 0, cln.ArsenicDot3 ?? 0 }.Average()!, 2),
                    ChlorideLonNhat = new[] { cln.ChlorideDot1 , cln.ChlorideDot2 , cln.ChlorideDot3  }.Max(),
                    ChlorideNhoNhat = new[] { cln.ChlorideDot1 , cln.ChlorideDot2 , cln.ChlorideDot3  }.Min(),
                    ChlorideTrungBinh = Math.Round((double)new[] { cln.ChlorideDot1 , cln.ChlorideDot2 , cln.ChlorideDot3  }.Average()!, 2),

                })
                .OrderBy(d => d.Id)
                .AsQueryable();

            var ttdlDto = _mapper.Map<List<BieuMauMuoiBonDto>>(await items.ToListAsync());

            return ttdlDto;
        }
    }
}


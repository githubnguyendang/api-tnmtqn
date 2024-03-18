using AutoMapper;
using new_wr_api.Data;
using new_wr_api.Data.BC.KNTiepNhanNuocThai.KNTNNTSong;
using new_wr_api.Data.KiemKeTNN;
using new_wr_api.Data.VHHC.MuaLu.LuongMua;
using new_wr_api.Dto;
using new_wr_api.Dto.VHHC;
using new_wr_api.Models;
using new_wr_api.Models.Authenticate;

namespace new_wr_api.Helpers
{
    public class MapperConfigure : Profile
    {
        public MapperConfigure()
        {

            //-------------Authenticatiion--------------------

            //Users
            CreateMap<AspNetUsers, UserModel>().ReverseMap();

            //Users Info
            CreateMap<AspNetUsers, UserInfoModel>().ForMember(dest => dest.Dashboards, opt =>
                {
                    opt.MapFrom((src, dest) => dest.Dashboards);
                }).ReverseMap();

            //Roles
            CreateMap<AspNetRoles, RoleModel>()
                .ForMember(dest => dest.Dashboards, opt =>
                {
                    opt.MapFrom((src, dest) => dest.Dashboards);
                }).ReverseMap();

            //Dashboards
            CreateMap<Dashboards, DashboardModel>()
                .ForMember(dest => dest.Functions, opt =>
                {
                    opt.MapFrom((src, dest) => dest.Functions);
                }).ReverseMap();

            //Permissions
            CreateMap<Permissions, PermissionModel>().ReverseMap();

            //Dashboard for Roles and Users
            CreateMap<UserDashboards, UserDashboardModel>().ReverseMap();
            CreateMap<RoleDashboards, RoleDashboardModel>().ReverseMap();

            //functions
            CreateMap<Functions, FunctionModel>().ReverseMap();

            //-------------Other mapper--------------------

            CreateMap<CT_Loai, CT_LoaiDto>().ReverseMap();
            CreateMap<CT_HangMuc, CT_HangMucDto>().ReverseMap();
            CreateMap<CT_ThongSo, CT_ThongSoDto>().ReverseMap();
            CreateMap<CT_ThongTin, CT_ThongTinDto>()
                .ForMember(dest => dest.loaiCT, opt => opt.MapFrom(src => src.LoaiCT))
                .ForMember(dest => dest.hangmuc, opt => opt.MapFrom(src => src.HangMuc))
                .ForMember(dest => dest.thongso, opt => opt.MapFrom(src => src.ThongSo))
                .ForMember(dest => dest.huyen, opt => opt.MapFrom(src => src.Huyen))
                .ForMember(dest => dest.xa, opt => opt.MapFrom(src => src.Xa))
                .ForMember(dest => dest.donvi_hanhchinh, opt => opt.MapFrom((src, dest) => dest.donvi_hanhchinh))
                .ForMember(dest => dest.giayphep, opt => opt.MapFrom(src => src.GiayPhep))
                .ForMember(dest => dest.luuluongtheo_mucdich, opt => opt.MapFrom(src => src.LuuLuongTheoMucDich))
            .ReverseMap();

            CreateMap<LuuLuongTheoMucDich, LuuLuongTheoMucDichDto>().ReverseMap();

            CreateMap<DonViHC, DonViHCDto>().ReverseMap();
            CreateMap<Huyen, HuyenDto>().ReverseMap();
            CreateMap<Xa, XaDto>().ReverseMap();

            CreateMap<GP_Loai, GP_LoaiDto>().ReverseMap();
            CreateMap<GP_ThongTin, GP_ThongTinDto>()
                .ForMember(dest => dest.tochuc_canhan, opt => opt.MapFrom(src => src.ToChuc_CaNhan))
                .ForMember(dest => dest.loaiGP, opt => opt.MapFrom(src => src.LoaiGP))
                .ForMember(dest => dest.congtrinh, opt => opt.MapFrom(src => src.CongTrinh))
                .ForMember(dest => dest.gp_tcq, opt => opt.MapFrom(src => src.GP_TCQ))
                .ForMember(dest => dest.tiencq, opt => opt.MapFrom((src, dest) => dest.tiencq))
                .ReverseMap();

            CreateMap<GP_TCQ, GP_TCQDto>().ReverseMap();

            CreateMap<TCQ_ThongTin, TCQ_ThongTinDto>()
                .ForMember(dest => dest.giayphep, opt => opt.MapFrom((src, dest) => dest.giayphep))
                .ForMember(dest => dest.congtrinh, opt => opt.MapFrom((src, dest) => dest.congtrinh))
                .ReverseMap();

            CreateMap<ToChuc_CaNhan, ToChuc_CaNhanDto>().ReverseMap();

            //baocaobieumau
            CreateMap<BieuMauSoMot, BieuMauMotDto>().ReverseMap();
            CreateMap<BieuMauSoHai, BieuMauHaiDto>().ReverseMap();
            CreateMap<BieuMauSoBa, BieuMauBaDto>().ReverseMap();
            CreateMap<BieuMauSoBon, BieuMauBonDto>().ReverseMap();
            CreateMap<BieuMauSoNam, BieuMauNamDto>().ReverseMap();
            CreateMap<BieuMauSoSau, BieuMauSauDto>().ReverseMap();
            CreateMap<BieuMauSoBay, BieuMauBayDto>().ReverseMap();
            CreateMap<BieuMauSoTam, BieuMauTamDto>().ReverseMap();
            CreateMap<BieuMauSoChin, BieuMauChinDto>().ReverseMap();
            CreateMap<BieuMauSoMuoi, BieuMauMuoiDto>().ReverseMap();
            CreateMap<BieuMauSoMuoiMot, BieuMauMuoiMotDto>().ReverseMap();
            CreateMap<BieuMauSoMuoiHai, BieuMauMuoiHaiDto>().ReverseMap();
            CreateMap<BieuMauSoMuoiBa, BieuMauMuoiBaDto>().ReverseMap();
            CreateMap<BieuMauSoMuoiBon, BieuMauMuoiBonDto>().ReverseMap();
            CreateMap<BieuMauSoMuoiNam, BieuMauMuoiLamDto>().ReverseMap();
            CreateMap<BieuMauSoMuoiSau, BieuMauMuoiSauDto>().ReverseMap();
            CreateMap<BieuMauSoMuoiBay, BieuMauMuoiBayDto>().ReverseMap();
            CreateMap<BieuMauSoMuoiTam, BieuMauMuoiTamDto>().ReverseMap();
            CreateMap<BieuMauSoMuoiChin, BieuMauMuoiChinDto>().ReverseMap();
            CreateMap<BieuMauSoHaiMot, BieuMauHaiMotDto>().ReverseMap();
            CreateMap<BieuMauSoHaiHai, BieuMauHaiHaiDto>().ReverseMap();
            CreateMap<BieuMauSoHaiBa, BieuMauHaiBaDto>().ReverseMap();
            CreateMap<BieuMauSoHaiTu, BieuMauHaiTuDto>().ReverseMap();
            CreateMap<BieuMauSoHaiLam, BieuMauHaiLamDto>().ReverseMap();

            //KNTiepNhanNuocThai
            CreateMap<ThongSoCLNSong, ThongSoCLNSongDto>().ReverseMap();
            CreateMap<ThongSoCLNAo, ThongSoCLNAoDto>().ReverseMap();
            CreateMap<DoanSong, DoanSongDto>()
                .ForMember(dest => dest.ThongSoLtd, opt => opt.MapFrom(src => src.ThongSoLtd))
                .ReverseMap();
            CreateMap<ThongSoLtd, ThongSoLtdDto>().ReverseMap();
            CreateMap<DuLieuNguonNuocNhan, DuLieuNguonNuocNhanDto>()
                .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<DuLieuNguonNuocThaiDiem, DuLieuNguonNuocThaiDiemDto>()
                .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<DuLieuNguonNuocThaiSinhHoat, DuLieuNguonNuocThaiSinhHoatDto>()
               .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<DuLieuNguonNuocThaiTrauBo, DuLieuNguonNuocThaiTrauBoDto>()
              .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<DuLieuNguonNuocThaiLon, DuLieuNguonNuocThaiLonDto>()
             .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<DuLieuNguonNuocThaiGiaCam, DuLieuNguonNuocThaiGiaCamDto>()
            .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<DuLieuNguonNuocThaiTrongLua, DuLieuNguonNuocThaiTrongLuaDto>()
            .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap(); 
            CreateMap<DuLieuNguonNuocThaiTrongCay, DuLieuNguonNuocThaiTrongCayDto>()
            .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<DuLieuNguonNuocThaiTrongRung, DuLieuNguonNuocThaiTrongRungDto>()
           .ForMember(dest => dest.PhanDoanSong, opt => opt.MapFrom(src => src.PhanDoanSong)).ReverseMap();
            CreateMap<PhanDoanSong, PhanDoanSongDto>().ReverseMap();


            //KiemKeTaiNguyenNuoc
            CreateMap<Tram_ThongTin, Tram_ThongTinDto>()
                .ForMember(dest => dest.tongluong_nuocmua, opt => opt.MapFrom(src => src.KKTNN_NuocMua_TongLuong))
                .ForMember(dest => dest.huyen, opt => opt.MapFrom(src => src.Huyen))
                .ForMember(dest => dest.xa, opt => opt.MapFrom(src => src.Xa))
                .ReverseMap();
            CreateMap<KKTNN_NuocMua_TongLuong, KKTNN_NuocMua_TongLuongDto>().ReverseMap();
            CreateMap<KKTNN_NuocMat_SoLuong_SongSuoi, KKTNN_NuocMat_SoLuong_SongSuoiDto>().ReverseMap();

            CreateMap<KKTNN_NuocMat_SoLuong_AoHoDamPha, KKTNN_NuocMat_SoLuong_AoHoDamPhaDto>().ReverseMap();

            CreateMap<CT_ThongTin, KKTNN_NuocMat_KhaiThacSuDungDto>()
                 .ForMember(dest => dest.ten_ct, opt => opt.MapFrom(src => src.TenCT))
                 .ForMember(dest => dest.loai_ct, opt => opt.MapFrom(src => src.LoaiCT!.TenLoaiCT))
                 .ForMember(dest => dest.nguonnuoc_kt, opt => opt.MapFrom(src => src.NguonNuocKT))
                 .ForMember(dest => dest.mucdich_kt, opt => opt.MapFrom(src => src.MucDichKTSD!.MucDich))
                 .ForMember(dest => dest.dungtich_ho, opt => opt.MapFrom(src => src.ThongSo!.DungTichToanBo))
                 .ForMember(dest => dest.congsuat, opt => opt.MapFrom(src => src.ThongSo!.CongSuatLM))
                 .ForMember(dest => dest.xa, opt => opt.MapFrom(src => src.Xa!.TenXa))
                 .ForMember(dest => dest.huyen, opt => opt.MapFrom(src => src.Huyen!.TenHuyen))
                 .ForMember(dest => dest.q_kt_tuoi, opt => opt.MapFrom(src => src.MucDichKTSD!.Id == 4 ? src.ThongSo!.QMaxKT : null))
                 .ForMember(dest => dest.q_kt_kddv_sx_phi_nn, opt => opt.MapFrom(src => new List<int> { 2, 3 }.Contains(src.MucDichKTSD!.Id) ? src.ThongSo!.QMaxKT * 86400 : null))
                 .ForMember(dest => dest.mucdich_khac, opt => opt.MapFrom(src => !new List<int> { 2, 3, 4 }.Contains(src.MucDichKTSD!.Id) ? src.ThongSo!.QMaxKT * 86400 : null))
                 .ReverseMap();

            CreateMap<KKTNN_NuocMat_TongLuong, KKTNN_NuocMat_TongLuongDto>()
                .ForMember(dest => dest.LuuVucSong, opt => opt.MapFrom(src => src.LuuVucSong))
                .ForMember(dest => dest.donvi_hanhchinh, opt => opt.MapFrom((src, dest) => dest.donvi_hanhchinh))
                .ReverseMap();

            CreateMap<CT_ThongTin, GS_SoLieuDto>()
                .ForMember(dest => dest.loaiCT, opt => opt.MapFrom(src => src.LoaiCT))
                .ForMember(dest => dest.thongso, opt => opt.MapFrom(src => src.ThongSo))
                .ReverseMap();

            CreateMap<KKTNN_NuocMat_ChatLuong, KKTNN_NuocMat_ChatLuongDto>().ReverseMap();
            CreateMap<KKTNN_NuocDuoiDat_SoLuong, KKTNN_NuocDuoiDat_SoLuongDto>()
               .ForMember(dest => dest.TangChuaNuoc, opt => opt.MapFrom(src => src.TangChuaNuoc))
               .ReverseMap();
            CreateMap<KKTNN_NuocDuoiDat_TongLuong, KKTNN_NuocDuoiDat_TongLuongDto>()
              .ForMember(dest => dest.TangChuaNuoc, opt => opt.MapFrom(src => src.TangChuaNuoc))
              .ReverseMap();
            CreateMap<LuuVucSong, KKTNN_NuocDuoiDat_ChatLuongDto>()
               .ForMember(dest => dest.donvi_hanhchinh, opt => opt.MapFrom((src, dest) => dest.donvi_hanhchinh))
               .ReverseMap();
            //Song
            CreateMap<Song, SongDto>().ReverseMap();

            //LuuVucSong
            CreateMap<LuuVucSong, LuuVucSongDto>().ReverseMap();

            //TangChuaNuoc
            CreateMap<TangChuaNuoc, TangChuaNuocDto>().ReverseMap();

            //ThongTinDuLieu
            CreateMap<NN_LuuVucSong, NN_LuuVucSongDto>().ReverseMap();
            CreateMap<NN_NguonNuoc_SongSuoi, NN_NguonNuoc_SongSuoiDto>().ReverseMap();
            CreateMap<NN_NguonNuoc_AoHoDamPha, NN_NguonNuoc_AoHoDamPhaDto>().ReverseMap();
            CreateMap<NN_NguonNuoc_TangChuaNuoc, NN_NguonNuoc_TangChuaNuocDto>().ReverseMap();
            CreateMap<NN_AoHoDamPhaKhongDuocSanLap, NN_AoHoDamPhaKhongDuocSanLapDto>().ReverseMap();
            CreateMap<NN_HanhLangBaoVeNN_SongSuoi, NN_HanhLangBaoVeNN_SongSuoiDto>().ReverseMap();
            CreateMap<NN_HanhLangBaoVeNN_HoThuyLoiNhieuHon1m3, NN_HanhLangBaoVeNN_HoThuyLoiNhieuHon1m3Dto>().ReverseMap();
            CreateMap<NN_HanhLangBaoVeNN_HoThuyLoiItHon1m3, NN_HanhLangBaoVeNN_HoThuyLoiItHon1m3Dto>().ReverseMap();
            CreateMap<NN_HanhLangBaoVeNN_AoHoDamTuNhienNhanTao, NN_HanhLangBaoVeNN_AoHoDamTuNhienNhanTaoDto>().ReverseMap();
            CreateMap<NN_CNNN_SongSuoi, NN_CNNN_SongSuoiDto>().ReverseMap();
            CreateMap<NN_CNNN_Ho, NN_CNNN_HoDto>().ReverseMap();
            CreateMap<NN_CNNN_TangChuaNuoc, NN_CNNN_TangChuaNuocDto>().ReverseMap();
            CreateMap<NN_DCTT_SongSuoi, NN_DCTT_SongSuoiDto>().ReverseMap();
            CreateMap<NN_DCTT_HaDuHoChua, NN_DCTT_HaDuHoChuaDto>().ReverseMap();
            CreateMap<NN_NguongKhaiThacNDD, NN_NguongKhaiThacNDDDto>().ReverseMap();
            CreateMap<NN_VungCamHanCheKTNDD, NN_VungCamHanCheKTNDDDto>().ReverseMap();
            CreateMap<NN_MatCatSongSuoi, NN_MatCatSongSuoiDto>().ReverseMap();

            CreateMap<SLN_TongLuongNuocMat, SLN_TongLuongNuocMatDto>().ReverseMap();
            CreateMap<CLN_NuocMat, CLN_NuocMatDto>().ReverseMap();
            CreateMap<CLN_NDD, CLN_NDDDto>().ReverseMap();

            CreateMap<SLDTKTSDN_NuocMat, SLDTKTSDN_NuocMatDto>().ReverseMap();
            CreateMap<SLDTKTSDN_NDD, SLDTKTSDN_NDDDto>().ReverseMap();
            CreateMap<SLDTKTSDN_XaThai, SLDTKTSDN_XaThaiDto>().ReverseMap();

            CreateMap<CTKTSDN_PCGP_NDD, CTKTSDN_PCGP_NDDDto>().ReverseMap();
            CreateMap<CTKTSDN_PCGP_NuocBien, CTKTSDN_PCGP_NuocBienDto>().ReverseMap();
            CreateMap<CTKTSDN_PCGP_NuocMat, CTKTSDN_PCGP_NuocMatDto>().ReverseMap();
            CreateMap<CTKTSDN_PDK_NDD, CTKTSDN_PDK_NDDDto>().ReverseMap();
            CreateMap<CTKTSDN_PDK_NuocBien, CTKTSDN_PDK_NuocBienDto>().ReverseMap();
            CreateMap<CTKTSDN_PDK_NuocMat, CTKTSDN_PDK_NuocMatDto>().ReverseMap();
            CreateMap<CTKTSDN_KTNDDCuaHoGD, CTKTSDN_KTNDDCuaHoGDDto>().ReverseMap();

            CreateMap<HSKTT_NuocMat, HSKTT_NuocMatDto>().ReverseMap();
            CreateMap<HSKTT_NDD, HSKTT_NDDDto>().ReverseMap();

            CreateMap<DanhMucNN_LienTinh, DanhMucNN_LienTinhDto>().ReverseMap();
            CreateMap<DanhMucNN_NoiTinh_AoHo, DanhMucNN_NoiTinh_AoHoDto>().ReverseMap();
            CreateMap<DanhMucNN_NoiTinh_SongSuoi, DanhMucNN_NoiTinh_SongSuoiDto>().ReverseMap();

            CreateMap<CLN_NuocMat, CLN_NuocMatDto>().ReverseMap();

            //VanHanhHoChua
            CreateMap<VHHC_LuuVucSong, VHHC_LuuVucSongDto>().ReverseMap();
            CreateMap<VHHC_HoChua_ThongSoKT, VHHC_HoChua_ThongSoKTDto>().ReverseMap();
            CreateMap<MuaHienTai, MuaHienTaiDto>().ReverseMap();


            //demo
            CreateMap<Demo, DemoDto>().ReverseMap();
        }
    }
}

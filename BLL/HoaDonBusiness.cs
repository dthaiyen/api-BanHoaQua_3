using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class HoaDonBusiness : IHoaDonBusiness
    {
        private IHoaDonRepository _res;
        public HoaDonBusiness(IHoaDonRepository res)
        {
            _res = res;
        }

        public bool Dat_Hang(string maid, string ten_kh, string noi_giao, string sdt, int thanh_tien, List<ChiTietHoaDonModel> listjson_chitiet)
        {
            return _res.Dat_Hang(maid, ten_kh, noi_giao, sdt, thanh_tien, listjson_chitiet);
        }

        public List<HoaDonModel> Get_ALL_Hoadon()
        {
            return _res.Get_ALL_Hoadon();
        }

        public HoaDonModel Get_Hoadon_By_ID()
        {
            return _res.Get_Hoadon_By_ID();
        }
    }

}

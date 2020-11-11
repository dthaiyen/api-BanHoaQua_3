using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IHoaDonRepository
    {
        List<HoaDonModel> Get_ALL_Hoadon();
        HoaDonModel Get_Hoadon_By_ID();
        bool Dat_Hang(string maid, string ten_kh, string noi_giao, string sdt, int thanh_tien, List<ChiTietHoaDonModel> listjson_chitiet);
    }
}

using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class HoaDonRepository : IHoaDonRepository
    {
        private readonly IDatabaseHelper _dbHelper;
        public HoaDonRepository(IDatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }
        public List<HoaDonModel> Get_ALL_Hoadon()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_hoadon_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HoaDonModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HoaDonModel Get_Hoadon_By_ID()
        {
            throw new NotImplementedException();
        }
        public bool Dat_Hang(string maid, string ten_kh, string noi_giao, string sdt, int thanh_tien, List<ChiTietHoaDonModel> listjson_chitiet)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_dat_hang_2", "@ma_hoa_don", maid, "@ngay_dat", DateTime.Now, "@ngay_giao", DateTime.Now, "@tinhtrang", 0, "@makh", ten_kh, "@noi_giao", noi_giao, "@sdt", sdt, "@thanh_tien", thanh_tien, "@listjson_chitiet", listjson_chitiet != null ? MessageConvert.SerializeObject(listjson_chitiet) : null);
                if (!string.IsNullOrEmpty(msgError) || (!string.IsNullOrEmpty(dt.ToString()) && dt != null))
                    throw new Exception(msgError);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
